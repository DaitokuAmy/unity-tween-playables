using System;
using UnityEngine;
using UnityEngine.Timeline;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public abstract class RendererTweenPlayableBehaviour<TTrack> : TweenPlayableBehaviour<Renderer, TTrack>
        where TTrack : TrackAsset, IRendererTweenPlayableTrack {
        /// <summary>編集前のMaterial</summary>
        protected Material SharedMaterial { get; private set; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Renderer playerData) {
            SharedMaterial = Track.MaterialIndex >= 0 && Track.MaterialIndex < playerData.sharedMaterials.Length ? playerData.sharedMaterials[Track.MaterialIndex] : playerData.sharedMaterial;
        }
    }
}