using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// HorizontalLayoutGroupをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class HorizontalLayoutGroupTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<HorizontalLayoutGroup, HorizontalLayoutGroupTweenPlayableTrack, HorizontalLayoutGroupTweenPlayableBehaviour> {
        private RectOffsetValueMixer _paddingMixer = new();
        private FloatValueMixer _spacingMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(HorizontalLayoutGroup component, HorizontalLayoutGroupTweenPlayableBehaviour lastBehaviour) {
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
        protected override void Blend(HorizontalLayoutGroup component, HorizontalLayoutGroupTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_paddingMixer, behaviour.padding, behaviour, weight, progress);
            BlendValueMixer(_spacingMixer, behaviour.spacing, behaviour, weight, progress);
        }
    }
}