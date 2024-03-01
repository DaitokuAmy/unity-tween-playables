using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// RectMask2DをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RectMask2DTweenPlayableBehaviour : TweenPlayableBehaviour<RectMask2D> {
        public Vector4TweenParameter padding;
        public Vector2TweenParameter softness;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(RectMask2D playerData) {
            padding.SetInitialValue(playerData, playerData.padding);
            softness.SetInitialValue(playerData, playerData.softness);
        }
    }
}