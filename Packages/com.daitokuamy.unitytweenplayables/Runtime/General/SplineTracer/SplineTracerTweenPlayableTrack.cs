using System.ComponentModel;
using UnityEngine.Timeline;
using UnityTweenPlayables.Components;
using UnityTweenPlayables.Core;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityTweenPlayables.General {
    /// <summary>
    /// SplineTracerをTweenで動かすためのPlayableTrack
    /// </summary>
    [TrackBindingType(typeof(SplineTracer))]
    [TrackClipType(typeof(SplineTracerTweenPlayableClip))]
    [TrackColor(Constant.TrackColorGeneralRed, Constant.TrackColorGeneralGreen, Constant.TrackColorGeneralBlue)]
    [DisplayName("Unity Tween Playables/General/SplineTracer Track")]
    public class SplineTracerTweenPlayableTrack : TweenPlayableTrack<SplineTracer, SplineTracerTweenMixerPlayableBehaviour> {
#if UNITY_EDITOR
        /// <summary>
        /// プロパティをプレビュー中にキャッシュするか判定(previewを戻す際に値が戻るか)
        /// </summary>
        protected override bool CheckAddDriver(SplineTracer component, SerializedProperty property) {
            return false;
        }
#endif
    }
}