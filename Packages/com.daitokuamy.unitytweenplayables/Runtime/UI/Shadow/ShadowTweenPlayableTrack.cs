using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// ShadowをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Shadow))]
    [TrackClipType(typeof(ShadowTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/Shadow Track")]
    public class ShadowTweenPlayableTrack : TweenPlayableTrack<Shadow, ShadowTweenMixerPlayableBehaviour, ShadowTweenPlayableBehaviour> {}
}