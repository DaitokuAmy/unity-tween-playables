using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VerticalLayoutGroupをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(VerticalLayoutGroup))]
    [TrackClipType(typeof(VerticalLayoutGroupTweenPlayableClip))]
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/LayoutGroup/VerticalLayoutGroup Track")]
    public class VerticalLayoutGroupTweenPlayableTrack : TweenPlayableTrack<VerticalLayoutGroup, VerticalLayoutGroupTweenMixerPlayableBehaviour, VerticalLayoutGroupTweenPlayableBehaviour> {}
}