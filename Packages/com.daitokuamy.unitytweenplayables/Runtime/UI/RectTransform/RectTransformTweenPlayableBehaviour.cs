using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// RectTransformをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RectTransformTweenPlayableBehaviour : TweenPlayableBehaviour<RectTransform, RectTransformTweenPlayableTrack> {
        public Vector3TweenParameter anchoredPosition;
        public Vector2TweenParameter sizeDelta;
        public Vector2TweenParameter anchorMin;
        public Vector2TweenParameter anchorMax;
        public Vector2TweenParameter pivot;
        public Vector3TweenParameter rotation;
        public Vector3TweenParameter scale;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(RectTransform playerData) {
            anchoredPosition.SetInitialValue(playerData, playerData.anchoredPosition3D);
            sizeDelta.SetInitialValue(playerData, playerData.sizeDelta);
            anchorMin.SetInitialValue(playerData, playerData.anchorMin);
            anchorMax.SetInitialValue(playerData, playerData.anchorMax);
            pivot.SetInitialValue(playerData, playerData.sizeDelta);
            rotation.SetInitialValue(playerData, playerData.localEulerAngles);
            scale.SetInitialValue(playerData, playerData.localScale);
        }
    }
}