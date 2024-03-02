using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのFloatをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererFloatTweenPlayableBehaviour : RendererTweenPlayableBehaviour<RendererFloatTweenPlayableTrack> {
        public FloatTweenParameter value;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Renderer playerData) {
            base.SetupInternal(playerData);
            
            if (SharedMaterial.HasProperty(Track.propertyName)) {
                value.SetInitialValue(playerData, SharedMaterial.GetFloat(Track.propertyName));
            }
        }
    }
}