using System.ComponentModel;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// RectMask2DをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(RectMask2D))]
    [TrackClipType(typeof(RectMask2DTweenPlayableClip))]
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/RectMask2D Track")]
    public class RectMask2DTweenPlayableTrack : TweenPlayableTrack<RectMask2D, RectMask2DTweenMixerPlayableBehaviour> {}
}