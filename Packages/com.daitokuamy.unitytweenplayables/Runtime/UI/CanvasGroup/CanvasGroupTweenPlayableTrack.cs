using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// CanvasGroupをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(CanvasGroup))]
    [TrackClipType(typeof(CanvasGroupTweenPlayableClip))]
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/CanvasGroup Track")]
    public class CanvasGroupTweenPlayableTrack : TweenPlayableTrack<CanvasGroup, CanvasGroupTweenMixerPlayableBehaviour, CanvasGroupTweenPlayableBehaviour> {}
}