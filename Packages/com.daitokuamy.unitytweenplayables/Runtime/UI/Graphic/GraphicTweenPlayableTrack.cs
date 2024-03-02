using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// GraphicをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Graphic))]
    [TrackClipType(typeof(GraphicTweenPlayableClip))]
    [TrackColor(0.3f, 0.8f, 0.3f)]
    [DisplayName("Unity Tween Playables/UI/Graphic Track")]
    public class GraphicTweenPlayableTrack : TweenPlayableTrack<Graphic, GraphicTweenMixerPlayableBehaviour> {}
}