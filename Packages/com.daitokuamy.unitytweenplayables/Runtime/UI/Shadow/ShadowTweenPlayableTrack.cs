using System.ComponentModel;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// ShadowをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Shadow))]
    [TrackClipType(typeof(ShadowTweenPlayableClip))]
    [TrackColor(Constant.TrackColorUIRed, Constant.TrackColorUIGreen, Constant.TrackColorUIBlue)]
    [DisplayName("Unity Tween Playables/UI/Shadow Track")]
    public class ShadowTweenPlayableTrack : TweenPlayableTrack<Shadow, ShadowTweenMixerPlayableBehaviour, ShadowTweenPlayableBehaviour> {}
}