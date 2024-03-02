using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// PlayableBehaviourの共通インターフェース
    /// </summary>
    public interface ITweenMixerPlayableBehaviour {
        /// <summary>
        /// 初期化処理
        /// </summary>
        void Initialize(TrackAsset trackAsset);
    }
    
    /// <summary>
    /// TweenPlayable用のMixerPlayableBehaviour基底
    /// </summary>
    public abstract class TweenMixerPlayableBehaviour<TBinding, TTrack, TBehaviour> : PlayableBehaviour, ITweenMixerPlayableBehaviour
        where TBinding : Component
        where TTrack : TrackAsset
        where TBehaviour : TweenPlayableBehaviour<TBinding, TTrack>, new() {
        private TBinding _targetComponent;
        private List<ScriptPlayable<TBehaviour>> _playables = new();
        
        /// <summary>Trackへの参照</summary>
        public TTrack Track { get; private set; }

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
                    }

                    // Behaviourの初期化
                    for (var i = 0; i < _playables.Count; i++) {
                        _playables[i].GetBehaviour().Setup(_targetComponent);
                    }
                }
                else {
                    // 想定するplayerDataではない場合はスキップ
                    return;
                }
            }

            var activeInputCount = 0;
            var lastBehaviour = default(TBehaviour);
            var lastActiveBehaviour = default(TBehaviour);
            
            // ブレンドに必要なパラメータ計算
            for (var i = 0; i < inputCount; i++) {
                var input = (ScriptPlayable<TBehaviour>)playable.GetInput(i);
                var behaviour = input.GetBehaviour();
                var inputWeight = playable.GetInputWeight(i);
                var progress = (float)(input.GetTime() / behaviour.GetClipDuration());

                if (inputWeight == 0.0f) {
                    continue;
                }

                lastActiveBehaviour = behaviour;
                Blend(_targetComponent, behaviour, inputWeight, progress);
                activeInputCount++;
            }

            // 値の反映
            if (lastActiveBehaviour != null) {
                Apply(_targetComponent, lastActiveBehaviour);
            }
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
        /// <param name="lastBehaviour">最後に評価された振る舞いクラス</param>
        protected abstract void Apply(TBinding component, TBehaviour lastBehaviour);

        /// <summary>
        /// 初期化処理
        /// </summary>
        void ITweenMixerPlayableBehaviour.Initialize(TrackAsset track) {
            Track = track as TTrack;
        }

        /// <summary>
        /// ValueMixerへのブレンド反映
        /// </summary>
        protected static void BlendValueMixer<T>(ValueMixer<T> mixer, TweenParameter<T> tweenParameter, object component, float weight, float progress) {
            if (!tweenParameter.active) {
                return;
            }
            
            mixer.Blend(tweenParameter.Evaluate(component, progress), weight);
        }
    }
}