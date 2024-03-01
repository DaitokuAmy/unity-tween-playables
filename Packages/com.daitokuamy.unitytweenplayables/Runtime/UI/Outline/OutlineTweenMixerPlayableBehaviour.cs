using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// OutlineをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class OutlineTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Outline, OutlineTweenPlayableBehaviour> {
        private ColorValueMixer _colorMixer = new();
        private Vector2ValueMixer _distanceMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Outline component, OutlineTweenPlayableBehaviour lastBehaviour) {
            if (_colorMixer.IsValid) {
                component.effectColor = _colorMixer.Value.Mask(component.effectColor, (int)~lastBehaviour.color.ignoreMasks);
                _colorMixer.Clear();
            }

            if (_distanceMixer.IsValid) {
                component.effectDistance = _distanceMixer.Value.Mask(component.effectDistance, (int)~lastBehaviour.distance.ignoreMasks);
                _distanceMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Outline component, OutlineTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_colorMixer, behaviour.color, component, weight, progress);
            BlendValueMixer(_distanceMixer, behaviour.distance, component, weight, progress);
        }
    }
}