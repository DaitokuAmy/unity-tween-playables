using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// HorizontalLayoutGroupをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class HorizontalLayoutGroupTweenPlayableBehaviour : TweenPlayableBehaviour<HorizontalLayoutGroup, HorizontalLayoutGroupTweenPlayableTrack> {
        public RectOffsetTweenParameter padding;
        public FloatTweenParameter spacing;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(HorizontalLayoutGroup playerData) {
            padding.SetInitialValue(playerData, playerData.padding);
            spacing.SetInitialValue(playerData, playerData.spacing);
        }
    }
}