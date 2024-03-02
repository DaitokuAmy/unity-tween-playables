using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// ImageをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class ImageTweenPlayableBehaviour : TweenPlayableBehaviour<Image, ImageTweenPlayableTrack> {
        public ColorTweenParameter color;
        public FloatTweenParameter fillAmount;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Image playerData) {
            color.SetInitialValue(playerData, playerData.color);
            fillAmount.SetInitialValue(playerData, playerData.fillAmount);
        }
    }
}