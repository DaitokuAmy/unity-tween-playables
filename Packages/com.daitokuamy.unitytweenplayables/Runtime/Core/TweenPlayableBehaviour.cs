using System;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// PlayableBehaviourの共通インターフェース
    /// </summary>
    public interface ITweenPlayableBehaviour {
        /// <summary>
        /// 初期化処理
        /// </summary>
        void Initialize(ITweenPlayableClip ownerClip);
    }
    
    /// <summary>
    /// TweenPlayable用のPlayableBehaviour基底
    /// </summary>
    [Serializable]
    public abstract class TweenPlayableBehaviour<TBinding> : PlayableBehaviour, ITweenPlayableBehaviour
        where TBinding : Component {
        private bool _initialized;
        private ITweenPlayableClip _ownerClip;

        /// <summary>
        /// グラフ停止時の処理
        /// </summary>
        public override void OnGraphStop(Playable playable) {
            _initialized = false;
            base.OnGraphStop(playable);
        }

        /// <summary>
        /// 再生停止状態になった時の処理
        /// </summary>
        public override void OnBehaviourPause(Playable playable, FrameData info) {
            var duration = GetClipDuration();
            var nextTime = playable.GetTime() + info.deltaTime;

            // 停止条件を満たしていたらBehaviourをCleanup
            if ((info.effectivePlayState == PlayState.Paused && nextTime > duration) || playable.GetGraph().GetRootPlayable(0).IsDone()) {
                Cleanup();
            }
            
            base.OnBehaviourPause(playable, info);
        }

        /// <summary>
        /// Behaviourのセットアップ
        /// </summary>
        protected virtual void SetupInternal(TBinding playerData) {}
        
        /// <summary>
        /// Behaviourのクリーンアップ
        /// </summary>
        protected virtual void CleanupInternal() {}

        /// <summary>
        /// 初期化処理
        /// </summary>
        void ITweenPlayableBehaviour.Initialize(ITweenPlayableClip ownerClip) {
            _ownerClip = ownerClip;
        }

        /// <summary>
        /// セットアップ
        /// </summary>
        public void Setup(TBinding playerData) {
            if (playerData == null) {
                return;
            }

            if (_initialized) {
                return;
            }

            _initialized = true;
            SetupInternal(playerData);
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        public void Cleanup() {
            if (!_initialized) {
                return;
            }

            _initialized = false;
            CleanupInternal();
        }

        /// <summary>
        /// ClipのDurationを取得
        /// </summary>
        public double GetClipDuration() {
            return _ownerClip?.GetDuration() ?? 0.0f;
        }
    }
}