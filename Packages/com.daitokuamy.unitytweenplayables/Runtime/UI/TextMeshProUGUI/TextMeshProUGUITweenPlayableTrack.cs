using System.ComponentModel;
using TMPro;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TextMeshProUGUIをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(TextMeshProUGUI))]
    [TrackClipType(typeof(TextMeshProUGUITweenPlayableClip))]
    [TrackColor(Constant.TrackColorTextRed, Constant.TrackColorTextGreen, Constant.TrackColorTextBlue)]
    [DisplayName("Unity Tween Playables/UI/TextMeshProUGUI Track")]
    public class TextMeshProUGUITweenPlayableTrack : TweenPlayableTrack<TextMeshProUGUI, TextMeshProUGUITweenMixerPlayableBehaviour, TextMeshProUGUITweenPlayableBehaviour> {}
}