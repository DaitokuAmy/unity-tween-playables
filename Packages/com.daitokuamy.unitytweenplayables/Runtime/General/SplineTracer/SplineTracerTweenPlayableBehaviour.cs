using System;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// TransformをSplineを使って動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class SplineTracerTweenPlayableBehaviour : TweenPlayableBehaviour<SplineTracer, SplineTracerTweenPlayableTrack> {
        public ProgressTweenParameter progress;
        public int splineIndex;
        public bool reverse;
    }
}