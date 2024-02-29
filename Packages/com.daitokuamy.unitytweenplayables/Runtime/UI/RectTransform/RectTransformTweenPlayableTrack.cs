using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// RectTransformをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(RectTransform))]
    [TrackClipType(typeof(RectTransformTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/RectTransform Track")]
    public class RectTransformTweenPlayableTrack : TweenPlayableTrack<RectTransform, RectTransformTweenMixerPlayableBehaviour, RectTransformTweenPlayableBehaviour> {}
}