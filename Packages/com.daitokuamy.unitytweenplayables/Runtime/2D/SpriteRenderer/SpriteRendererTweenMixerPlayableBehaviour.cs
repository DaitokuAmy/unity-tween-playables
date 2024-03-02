using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// SpriteRendererをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class SpriteRendererTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<SpriteRenderer, SpriteRendererTweenPlayableTrack, SpriteRendererTweenPlayableBehaviour> {
        private ColorValueMixer _colorMixer = new();
        private Vector2ValueMixer _sizeMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(SpriteRenderer component, SpriteRendererTweenPlayableBehaviour lastBehaviour) {
            if (_colorMixer.IsValid) {
                component.color = _colorMixer.Value.Mask(component.color, (int)~lastBehaviour.color.ignoreMasks);
                _colorMixer.Clear();
            }
            if (_sizeMixer.IsValid) {
                component.size = _sizeMixer.Value.Mask(component.size, (int)~lastBehaviour.size.ignoreMasks);
                _sizeMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(SpriteRenderer component, SpriteRendererTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_colorMixer, behaviour.color, behaviour, weight, progress);
            BlendValueMixer(_sizeMixer, behaviour.size, behaviour, weight, progress);
        }
    }
}