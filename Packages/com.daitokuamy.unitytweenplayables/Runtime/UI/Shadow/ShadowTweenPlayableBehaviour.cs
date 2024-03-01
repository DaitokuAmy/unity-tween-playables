using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// ShadowをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class ShadowTweenPlayableBehaviour : TweenPlayableBehaviour<Shadow> {
        public ColorTweenParameter color;
        public Vector2TweenParameter distance;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Shadow playerData) {
            color.SetInitialValue(playerData, playerData.effectColor);
            distance.SetInitialValue(playerData, playerData.effectDistance);
        }
    }
}