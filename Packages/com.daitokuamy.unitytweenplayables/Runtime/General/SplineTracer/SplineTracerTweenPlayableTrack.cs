using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// SplineTracerをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(SplineTracer))]
    [TrackClipType(typeof(SplineTracerTweenPlayableClip))]
    [TrackColor(Constant.TrackColorGeneralRed, Constant.TrackColorGeneralGreen, Constant.TrackColorGeneralBlue)]
    [DisplayName("Unity Tween Playables/General/SplineTracer Track")]
    public class SplineTracerTweenPlayableTrack : TweenPlayableTrack<SplineTracer, SplineTracerTweenMixerPlayableBehaviour> {}
}