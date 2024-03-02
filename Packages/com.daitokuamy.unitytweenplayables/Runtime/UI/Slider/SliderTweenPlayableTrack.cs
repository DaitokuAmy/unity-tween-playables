using System.ComponentModel;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// SliderをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Slider))]
    [TrackClipType(typeof(SliderTweenPlayableClip))]
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/Slider Track")]
    public class SliderTweenPlayableTrack : TweenPlayableTrack<Slider, SliderTweenMixerPlayableBehaviour> {}
}