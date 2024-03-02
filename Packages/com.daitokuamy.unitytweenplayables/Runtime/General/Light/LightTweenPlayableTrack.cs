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
    [TrackColor(Constant.TrackColorGeneralRed, Constant.TrackColorGeneralGreen, Constant.TrackColorGeneralBlue)]
    [DisplayName("Unity Tween Playables/General/Light Track")]
    public class LightTweenPlayableTrack : TweenPlayableTrack<Light, LightTweenMixerPlayableBehaviour, LightTweenPlayableBehaviour> {}
}