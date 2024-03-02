using System.ComponentModel;
using UnityEngine.Timeline;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのFloatをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackClipType(typeof(RendererFloatTweenPlayableClip))]
    [DisplayName("Unity Tween Playables/General/Renderer/Float Track")]
    public class RendererFloatTweenPlayableTrack : RendererTweenPlayableTrack<RendererFloatTweenMixerPlayableBehaviour> {
    }
}