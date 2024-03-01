using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// HorizontalLayoutGroupをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(HorizontalLayoutGroup))]
    [TrackClipType(typeof(HorizontalLayoutGroupTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/LayoutGroup/HorizontalLayoutGroup Track")]
    public class HorizontalLayoutGroupTweenPlayableTrack : TweenPlayableTrack<HorizontalLayoutGroup, HorizontalLayoutGroupTweenMixerPlayableBehaviour, HorizontalLayoutGroupTweenPlayableBehaviour> {}
}