using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VerticalLayoutGroupをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(VerticalLayoutGroup))]
    [TrackClipType(typeof(VerticalLayoutGroupTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/LayoutGroup/VerticalLayoutGroup Track")]
    public class VerticalLayoutGroupTweenPlayableTrack : TweenPlayableTrack<VerticalLayoutGroup, VerticalLayoutGroupTweenMixerPlayableBehaviour, VerticalLayoutGroupTweenPlayableBehaviour> {}
}