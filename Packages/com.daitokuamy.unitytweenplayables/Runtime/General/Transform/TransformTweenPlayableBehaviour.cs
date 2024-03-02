using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TransformをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class TransformTweenPlayableBehaviour : TweenPlayableBehaviour<Transform, TransformTweenPlayableTrack> {
        public Vector3TweenParameter position;
        public Vector3TweenParameter rotation;
        public Vector3TweenParameter scale;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Transform playerData) {
            position.SetInitialValue(playerData, playerData.localPosition);
            rotation.SetInitialValue(playerData, playerData.localEulerAngles);
            scale.SetInitialValue(playerData, playerData.localScale);
        }
    }
}