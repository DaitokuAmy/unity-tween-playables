using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererのColorをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererColorTweenPlayableBehaviour : RendererTweenPlayableBehaviour<RendererColorTweenPlayableTrack> {
        public ColorTweenParameter value;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Renderer playerData) {
            base.SetupInternal(playerData);
            
            if (SharedMaterial.HasProperty(Track.propertyName)) {
                value.SetInitialValue(playerData, SharedMaterial.GetColor(Track.propertyName));
            }
        }
    }
}