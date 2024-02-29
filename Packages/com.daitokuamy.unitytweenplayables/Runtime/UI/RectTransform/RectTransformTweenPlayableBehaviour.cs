using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// RectTransformをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RectTransformTweenPlayableBehaviour : TweenPlayableBehaviour<RectTransform> {
        public Vector3TweenParameter anchoredPosition;
        public Vector2TweenParameter sizeDelta;
        public Vector3TweenParameter rotation;
        public Vector3TweenParameter scale;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(RectTransform playerData) {
            anchoredPosition.SetInitialValue(playerData, playerData.anchoredPosition3D);
            sizeDelta.SetInitialValue(playerData, playerData.sizeDelta);
            rotation.SetInitialValue(playerData, playerData.localEulerAngles);
            scale.SetInitialValue(playerData, playerData.localScale);
        }
    }
}