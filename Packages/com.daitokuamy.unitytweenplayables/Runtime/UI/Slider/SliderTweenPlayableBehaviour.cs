using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// SliderをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class SliderTweenPlayableBehaviour : TweenPlayableBehaviour<Slider, SliderTweenPlayableTrack> {
        public FloatTweenParameter value;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Slider playerData) {
            value.SetInitialValue(playerData, playerData.value);
        }
    }
}