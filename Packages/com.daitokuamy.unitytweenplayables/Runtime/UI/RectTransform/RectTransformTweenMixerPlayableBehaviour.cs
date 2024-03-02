using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// RectTransformをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class RectTransformTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<RectTransform, RectTransformTweenPlayableTrack, RectTransformTweenPlayableBehaviour> {
        private Vector3ValueMixer _anchoredPositionMixer = new();
        private Vector2ValueMixer _sizeDeltaMixer = new();
        private Vector2ValueMixer _anchorMinMixer = new();
        private Vector2ValueMixer _anchorMaxMixer = new();
        private Vector2ValueMixer _pivotMixer = new();
        private Vector3ValueMixer _rotationMixer = new();
        private Vector3ValueMixer _scaleMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(RectTransform component, RectTransformTweenPlayableBehaviour lastBehaviour) {
            if (_anchoredPositionMixer.IsValid) {
                component.anchoredPosition3D = _anchoredPositionMixer.Value.Mask(component.anchoredPosition3D, ~(int)lastBehaviour.anchoredPosition.ignoreMasks);
                _anchoredPositionMixer.Clear();
            }

            if (_sizeDeltaMixer.IsValid) {
                component.sizeDelta = _sizeDeltaMixer.Value.Mask(component.sizeDelta, ~(int)lastBehaviour.sizeDelta.ignoreMasks);
                _sizeDeltaMixer.Clear();
            }

            if (_anchorMinMixer.IsValid) {
                component.anchorMin = _anchorMinMixer.Value.Mask(component.anchorMin, ~(int)lastBehaviour.anchorMin.ignoreMasks);
                _anchorMinMixer.Clear();
            }

            if (_anchorMaxMixer.IsValid) {
                component.anchorMax = _anchorMaxMixer.Value.Mask(component.anchorMax, ~(int)lastBehaviour.anchorMax.ignoreMasks);
                _anchorMaxMixer.Clear();
            }

            if (_pivotMixer.IsValid) {
                component.pivot = _pivotMixer.Value.Mask(component.pivot, ~(int)lastBehaviour.pivot.ignoreMasks);
                _pivotMixer.Clear();
            }

            if (_rotationMixer.IsValid) {
                component.localEulerAngles = _rotationMixer.Value.Mask(component.localEulerAngles, ~(int)lastBehaviour.rotation.ignoreMasks);
                _rotationMixer.Clear();
            }

            if (_scaleMixer.IsValid) {
                component.localScale = _scaleMixer.Value.Mask(component.localScale, ~(int)lastBehaviour.scale.ignoreMasks);
                _scaleMixer.Clear();
            }
        }

        /// <summary>
        /// ブレンド処理
        /// </summary>
        protected override void Blend(RectTransform component, RectTransformTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_anchoredPositionMixer, behaviour.anchoredPosition, behaviour, weight, progress);
            BlendValueMixer(_sizeDeltaMixer, behaviour.sizeDelta, behaviour, weight, progress);
            BlendValueMixer(_anchorMinMixer, behaviour.anchorMin, behaviour, weight, progress);
            BlendValueMixer(_anchorMaxMixer, behaviour.anchorMax, behaviour, weight, progress);
            BlendValueMixer(_pivotMixer, behaviour.pivot, behaviour, weight, progress);
            BlendValueMixer(_rotationMixer, behaviour.rotation, behaviour, weight, progress);
            BlendValueMixer(_scaleMixer, behaviour.scale, behaviour, weight, progress);
        }
    }
}