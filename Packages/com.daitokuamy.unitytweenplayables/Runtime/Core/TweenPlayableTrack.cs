using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// TweenPlayable用のTrackAsset基底
    /// </summary>
    public abstract class TweenPlayableTrack<TBinding, TMixerBehaviour, TBehaviour> : TrackAsset
        where TBinding : Component
        where TMixerBehaviour : TweenMixerPlayableBehaviour<TBinding, TBehaviour>, new()
        where TBehaviour : TweenPlayableBehaviour<TBinding> {
        /// <summary>
        /// Mixerの生成
        /// </summary>
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
            return ScriptPlayable<TMixerBehaviour>.Create(graph, inputCount);
        }

        /// <summary>
        /// プレビュー用プロパティの集約
        /// </summary>
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver) {
            base.GatherProperties(director, driver);
            
#if UNITY_EDITOR
            var component = director.GetGenericBinding(this) as TBinding;
            if (component == null) {
                return;
            }

            var serializedObj = new SerializedObject(component);
            var itr = serializedObj.GetIterator();
            while (itr.NextVisible(true)) {
                if (itr.hasVisibleChildren) {
                    continue;
                }

                driver.AddFromName<TBinding>(component.gameObject, itr.propertyPath);
            }
#endif
        }
    }
}