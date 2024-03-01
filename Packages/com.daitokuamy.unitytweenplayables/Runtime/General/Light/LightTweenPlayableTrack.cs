using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// LightをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Light))]
    [TrackClipType(typeof(LightTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/Light Track")]
    public class LightTweenPlayableTrack : TweenPlayableTrack<Light, LightTweenMixerPlayableBehaviour, LightTweenPlayableBehaviour> {}
}