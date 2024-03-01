using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VolumeをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class VolumeTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Volume, VolumeTweenPlayableBehaviour> {
        private FloatValueMixer _weightMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Volume component, VolumeTweenPlayableBehaviour lastBehaviour) {
            if (_weightMixer.IsValid) {
                component.weight = _weightMixer.Value;
                _weightMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Volume component, VolumeTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_weightMixer, behaviour.weight, behaviour, weight, progress);
        }
    }
}