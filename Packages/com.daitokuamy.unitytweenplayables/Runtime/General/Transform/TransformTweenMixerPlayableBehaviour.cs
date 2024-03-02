using System;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TransformをTweenで動かすためのMixerPlayableBehaviour
    /// </summary>
    [Serializable]
    public class TransformTweenMixerPlayableBehaviour : TweenMixerPlayableBehaviour<Transform, TransformTweenPlayableTrack, TransformTweenPlayableBehaviour> {
        private Vector3ValueMixer _positionMixer = new();
        private Vector3ValueMixer _rotationMixer = new();
        private Vector3ValueMixer _scaleMixer = new();

        /// <summary>
        /// 値の反映処理
        /// </summary>
        protected override void Apply(Transform component, TransformTweenPlayableBehaviour lastBehaviour) {
            if (_positionMixer.IsValid) {
                component.localPosition = _positionMixer.Value.Mask(component.localPosition, ~(int)lastBehaviour.position.ignoreMasks);
                _positionMixer.Clear();
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
        protected override void Blend(Transform component, TransformTweenPlayableBehaviour behaviour, float weight, float progress) {
            BlendValueMixer(_positionMixer, behaviour.position, behaviour, weight, progress);
            BlendValueMixer(_rotationMixer, behaviour.rotation, behaviour, weight, progress);
            BlendValueMixer(_scaleMixer, behaviour.scale, behaviour, weight, progress);
        }
    }
}