using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// Rendererの汎用パラメータをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RendererStandardTweenPlayableBehaviour : RendererTweenPlayableBehaviour<RendererStandardTweenPlayableTrack> {
        public ColorTweenParameter mainColor;
        public Vector2TweenParameter mainTextureOffset;
        public Vector2TweenParameter mainTextureScale;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(Renderer playerData) {
            base.SetupInternal(playerData);
            
            mainColor.SetInitialValue(playerData, SharedMaterial.color);
            mainTextureOffset.SetInitialValue(playerData, SharedMaterial.mainTextureOffset);
            mainTextureScale.SetInitialValue(playerData, SharedMaterial.mainTextureScale);
        }
    }
}