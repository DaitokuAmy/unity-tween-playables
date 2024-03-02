using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// SpriteRendererをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class SpriteRendererTweenPlayableBehaviour : TweenPlayableBehaviour<SpriteRenderer, SpriteRendererTweenPlayableTrack> {
        public ColorTweenParameter color;
        public Vector2TweenParameter size;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(SpriteRenderer playerData) {
            color.SetInitialValue(playerData, playerData.color);
            size.SetInitialValue(playerData, playerData.size);
        }
    }
}