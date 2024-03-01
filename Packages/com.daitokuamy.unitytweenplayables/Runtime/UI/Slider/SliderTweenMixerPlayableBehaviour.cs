using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// SliderをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class SliderTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Slider, SliderTweenPlayableBehaviour> {
        private FloatValueMixer _valueMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Slider component, SliderTweenPlayableBehaviour lastBehaviour) {
            if (_valueMixer.IsValid) {
                component.value = _valueMixer.Value;
                _valueMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Slider component, SliderTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_valueMixer, behaviour.value, component, weight, progress);
        }
    }
}