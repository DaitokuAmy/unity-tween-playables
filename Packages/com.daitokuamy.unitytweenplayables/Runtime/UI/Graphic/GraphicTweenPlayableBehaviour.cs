using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// GraphicをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class GraphicTweenPlayableBehaviour : TweenPlayableBehaviour<Graphic> {
        public ColorTweenParameter color;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Graphic playerData) {
            color.SetInitialValue(playerData, playerData.color);
        }
    }
}