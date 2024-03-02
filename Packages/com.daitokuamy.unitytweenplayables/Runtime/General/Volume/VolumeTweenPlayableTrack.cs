using System.ComponentModel;
using UnityEngine.Rendering;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VolumeをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Volume))]
    [TrackClipType(typeof(VolumeTweenPlayableClip))]
    [TrackColor(Constant.TrackColorGeneralRed, Constant.TrackColorGeneralGreen, Constant.TrackColorGeneralBlue)]
    [DisplayName("Unity Tween Playables/General/Volume Track")]
    public class VolumeTweenPlayableTrack : TweenPlayableTrack<Volume, VolumeTweenMixerPlayableBehaviour> {}
}