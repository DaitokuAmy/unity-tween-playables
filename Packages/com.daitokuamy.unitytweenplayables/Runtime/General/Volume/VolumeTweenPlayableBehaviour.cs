using System;
using UnityEngine.Rendering;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VolumeをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class VolumeTweenPlayableBehaviour : TweenPlayableBehaviour<Volume, VolumeTweenPlayableTrack> {
        public FloatTweenParameter weight;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Volume playerData) {
            weight.SetInitialValue(playerData, playerData.weight);
        }
    }
}