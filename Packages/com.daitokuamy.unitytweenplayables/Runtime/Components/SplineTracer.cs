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
        public bool Evaluate(int index, float rate, int startKnotIndex = -1, int endKnotIndex = -1) {
            if (_target == null) {
                return false;
            }

            if (_splineContainer == null || index < 0 || index >= _splineContainer.Splines.Count) {
                return false;
            }

            var spline = _splineContainer.Splines[index];

            var startT = 0.0f;
            var endT = 1.0f;
            var knotCount = spline.Count;
            var totalLength = spline.GetLength();
            if (startKnotIndex >= 0) {
                if (startKnotIndex < knotCount) {
                    var length = 0.0f;
                    for (var i = 0; i < startKnotIndex; i++) {
                        length += spline.GetCurveLength(i);
                    }

                    startT = length / totalLength;
                }
            }

            if (endKnotIndex >= 0) {
                if (endKnotIndex < knotCount) {
                    var length = 0.0f;
                    for (var i = 0; i < endKnotIndex; i++) {
                        length += spline.GetCurveLength(i);
                    }

                    endT = length / totalLength;
                }
            }

            rate = Mathf.Lerp(startT, endT, rate);
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