using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TransformをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Transform))]
    [TrackClipType(typeof(TransformTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/General/Transform Track")]
    public class TransformTweenPlayableTrack : TweenPlayableTrack<Transform, TransformTweenMixerPlayableBehaviour, TransformTweenPlayableBehaviour> {}
}