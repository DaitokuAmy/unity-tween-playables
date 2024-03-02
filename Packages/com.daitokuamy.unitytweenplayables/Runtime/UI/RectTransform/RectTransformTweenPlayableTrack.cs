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
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/RectTransform Track")]
    public class RectTransformTweenPlayableTrack : TweenPlayableTrack<RectTransform, RectTransformTweenMixerPlayableBehaviour, RectTransformTweenPlayableBehaviour> {}
}