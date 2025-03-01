using System;
using UnityEngine;
using UnityEngine.Splines;

namespace UnityTweenPlayables.Components {
    /// <summary>
    /// TransformをSplineContainerのカーブで移動操作させるためのコンポーネント
    /// </summary>
    public class SplineTracer : MonoBehaviour {
        /// <summary>
        /// 反映するTransformのマスク
        /// </summary>
        [Flags]
        public enum TransformMasks {
            Position = 1 << 0,
            Rotation = 1 << 1,
        }
        
        [SerializeField, Tooltip("移動制御対象")]
        private Transform _target;
        [SerializeField, Tooltip("スプラインコンテナ")]
        private SplineContainer _splineContainer;
        [SerializeField, Tooltip("反映するTransformのマスク")]
        private TransformMasks _transformMasks = TransformMasks.Position | TransformMasks.Rotation;

        /// <summary>
        /// 値の反映
        /// </summary>
        public bool Evaluate(int index, float rate) {
            if (_target == null) {
                return false;
            }

            if (_splineContainer == null || index < 0 || index >= _splineContainer.Splines.Count) {
                return false;
            }

            var result = _splineContainer.Evaluate(index, rate, out var position, out var tangent, out var upVector);
            if (!result) {
                return false;
            }

            if ((_transformMasks & TransformMasks.Position) != 0) {
                _target.position = position;
            }

            if ((_transformMasks & TransformMasks.Rotation) != 0) {
                _target.rotation = Quaternion.LookRotation(tangent, upVector);
            }

            return true;
        }
    }
}