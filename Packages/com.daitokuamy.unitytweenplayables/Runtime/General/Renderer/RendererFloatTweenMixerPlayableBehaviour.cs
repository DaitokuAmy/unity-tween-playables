using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのFloatをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererFloatTweenMixerPlayableBehaviour : RendererTweenMixerPlayableBehaviour<RendererFloatTweenPlayableTrack, RendererFloatTweenPlayableBehaviour> {
        private FloatValueMixer _valueMixer = new();
        
        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Renderer component, RendererFloatTweenPlayableBehaviour lastBehaviour) {
            if (_valueMixer.IsValid) {
                var targetMaterial = FindTargetMaterial(component);
                if (targetMaterial != null) {
                    targetMaterial.SetFloat(PropertyId, _valueMixer.Value);
                }

                _valueMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Renderer component, RendererFloatTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_valueMixer, behaviour.value, behaviour, weight, progress);
        }
    }
}