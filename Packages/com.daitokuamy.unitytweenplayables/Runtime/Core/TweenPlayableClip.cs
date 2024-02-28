using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// TweenPlayableClipの共通インターフェース
    /// </summary>
    public interface ITweenPlayableClip {
        /// <summary>
        /// Clipの長さを取得
        /// </summary>
        double GetDuration();
    }
    
    /// <summary>
    /// TweenPlayable用のPlayableAsset基底
    /// </summary>
    public abstract class TweenPlayableClip<TBehaviour> : PlayableAsset, ITimelineClipAsset, ITweenPlayableClip
        where TBehaviour : PlayableBehaviour, ITweenPlayableBehaviour, new() {
        [SerializeField, Tooltip("振る舞い指定用のComponent")]
        private TBehaviour _behaviour = new();

        /// <summary>TimelineClipのサポート機能属性</summary>
        ClipCaps ITimelineClipAsset.clipCaps => ClipCaps.Blending | ClipCaps.Extrapolation;

        /// <summary>
        /// Playableの生成
        /// </summary>
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            var playable = ScriptPlayable<TBehaviour>.Create(graph, _behaviour);
            playable.GetBehaviour().Initialize(this);
            return playable;
        }

        /// <summary>
        /// Clipの長さを取得
        /// </summary>
        double ITweenPlayableClip.GetDuration() {
            return duration;
        }
    }
}