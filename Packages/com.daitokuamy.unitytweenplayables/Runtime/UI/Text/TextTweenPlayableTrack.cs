using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TextをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Text))]
    [TrackClipType(typeof(TextTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/Text Track")]
    public class TextTweenPlayableTrack : TweenPlayableTrack<Text, TextTweenMixerPlayableBehaviour, TextTweenPlayableBehaviour> {}
}