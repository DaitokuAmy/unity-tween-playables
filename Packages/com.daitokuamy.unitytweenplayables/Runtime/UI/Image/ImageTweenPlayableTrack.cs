using System.ComponentModel;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// ImageをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Image))]
    [TrackClipType(typeof(ImageTweenPlayableClip))]
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/Image Track")]
    public class ImageTweenPlayableTrack : TweenPlayableTrack<Image, ImageTweenMixerPlayableBehaviour, ImageTweenPlayableBehaviour> {}
}