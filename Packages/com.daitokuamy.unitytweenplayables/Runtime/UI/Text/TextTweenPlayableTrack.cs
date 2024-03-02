using System.ComponentModel;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TextをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Text))]
    [TrackClipType(typeof(TextTweenPlayableClip))]
    [TrackColor(Constant.TrackColorTextRed, Constant.TrackColorTextGreen, Constant.TrackColorTextBlue)]
    [DisplayName("Unity Tween Playables/UI/Text Track")]
    public class TextTweenPlayableTrack : TweenPlayableTrack<Text, TextTweenMixerPlayableBehaviour> {}
}