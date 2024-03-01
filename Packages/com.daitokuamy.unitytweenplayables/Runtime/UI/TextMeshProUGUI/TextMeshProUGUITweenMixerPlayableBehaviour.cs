using System;
using TMPro;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TextMeshProUGUIをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class TextMeshProUGUITweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<TextMeshProUGUI, TextMeshProUGUITweenPlayableBehaviour> {
        private ColorValueMixer _colorMixer = new();
        private FloatValueMixer _fontSizeMixer = new();
        private FloatValueMixer _characterSpacingMixer = new();
        private FloatValueMixer _wordSpacingMixer = new();
        private FloatValueMixer _lineSpacingMixer = new();
        private FloatValueMixer _paragraphSpacingMixer = new();
        private VertexGradientValueMixer _colorGradientMixer = new();
        private FloatValueMixer _typewriterProgressMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(TextMeshProUGUI component, TextMeshProUGUITweenPlayableBehaviour lastBehaviour) {
            if (_colorMixer.IsValid) {
                component.color = _colorMixer.Value.Mask(component.color, (int)~lastBehaviour.color.ignoreMasks);
                _colorMixer.Clear();
            }

            if (_fontSizeMixer.IsValid) {
                component.fontSize = (int)_fontSizeMixer.Value;
                _fontSizeMixer.Clear();
            }

            if (_characterSpacingMixer.IsValid) {
                component.characterSpacing = _characterSpacingMixer.Value;
                _characterSpacingMixer.Clear();
            }

            if (_wordSpacingMixer.IsValid) {
                component.wordSpacing = _wordSpacingMixer.Value;
                _wordSpacingMixer.Clear();
            }

            if (_lineSpacingMixer.IsValid) {
                component.lineSpacing = _lineSpacingMixer.Value;
                _lineSpacingMixer.Clear();
            }

            if (_paragraphSpacingMixer.IsValid) {
                component.paragraphSpacing = _paragraphSpacingMixer.Value;
                _paragraphSpacingMixer.Clear();
            }

            if (_colorGradientMixer.IsValid) {
                component.colorGradient = _colorGradientMixer.Value;
                _colorGradientMixer.Clear();
            }

            if (_typewriterProgressMixer.IsValid) {
                component.maxVisibleCharacters = (int)(component.text.Length * _typewriterProgressMixer.Value);
                _typewriterProgressMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(TextMeshProUGUI component, TextMeshProUGUITweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_colorMixer, behaviour.color, component, weight, progress);
            BlendValueMixer(_fontSizeMixer, behaviour.fontSize, component, weight, progress);
            BlendValueMixer(_characterSpacingMixer, behaviour.characterSpacing, component, weight, progress);
            BlendValueMixer(_wordSpacingMixer, behaviour.wordSpacing, component, weight, progress);
            BlendValueMixer(_lineSpacingMixer, behaviour.lineSpacing, component, weight, progress);
            BlendValueMixer(_paragraphSpacingMixer, behaviour.paragraphSpacing, component, weight, progress);
            BlendValueMixer(_typewriterProgressMixer, behaviour.typewriteProgress, component, weight, progress);
        }
    }
}