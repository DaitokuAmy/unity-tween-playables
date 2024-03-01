using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// ImageをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Image))]
    [TrackClipType(typeof(ImageTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/Image Track")]
    public class ImageTweenPlayableTrack : TweenPlayableTrack<Image, ImageTweenMixerPlayableBehaviour, ImageTweenPlayableBehaviour> {}
}