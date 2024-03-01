using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// ImageをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class ImageTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Image, ImageTweenPlayableBehaviour> {
        private ColorValueMixer _colorMixer = new();
        private FloatValueMixer _fillAmountMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Image component, ImageTweenPlayableBehaviour lastBehaviour) {
            if (_colorMixer.IsValid) {
                component.color = _colorMixer.Value.Mask(component.color, (int)~lastBehaviour.color.ignoreMasks);
                _colorMixer.Clear();
            }

            if (_fillAmountMixer.IsValid) {
                component.fillAmount = _fillAmountMixer.Value;
                _fillAmountMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Image component, ImageTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_colorMixer, behaviour.color, component, weight, progress);
            BlendValueMixer(_fillAmountMixer, behaviour.fillAmount, component, weight, progress);
        }
    }
}