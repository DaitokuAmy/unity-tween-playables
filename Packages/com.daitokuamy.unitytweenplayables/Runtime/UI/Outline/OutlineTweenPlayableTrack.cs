using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// OutlineをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Outline))]
    [TrackClipType(typeof(OutlineTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/Outline Track")]
    public class OutlineTweenPlayableTrack : TweenPlayableTrack<Outline, OutlineTweenMixerPlayableBehaviour, OutlineTweenPlayableBehaviour> {}
}