using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TextをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class TextTweenPlayableBehaviour : TweenPlayableBehaviour<Text> {
        public ColorTweenParameter color;
        public FloatTweenParameter fontSize;
        public FloatTweenParameter lineSpacing;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Text playerData) {
            color.SetInitialValue(playerData, playerData.color);
            fontSize.SetInitialValue(playerData, playerData.fontSize);
            lineSpacing.SetInitialValue(playerData, playerData.lineSpacing);
        }
    }
}