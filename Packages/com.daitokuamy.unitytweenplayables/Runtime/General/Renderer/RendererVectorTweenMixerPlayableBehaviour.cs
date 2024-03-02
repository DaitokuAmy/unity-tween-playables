using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのVectorをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererVectorTweenMixerPlayableBehaviour : RendererTweenMixerPlayableBehaviour<RendererVectorTweenPlayableTrack, RendererVectorTweenPlayableBehaviour> {
        private Vector4ValueMixer _valueMixer = new();
        
        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Renderer component, RendererVectorTweenPlayableBehaviour lastBehaviour) {
            if (_valueMixer.IsValid) {
                var targetMaterial = FindTargetMaterial(component);
                if (targetMaterial != null) {
                    targetMaterial.SetVector(PropertyId, _valueMixer.Value);
                }

                _valueMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(Renderer component, RendererVectorTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_valueMixer, behaviour.value, behaviour, weight, progress);
        }
    }
}