using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// RectMask2DをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RectMask2DTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<RectMask2D, RectMask2DTweenPlayableBehaviour> {
        private Vector4ValueMixer _paddingMixer = new();
        private Vector2ValueMixer _softnessMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(RectMask2D component, RectMask2DTweenPlayableBehaviour lastBehaviour) {
            if (_paddingMixer.IsValid) {
                component.padding = _paddingMixer.Value;
                _paddingMixer.Clear();
            }
            
            if (_softnessMixer.IsValid) {
                var softness = _softnessMixer.Value.Mask(component.softness, (int)~lastBehaviour.softness.ignoreMasks);
                component.softness = new Vector2Int((int)softness.x, (int)softness.y);
                _softnessMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(RectMask2D component, RectMask2DTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_paddingMixer, behaviour.padding, component, weight, progress);
            BlendValueMixer(_softnessMixer, behaviour.softness, component, weight, progress);
        }
    }
}