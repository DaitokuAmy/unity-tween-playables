using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのVectorをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererVectorTweenPlayableBehaviour : RendererTweenPlayableBehaviour<RendererVectorTweenPlayableTrack> {
        public Vector4TweenParameter value;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Renderer playerData) {
            base.SetupInternal(playerData);
            
            if (SharedMaterial.HasProperty(Track.propertyName)) {
                value.SetInitialValue(playerData, SharedMaterial.GetVector(Track.propertyName));
            }
        }
    }
}