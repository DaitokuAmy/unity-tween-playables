using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// CanvasGroupをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class CanvasGroupTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<CanvasGroup, CanvasGroupTweenPlayableBehaviour> {
        private FloatValueMixer _alphaMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(CanvasGroup component, CanvasGroupTweenPlayableBehaviour lastBehaviour) {
            if (_alphaMixer.IsValid) {
                component.alpha = _alphaMixer.Value;
                _alphaMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(CanvasGroup component, CanvasGroupTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_alphaMixer, behaviour.alpha, behaviour, weight, progress);
        }
    }
}