using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// SpriteRendererをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(SpriteRenderer))]
    [TrackClipType(typeof(SpriteRendererTweenPlayableClip))]
    [TrackColor(Constant.TrackColor2DRed, Constant.TrackColor2DGreen, Constant.TrackColor2DBlue)]
    [DisplayName("Unity Tween Playables/General/SpriteRenderer Track")]
    public class SpriteRendererTweenPlayableTrack : TweenPlayableTrack<SpriteRenderer, SpriteRendererTweenMixerPlayableBehaviour, SpriteRendererTweenPlayableBehaviour> {}
}