using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// VerticalLayoutGroupをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class VerticalLayoutGroupTweenPlayableBehaviour : TweenPlayableBehaviour<VerticalLayoutGroup, VerticalLayoutGroupTweenPlayableTrack> {
        public RectOffsetTweenParameter padding;
        public FloatTweenParameter spacing;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(VerticalLayoutGroup playerData) {
            padding.SetInitialValue(playerData, playerData.padding);
            spacing.SetInitialValue(playerData, playerData.spacing);
        }
    }
}