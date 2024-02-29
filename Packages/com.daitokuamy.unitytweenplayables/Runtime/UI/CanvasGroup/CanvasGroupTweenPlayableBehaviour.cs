using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// CanvasGroupをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class CanvasGroupTweenPlayableBehaviour : TweenPlayableBehaviour<CanvasGroup> {
        public FloatTweenParameter alpha;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(CanvasGroup playerData) {
            alpha.SetInitialValue(playerData, playerData.alpha);
        }
    }
}