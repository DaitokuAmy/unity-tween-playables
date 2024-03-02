using System.ComponentModel;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// HorizontalLayoutGroupをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(HorizontalLayoutGroup))]
    [TrackClipType(typeof(HorizontalLayoutGroupTweenPlayableClip))]
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/LayoutGroup/HorizontalLayoutGroup Track")]
    public class HorizontalLayoutGroupTweenPlayableTrack : TweenPlayableTrack<HorizontalLayoutGroup, HorizontalLayoutGroupTweenMixerPlayableBehaviour> {}
}