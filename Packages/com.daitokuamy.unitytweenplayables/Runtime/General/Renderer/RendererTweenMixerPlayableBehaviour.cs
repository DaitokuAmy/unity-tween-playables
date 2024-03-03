using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;
using Object = UnityEngine.Object;

namespace UnityTweenPlayables.General {
#if UNITY_EDITOR
    /// <summary>
    /// Editorモード用のRendererキャッシュ
    /// </summary>
    internal static class RendererEditorCache {
        // MaterialCloneキャッシュ
        public static readonly Dictionary<Renderer, List<Material>> CloneMaterials = new();
    }
#endif

    /// <summary>
    /// RendererをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public abstract class RendererTweenMixerPlayableBehaviour<TTrack, TBehaviour> : TweenMixerPlayableBehaviour<Renderer, TTrack, TBehaviour>
        where TTrack : TrackAsset, IRendererTweenPlayableTrack
        where TBehaviour : TweenPlayableBehaviour<Renderer, TTrack>, new() {
        private List<Material> _sharedMaterials = new();
        private Dictionary<Renderer, List<Material>> _sharedMaterialsDict = new();

        private string _cachedPropertyName;

        /// <summary>Material制御プロパティID</summary>
        protected int PropertyId { get; private set; }

        /// <summary>
        /// Playable廃棄時処理
        /// </summary>
        public override void OnPlayableDestroy(Playable playable) {
            // PropertyIdのキャッシュを削除
            _cachedPropertyName = null;
            PropertyId = -1;

#if UNITY_EDITOR
            // Editor用Materialのキャッシュを削除
            if (!Application.isPlaying) {
                foreach (var materials in RendererEditorCache.CloneMaterials.Values) {
                    foreach (var material in materials) {
                        if (material == null) {
                            continue;
                        }

                        Object.DestroyImmediate(material);
                    }
                }

                RendererEditorCache.CloneMaterials.Clear();
            }
#endif

            // Materialのキャッシュを削除
            _sharedMaterials.Clear();

            base.OnPlayableDestroy(playable);
        }

        /// <summary>
        /// フレーム解釈時処理
        /// </summary>
        public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
            // PropertyIdをキャッシュ
#if UNITY_EDITOR
            if (_cachedPropertyName == null || Track.PropertyName != _cachedPropertyName) {
#else
            if (_cachedPropertyName == null) {
#endif
                _cachedPropertyName = Track.PropertyName;
                PropertyId = Shader.PropertyToID(_cachedPropertyName);
            }

            // Materialをキャッシュ
            if (playerData is Renderer renderer) {
                if (!_sharedMaterialsDict.ContainsKey(renderer)) {
                    // MaterialをCloneして設定し直す
                    var materials = new List<Material>();

                    // 再生時は通常の取得フロー
                    if (Application.isPlaying) {
                        renderer.GetMaterials(materials);
                    }
#if UNITY_EDITOR
                    // 非再生時は独自でキャッシュする（エラーになるので）
                    else {
                        if (!RendererEditorCache.CloneMaterials.TryGetValue(renderer, out var cloneMaterials)) {
                            renderer.GetSharedMaterials(materials);
                            for (var i = 0; i < materials.Count; i++) {
                                materials[i] = Object.Instantiate(materials[i]);
                            }

                            RendererEditorCache.CloneMaterials[renderer] = materials;
                            renderer.SetSharedMaterials(materials);
                        }
                        else {
                            materials = cloneMaterials;
                        }
                    }
#endif

                    _sharedMaterialsDict.Add(renderer, materials);
                }
            }

            base.ProcessFrame(playable, info, playerData);
        }

        /// <summary>
        /// 操作対象のMaterialを検索
        /// </summary>
        protected Material FindTargetMaterial(Renderer component) {
            if (_sharedMaterialsDict.TryGetValue(component, out var materials)) {
                if (Track.MaterialIndex >= 0 && Track.MaterialIndex < materials.Count) {
                    return materials[Track.MaterialIndex];
                }
            }

            return null;
        }
    }
}