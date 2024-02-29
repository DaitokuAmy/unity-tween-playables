using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// TweenPlayable用の設定データ
    /// </summary>
    [CreateAssetMenu(menuName = "Unity Tween Playables/Config Data", fileName = "UnityTweenPlayablesConfig.asset")]
    internal class TweenPlayableConfigData : ScriptableObject, ITweenPlayableConfig {
        /// <summary>
        /// テンプレート用カーブ情報
        /// </summary>
        [Serializable]
        public class TemplateCurve {
            [Tooltip("カーブ指定用のキー")]
            public string key = "Unknown";
            [Tooltip("アニメーションカーブ(timeが0～1, valueが0～1になるように指定してください)")]
            public AnimationCurve curve = new(new Keyframe(0, 0, 0, 1), new Keyframe(1, 1, 1, 0));
        }

        [Tooltip("テンプレートカーブ情報")]
        public TemplateCurve[] templateCurves;

        public EaseParameter Parameter;

        private Dictionary<string, TemplateCurve> _templateCurveDict;

        /// <summary>
        /// テンプレートカーブのキー一覧を取得
        /// </summary>
        public string[] GetTemplateCurveKeys() {
            if (_templateCurveDict == null) {
                RefreshTemplateCurveCache();
            }

            return _templateCurveDict.Keys.ToArray();
        }

        /// <summary>
        /// テンプレートカーブの検索
        /// </summary>
        public AnimationCurve FindTemplateCurve(string key) {
            if (_templateCurveDict == null) {
                RefreshTemplateCurveCache();
            }

            if (!_templateCurveDict.TryGetValue(key, out var curve)) {
                return null;
            }

            return curve.curve;
        }

#if UNITY_EDITOR
        /// <summary>
        /// 生成時の処理
        /// </summary>
        private void Awake() {
            TweenPlayableConfig.Reload();
        }
        
        /// <summary>
        /// 値変化時の通知
        /// </summary>
        private void OnValidate() {
            RefreshTemplateCurveCache();
            TweenPlayableConfig.Reload();
        }
#endif

        /// <summary>
        /// TemplateCurveアクセス用のキャッシュを更新
        /// </summary>
        private void RefreshTemplateCurveCache() {
            if (_templateCurveDict == null) {
                _templateCurveDict = new();
            }

            _templateCurveDict.Clear();
            foreach (var curve in templateCurves) {
                if (string.IsNullOrWhiteSpace(curve.key)) {
                    continue;
                }

                _templateCurveDict[curve.key] = curve;
            }
        }
    }
}