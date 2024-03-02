using System.ComponentModel;
using UnityEngine.Timeline;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのColorをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackClipType(typeof(RendererColorTweenPlayableClip))]
    [DisplayName("Unity Tween Playables/General/Renderer/Color Track")]
    public class RendererColorTweenPlayableTrack : RendererTweenPlayableTrack<RendererColorTweenMixerPlayableBehaviour> {
    }
}