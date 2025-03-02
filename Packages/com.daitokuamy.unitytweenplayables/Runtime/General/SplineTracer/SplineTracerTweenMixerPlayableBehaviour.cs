using System;
using UnityEngine;
using UnityTweenPlayables.Components;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// SplineTracerをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class SplineTracerTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<SplineTracer, SplineTracerTweenPlayableTrack, SplineTracerTweenPlayableBehaviour> {
        private float _progress;
        
        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(SplineTracer component, SplineTracerTweenPlayableBehaviour lastBehaviour) {
            component.Evaluate(lastBehaviour.splineIndex, _progress, lastBehaviour.startKnotIndex, lastBehaviour.endKnotIndex);
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(SplineTracer component, SplineTracerTweenPlayableBehaviour behaviour, float weight, float progress) {
            if (behaviour.progress.active) {
                _progress = behaviour.progress.Evaluate(component, progress);
            }
            else {
                _progress = progress;
            }

            if (behaviour.reverse) {
                _progress = Mathf.Clamp01(1.0f - _progress);
            }
        }
    }
}