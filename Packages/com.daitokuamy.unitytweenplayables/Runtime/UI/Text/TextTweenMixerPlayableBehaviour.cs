using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TextをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class TextTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Text, TextTweenPlayableBehaviour> {
        private ColorValueMixer _colorMixer = new();
        private FloatValueMixer _fontSizeMixer = new();
        private FloatValueMixer _lineSpacingMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Text component, TextTweenPlayableBehaviour lastBehaviour) {
            if (_colorMixer.IsValid) {
                component.color = _colorMixer.Value.Mask(component.color, (int)~lastBehaviour.color.ignoreMasks);
                _colorMixer.Clear();
            }

            if (_fontSizeMixer.IsValid) {
                component.fontSize = (int)_fontSizeMixer.Value;
                _fontSizeMixer.Clear();
            }

            if (_lineSpacingMixer.IsValid) {
                component.lineSpacing = _lineSpacingMixer.Value;
                _lineSpacingMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Text component, TextTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_colorMixer, behaviour.color, component, weight, progress);
            BlendValueMixer(_fontSizeMixer, behaviour.fontSize, component, weight, progress);
            BlendValueMixer(_lineSpacingMixer, behaviour.lineSpacing, component, weight, progress);
        }
    }
}