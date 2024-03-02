using System.ComponentModel;
using UnityEngine.Timeline;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのVectorをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackClipType(typeof(RendererVectorTweenPlayableClip))]
    [DisplayName("Unity Tween Playables/General/Renderer/Vector Track")]
    public class RendererVectorTweenPlayableTrack : RendererTweenPlayableTrack<RendererVectorTweenMixerPlayableBehaviour> {
    }
}