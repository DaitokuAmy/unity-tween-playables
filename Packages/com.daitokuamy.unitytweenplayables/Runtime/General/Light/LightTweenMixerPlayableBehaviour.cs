using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// LightをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class LightTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Light, LightTweenPlayableBehaviour> {
        private ColorValueMixer _colorMixer = new();
        private FloatValueMixer _intensityMixer = new();
        private FloatValueMixer _shadowStrengthMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Light component, LightTweenPlayableBehaviour lastBehaviour) {
            if (_colorMixer.IsValid) {
                component.color = _colorMixer.Value.Mask(component.color, ~(int)lastBehaviour.color.ignoreMasks);
                _colorMixer.Clear();
            }

            if (_intensityMixer.IsValid) {
                component.intensity = _intensityMixer.Value;
                _intensityMixer.Clear();
            }

            if (_shadowStrengthMixer.IsValid) {
                component.shadowStrength = _shadowStrengthMixer.Value;
                _shadowStrengthMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Light component, LightTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_colorMixer, behaviour.color, behaviour, weight, progress);
            BlendValueMixer(_intensityMixer, behaviour.intensity, behaviour, weight, progress);
            BlendValueMixer(_shadowStrengthMixer, behaviour.shadowStrength, behaviour, weight, progress);
        }
    }
}