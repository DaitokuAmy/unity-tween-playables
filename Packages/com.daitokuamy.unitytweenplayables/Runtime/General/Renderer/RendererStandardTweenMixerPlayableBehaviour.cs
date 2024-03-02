using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// Rendererの汎用パラメータをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererStandardTweenMixerPlayableBehaviour : RendererTweenMixerPlayableBehaviour<RendererStandardTweenPlayableTrack, RendererStandardTweenPlayableBehaviour> {
        private ColorValueMixer _mainColorMixer = new();
        private Vector2ValueMixer _mainTextureOffsetMixer = new();
        private Vector2ValueMixer _mainTextureScaleMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Renderer component, RendererStandardTweenPlayableBehaviour lastBehaviour) {
            var targetMaterial = FindTargetMaterial(component);

            if (targetMaterial != null) {
                if (_mainColorMixer.IsValid) {
                    targetMaterial.color = _mainColorMixer.Value;
                    _mainColorMixer.Clear();
                }

                if (_mainTextureOffsetMixer.IsValid) {
                    targetMaterial.mainTextureOffset = _mainTextureOffsetMixer.Value.Mask(targetMaterial.mainTextureOffset, (int)~lastBehaviour.mainTextureOffset.ignoreMasks);
                    _mainTextureOffsetMixer.Clear();
                }

                if (_mainTextureScaleMixer.IsValid) {
                    targetMaterial.mainTextureScale = _mainTextureScaleMixer.Value.Mask(targetMaterial.mainTextureScale, (int)~lastBehaviour.mainTextureScale.ignoreMasks);
                    _mainTextureScaleMixer.Clear();
                }
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Renderer component, RendererStandardTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_mainColorMixer, behaviour.mainColor, behaviour, weight, progress);
            BlendValueMixer(_mainTextureOffsetMixer, behaviour.mainTextureOffset, behaviour, weight, progress);
            BlendValueMixer(_mainTextureScaleMixer, behaviour.mainTextureScale, behaviour, weight, progress);
        }
    }
}