using System.ComponentModel;
using UnityEngine.Timeline;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// Rendererの汎用パラメータをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackClipType(typeof(RendererStandardTweenPlayableClip))]
    [DisplayName("Unity Tween Playables/General/Renderer/Standard Track")]
    public class RendererStandardTweenPlayableTrack : RendererTweenPlayableTrack<RendererStandardTweenMixerPlayableBehaviour> {
        /// <summary>Clip表示名</summary>
        public override string ClipDisplayName => "[Standard]";
    }
}