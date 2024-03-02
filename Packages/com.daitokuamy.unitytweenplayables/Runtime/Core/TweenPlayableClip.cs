using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// TweenPlayableClipの共通インターフェース
    /// </summary>
    public interface ITweenPlayableClip {
        /// <summary>表示名</summary>
        string DisplayName { get; }
        
        /// <summary>
        /// Clipの長さを設定
        /// </summary>
        void SetDuration(double duration);

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

        private double _duration;

        /// <summary>TimelineClipのサポート機能属性</summary>
        public virtual ClipCaps clipCaps => ClipCaps.Blending | ClipCaps.Extrapolation;

        /// <summary>表示名</summary>
        public virtual string DisplayName => GetType().Name.Replace("TweenPlayableClip", "");

        /// <summary>
        /// Playableの生成
        /// </summary>
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            var playable = ScriptPlayable<TBehaviour>.Create(graph, _behaviour);
            playable.GetBehaviour().Initialize(this);
            return playable;
        }

        /// <summary>
        /// Clipの長さを設定
        /// </summary>
        void ITweenPlayableClip.SetDuration(double duration) {
            _duration = duration;
        }

        /// <summary>
        /// Clipの長さを取得
        /// </summary>
        double ITweenPlayableClip.GetDuration() {
            return _duration;
        }
    }
}