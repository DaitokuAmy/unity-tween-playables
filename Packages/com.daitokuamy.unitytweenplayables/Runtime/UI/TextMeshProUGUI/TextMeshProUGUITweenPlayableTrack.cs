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
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/TextMeshProUGUI Track")]
    public class TextMeshProUGUITweenPlayableTrack : TweenPlayableTrack<TextMeshProUGUI, TextMeshProUGUITweenMixerPlayableBehaviour, TextMeshProUGUITweenPlayableBehaviour> {}
}