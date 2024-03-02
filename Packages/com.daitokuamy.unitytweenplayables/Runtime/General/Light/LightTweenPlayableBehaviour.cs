using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// LightをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class LightTweenPlayableBehaviour : TweenPlayableBehaviour<Light, LightTweenPlayableTrack> {
        public ColorTweenParameter color;
        public FloatTweenParameter intensity;
        public FloatTweenParameter shadowStrength;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Light playerData) {
            color.SetInitialValue(playerData, playerData.color);
            intensity.SetInitialValue(playerData, playerData.intensity);
            shadowStrength.SetInitialValue(playerData, playerData.shadowStrength);
        }
    }
}