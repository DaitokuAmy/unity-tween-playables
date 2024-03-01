using System;
using UnityEngine;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// GraphicをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class GraphicTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Graphic, GraphicTweenPlayableBehaviour> {
        private ColorValueMixer _colorMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Graphic component, GraphicTweenPlayableBehaviour lastBehaviour) {
            if (_colorMixer.IsValid) {
                component.color = _colorMixer.Value.Mask(component.color, (int)~lastBehaviour.color.ignoreMasks);
                _colorMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Graphic component, GraphicTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_colorMixer, behaviour.color, component, weight, progress);
        }
    }
}