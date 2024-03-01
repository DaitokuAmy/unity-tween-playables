using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VolumeをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Volume))]
    [TrackClipType(typeof(VolumeTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/General/Volume Track")]
    public class VolumeTweenPlayableTrack : TweenPlayableTrack<Volume, VolumeTweenMixerPlayableBehaviour, VolumeTweenPlayableBehaviour> {}
}