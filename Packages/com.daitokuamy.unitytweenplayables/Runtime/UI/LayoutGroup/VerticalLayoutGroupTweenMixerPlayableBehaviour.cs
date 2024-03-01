using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VerticalLayoutGroupをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class VerticalLayoutGroupTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<VerticalLayoutGroup, VerticalLayoutGroupTweenPlayableBehaviour> {
        private RectOffsetValueMixer _paddingMixer = new();
        private FloatValueMixer _spacingMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(VerticalLayoutGroup component, VerticalLayoutGroupTweenPlayableBehaviour lastBehaviour) {
            if (_paddingMixer.IsValid) {
                component.padding = _paddingMixer.Value.Mask(component.padding, ~(int)lastBehaviour.padding.ignoreMasks);
                _paddingMixer.Clear();
            }

            if (_spacingMixer.IsValid) {
                component.spacing = _spacingMixer.Value;
                _spacingMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(VerticalLayoutGroup component, VerticalLayoutGroupTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_paddingMixer, behaviour.padding, behaviour, weight, progress);
            BlendValueMixer(_spacingMixer, behaviour.spacing, behaviour, weight, progress);
        }
    }
}