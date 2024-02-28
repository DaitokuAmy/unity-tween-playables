using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// TweenPlayable用のMixerPlayableBehaviour基底
    /// </summary>
    public abstract class TweenMixerPlayableBehaviour<TBinding, TBehaviour> : PlayableBehaviour
        where TBinding : Component
        where TBehaviour : TweenPlayableBehaviour<TBinding>, new() {
        private TBinding _targetComponent;
        private List<ScriptPlayable<TBehaviour>> _playables = new();

        /// <summary>
        /// Playable廃棄時処理
        /// </summary>
        public override void OnPlayableDestroy(Playable playable) {
            _playables.Clear();
            _targetComponent = null;
            base.OnPlayableDestroy(playable);
        }

        /// <summary>
        /// フレーム解釈
        /// </summary>
        public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
            base.ProcessFrame(playable, info, playerData);

            var inputCount = playable.GetInputCount();

            if (_targetComponent == null) {
                if (playerData is TBinding target) {
                    _targetComponent = target;

                    for (var i = 0; i < inputCount; i++) {
                        var input = (ScriptPlayable<TBehaviour>)playable.GetInput(i);
                        _playables.Add(input);

                        // Behaviourの初期化
                        input.GetBehaviour().Setup(_targetComponent);
                    }
                }
                else {
                    // 想定するplayerDataではない場合はスキップ
                    return;
                }
            }

            var activeInputCount = 0;
            var lastBehaviour = default(TBehaviour);
            
            // ブレンドに必要なパラメータ計算
            for (var i = 0; i < inputCount; i++) {
                var input = (ScriptPlayable<TBehaviour>)playable.GetInput(i);
                var behaviour = input.GetBehaviour();
                var inputWeight = playable.GetInputWeight(i);
                var progress = (float)(input.GetTime() / behaviour.GetClipDuration());

                if (inputWeight == 0.0f) {
                    if (input.GetPlayState() == PlayState.Paused && progress > 0.0f) {
                        lastBehaviour = behaviour;
                    }

                    continue;
                }

                Blend(_targetComponent, behaviour, inputWeight, progress);
                activeInputCount++;
            }

            // WeightがあるInputがない場合は、最後のBehaviourの値を適用
            if (activeInputCount == 0) {
                if (lastBehaviour != null) {
                    Blend(_targetComponent, lastBehaviour, 1, 1);
                }
            }

            Apply(_targetComponent);
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        /// <param name="component">変更対象のComponent</param>
        /// <param name="behaviour">振る舞いクラス</param>
        /// <param name="weight">ブレンド率</param>
        /// <param name="progress">進捗</param>
        protected abstract void Blend(TBinding component, TBehaviour behaviour, float weight, float progress);
        
        /// <summary>
        /// 値の反映
        /// </summary>
        /// <param name="component">変更対象のComponent</param>
        protected abstract void Apply(TBinding component);
    }
}