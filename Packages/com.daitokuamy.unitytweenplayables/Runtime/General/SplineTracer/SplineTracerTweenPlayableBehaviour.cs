using System;
using UnityTweenPlayables.Components;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// TransformをSplineを使って動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class SplineTracerTweenPlayableBehaviour : TweenPlayableBehaviour<SplineTracer, SplineTracerTweenPlayableTrack> {
        public ProgressTweenParameter progress;
        public int splineIndex;
        public int startKnotIndex = -1;
        public int endKnotIndex = -1;
        public bool reverse;
    }
}