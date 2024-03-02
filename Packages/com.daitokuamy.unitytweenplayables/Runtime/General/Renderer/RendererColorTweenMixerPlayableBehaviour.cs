using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのColorをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererColorTweenMixerPlayableBehaviour : RendererTweenMixerPlayableBehaviour<RendererColorTweenPlayableTrack, RendererColorTweenPlayableBehaviour> {
        private ColorValueMixer _valueMixer = new();
        
        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Renderer component, RendererColorTweenPlayableBehaviour lastBehaviour) {
            if (_valueMixer.IsValid) {
                var targetMaterial = FindTargetMaterial(component);
                if (targetMaterial != null) {
                    targetMaterial.SetColor(PropertyId, _valueMixer.Value);
                }

                _valueMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Renderer component, RendererColorTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_valueMixer, behaviour.value, behaviour, weight, progress);
        }
    }
}