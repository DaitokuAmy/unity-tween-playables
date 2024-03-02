using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererTweenPlayableTrack用の制御インターフェース
    /// </summary>
    public interface IRendererTweenPlayableTrack {
        /// <summary>操作対象のMaterialIndex</summary>
        int MaterialIndex { get; }
        /// <summary>プロパティ名</summary>
        string PropertyName { get; }
    }
    
    /// <summary>
    /// RendererをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(Renderer))]
    [TrackColor(Constant.TrackColorGeneralRed, Constant.TrackColorGeneralGreen, Constant.TrackColorGeneralBlue)]
    public abstract class RendererTweenPlayableTrack<TMixerBehaviour> : TweenPlayableTrack<Renderer, TMixerBehaviour>, IRendererTweenPlayableTrack
        where TMixerBehaviour : PlayableBehaviour, ITweenMixerPlayableBehaviour, new() {
        [Tooltip("制御対象のMaterialIndex")]
        public int materialIndex;
        [Tooltip("制御するシェーダープロパティ名")]
        public string propertyName;

        /// <summary>Clip表示名</summary>
        public override string ClipDisplayName => $"[{GetType().Name.Replace("TweenPlayableTrack", "").Replace("Renderer", "")}]{propertyName}";
        
        /// <summary>操作対象のMaterialIndex</summary>
        int IRendererTweenPlayableTrack.MaterialIndex => materialIndex;
        /// <summary>プロパティ名</summary>
        string IRendererTweenPlayableTrack.PropertyName => propertyName;
    }
}