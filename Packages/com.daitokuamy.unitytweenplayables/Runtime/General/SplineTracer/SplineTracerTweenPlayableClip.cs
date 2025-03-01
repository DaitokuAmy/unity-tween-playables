using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// SplineTracerをTweenで動かすためのPlayableClip
    /// </summary>
    public class SplineTracerTweenPlayableClip : TweenPlayableClip<SplineTracerTweenPlayableBehaviour> {
        /// <summary>TimelineClipのサポート機能属性</summary>
        public override ClipCaps clipCaps => ClipCaps.Extrapolation;
    }
}