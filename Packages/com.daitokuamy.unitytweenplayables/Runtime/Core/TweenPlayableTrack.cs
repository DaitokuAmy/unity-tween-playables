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
    public abstract class TweenPlayableTrack<TBinding, TMixerBehaviour> : TrackAsset
        where TBinding : Component
        where TMixerBehaviour : PlayableBehaviour, ITweenMixerPlayableBehaviour, new() {
        /// <summary>Clipの表示名(nullならデフォルト)</summary>
        public virtual string ClipDisplayName => null;
        
        /// <summary>
        /// Mixerの生成
        /// </summary>
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
            foreach (var timelineClip in GetClips()) {
                if (timelineClip.asset is ITweenPlayableClip clip) {
                    clip.Initialize(this);
                    clip.SetDuration(timelineClip.duration);
#if UNITY_EDITOR
                    if (!string.IsNullOrEmpty(clip.DisplayName)) {
                        timelineClip.displayName = clip.DisplayName;
                    }
                    else if (!string.IsNullOrEmpty(ClipDisplayName)) {
                        timelineClip.displayName = ClipDisplayName;
                    }
                    else {
                        timelineClip.displayName = clip.GetType().Name.Replace("TweenPlayableClip", "");
                    }
#endif
                }
            }

            var mixer = ScriptPlayable<TMixerBehaviour>.Create(graph, inputCount);
            mixer.GetBehaviour().Initialize(this);
            return mixer;
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