using System;
using UnityEngine.UI;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// OutlineをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class OutlineTweenPlayableBehaviour : TweenPlayableBehaviour<Outline, OutlineTweenPlayableTrack> {
        public ColorTweenParameter color;
        public Vector2TweenParameter distance;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Outline playerData) {
            color.SetInitialValue(playerData, playerData.effectColor);
            distance.SetInitialValue(playerData, playerData.effectDistance);
        }
    }
}