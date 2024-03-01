using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// SliderをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Slider))]
    [TrackClipType(typeof(SliderTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/Slider Track")]
    public class SliderTweenPlayableTrack : TweenPlayableTrack<Slider, SliderTweenMixerPlayableBehaviour, SliderTweenPlayableBehaviour> {}
}