using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// TransformをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Transform))]
    [TrackClipType(typeof(TransformTweenPlayableClip))]
    [TrackColor(Constant.TrackColorGeneralRed, Constant.TrackColorGeneralGreen, Constant.TrackColorGeneralBlue)]
    [DisplayName("Unity Tween Playables/General/Transform Track")]
    public class TransformTweenPlayableTrack : TweenPlayableTrack<Transform, TransformTweenMixerPlayableBehaviour> {}
}