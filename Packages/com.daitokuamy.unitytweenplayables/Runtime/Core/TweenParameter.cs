using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// TweenAnimation用のパラメータ基底
    /// </summary>
    [Serializable]
    public abstract class TweenParameter<T> {
        [Tooltip("有効か")]
        public bool active;
        [Tooltip("開始値")]
        public T start;
        [Tooltip("終了値")]
        public T end;
        [Tooltip("補間パラメータ")]
        public EaseParameter ease;
        [Tooltip("相対値モードか")]
        public bool relative;

        private Dictionary<object, T> _initialValueDict = new();

        /// <summary>
        /// 初期値の取得
        /// </summary>
        public T GetInitialValue(object key) {
            _initialValueDict.TryGetValue(key, out var val);
            return val;
        }

        /// <summary>
        /// 初期値の設定
        /// </summary>
        public void SetInitialValue(object key, T val) {
            if (key == null) {
                return;
            }

            _initialValueDict[key] = val;
        }

        /// <summary>
        /// 補間値の取得
        /// </summary>
        public abstract T Evaluate(object key, float t);

        /// <summary>
        /// 相対値の取得
        /// </summary>
        public abstract T GetRelativeValue(object key, T val);
    }

    /// <summary>
    /// 浮動小数点用補間パラメータ
    /// </summary>
    [Serializable]
    public class FloatTweenParameter : TweenParameter<float> {
        /// <inheritdoc/>
        public override float Evaluate(object key, float t) {
            if (relative) {
                return Mathf.LerpUnclamped(GetRelativeValue(key, start), GetRelativeValue(key, end), ease.Evaluate(t));
            }

            return Mathf.LerpUnclamped(start, end, ease.Evaluate(t));
        }

        /// <inheritdoc/>
        public override float GetRelativeValue(object key, float value) {
            return GetInitialValue(key) + value;
        }
    }

    /// <summary>
    /// 整数用補間パラメータ
    /// </summary>
    [Serializable]
    public class IntTweenParameter : TweenParameter<int> {
        /// <inheritdoc/>
        public override int Evaluate(object key, float t) {
            if (relative) {
                return (int)Mathf.LerpUnclamped(GetRelativeValue(key, start), GetRelativeValue(key, end), ease.Evaluate(t));
            }

            return (int)Mathf.LerpUnclamped(start, end, ease.Evaluate(t));
        }

        /// <inheritdoc/>
        public override int GetRelativeValue(object key, int value) {
            return GetInitialValue(key) + value;
        }
    }

    /// <summary>
    /// Vector2用補間パラメータ
    /// </summary>
    [Serializable]
    public class Vector2TweenParameter : TweenParameter<Vector2> {
        /// <summary>
        /// 軸マスク
        /// </summary>
        [Flags]
        public enum MaskFlags {
            X = 1 << 0,
            Y = 1 << 1,
        }

        [Tooltip("無効化する軸マスク")]
        public MaskFlags ignoreMasks;
        
        /// <inheritdoc/>
        public override Vector2 GetRelativeValue(object key, Vector2 value) {
            return GetInitialValue(key) + value;
        }

        /// <inheritdoc/>
        public override Vector2 Evaluate(object key, float t) {
            if (relative) {
                return Vector2.LerpUnclamped(GetRelativeValue(key, start), GetRelativeValue(key, end), ease.Evaluate(t));
            }

            return Vector2.LerpUnclamped(start, end, ease.Evaluate(t));
        }
    }

    /// <summary>
    /// Vector3用補間パラメータ
    /// </summary>
    [Serializable]
    public class Vector3TweenParameter : TweenParameter<Vector3> {
        /// <summary>
        /// 軸マスク
        /// </summary>
        [Flags]
        public enum MaskFlags {
            X = 1 << 0,
            Y = 1 << 1,
            Z = 1 << 2,
        }

        [Tooltip("無効化する軸マスク")]
        public MaskFlags ignoreMasks;
        
        /// <inheritdoc/>
        public override Vector3 GetRelativeValue(object key, Vector3 value) {
            return GetInitialValue(key) + value;
        }

        /// <inheritdoc/>
        public override Vector3 Evaluate(object key, float t) {
            if (relative) {
                return Vector3.LerpUnclamped(GetRelativeValue(key, start), GetRelativeValue(key, end), ease.Evaluate(t));
            }

            return Vector3.LerpUnclamped(start, end, ease.Evaluate(t));
        }
    }

    /// <summary>
    /// Vector4用補間パラメータ
    /// </summary>
    [Serializable]
    public class Vector4TweenParameter : TweenParameter<Vector4> {
        /// <summary>
        /// 軸マスク
        /// </summary>
        [Flags]
        public enum MaskFlags {
            X = 1 << 0,
            Y = 1 << 1,
            Z = 1 << 2,
            W = 1 << 3,
        }

        [Tooltip("無効化する軸マスク")]
        public MaskFlags ignoreMasks;
        
        /// <inheritdoc/>
        public override Vector4 GetRelativeValue(object key, Vector4 value) {
            return GetInitialValue(key) + value;
        }

        /// <inheritdoc/>
        public override Vector4 Evaluate(object key, float t) {
            if (relative) {
                return Vector4.LerpUnclamped(GetRelativeValue(key, start), GetRelativeValue(key, end), ease.Evaluate(t));
            }

            return Vector4.LerpUnclamped(start, end, ease.Evaluate(t));
        }
    }

    /// <summary>
    /// Rect用補間パラメータ
    /// </summary>
    [Serializable]
    public class RectTweenParameter : TweenParameter<Rect> {
        /// <summary>
        /// 軸マスク
        /// </summary>
        [Flags]
        public enum MaskFlags {
            X = 1 << 0,
            Y = 1 << 1,
            Width = 1 << 2,
            Height = 1 << 3,
        }

        [Tooltip("無効化する軸マスク")]
        public MaskFlags ignoreMasks;
        
        /// <inheritdoc/>
        public override Rect GetRelativeValue(object key, Rect value) {
            return value;
        }

        /// <inheritdoc/>
        public override Rect Evaluate(object key, float t) {
            t = ease.Evaluate(t);
            var x = Mathf.LerpUnclamped(start.x, end.x, t);
            var y = Mathf.LerpUnclamped(start.y, end.y, t);
            var width = Mathf.LerpUnclamped(start.width, end.width, t);
            var height = Mathf.LerpUnclamped(start.height, end.height, t);
            return new Rect(x, y, width, height);
        }
    }

    /// <summary>
    /// RectOffset用補間パラメータ
    /// </summary>
    [Serializable]
    public class RectOffsetTweenParameter : TweenParameter<RectOffset> {
        /// <summary>
        /// 軸マスク
        /// </summary>
        [Flags]
        public enum MaskFlags {
            X = 1 << 0,
            Y = 1 << 1,
            Width = 1 << 2,
            Height = 1 << 3,
        }

        [Tooltip("無効化する軸マスク")]
        public MaskFlags ignoreMasks;
        
        /// <inheritdoc/>
        public override RectOffset GetRelativeValue(object key, RectOffset value) {
            return value;
        }

        /// <inheritdoc/>
        public override RectOffset Evaluate(object key, float t) {
            t = ease.Evaluate(t);
            var left = Mathf.LerpUnclamped(start.left, end.left, t);
            var right = Mathf.LerpUnclamped(start.right, end.right, t);
            var top = Mathf.LerpUnclamped(start.top, end.top, t);
            var bottom = Mathf.LerpUnclamped(start.bottom, end.bottom, t);
            return new RectOffset((int)left, (int)right, (int)top, (int)bottom);
        }
    }

    /// <summary>
    /// Color用補間パラメータ
    /// </summary>
    [Serializable]
    public class ColorTweenParameter : TweenParameter<Color> {
        /// <summary>
        /// 軸マスク
        /// </summary>
        [Flags]
        public enum MaskFlags {
            R = 1 << 0,
            G = 1 << 1,
            B = 1 << 2,
            A = 1 << 3,
        }

        /// <summary>
        /// ブレンドタイプ
        /// </summary>
        public enum BlendType {
            Multiply,
            Additional,
        }

        [Tooltip("無効化する軸マスク")]
        public MaskFlags ignoreMasks;
        [Tooltip("相対指定の際のブレンドタイプ")]
        public BlendType blendTypeForRelative = BlendType.Multiply;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ColorTweenParameter() {
            start = Color.white;
            end = Color.white;
        }

        /// <inheritdoc/>
        public override Color GetRelativeValue(object key, Color value) {
            switch (blendTypeForRelative) {
                case BlendType.Additional:
                    return GetInitialValue(key) + value;
                case BlendType.Multiply:
                default:
                    return GetInitialValue(key) * value;
            }
        }

        /// <inheritdoc/>
        public override Color Evaluate(object key, float t) {
            if (relative) {
                return Color.LerpUnclamped(GetRelativeValue(key, start), GetRelativeValue(key, end), ease.Evaluate(t));
            }

            return Color.LerpUnclamped(start, end, ease.Evaluate(t));
        }
    }

    /// <summary>
    /// TextMeshProのVertexGradient用補間パラメータ
    /// </summary>
    [Serializable]
    public class VertexGradientTweenParameter : TweenParameter<VertexGradient> {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public VertexGradientTweenParameter() {
            start = new VertexGradient {
                topLeft = Color.white,
                topRight = Color.white,
                bottomLeft = Color.white,
                bottomRight = Color.white
            };
            end = new VertexGradient {
                topLeft = Color.white,
                topRight = Color.white,
                bottomLeft = Color.white,
                bottomRight = Color.white
            };
        }

        /// <inheritdoc/>
        public override VertexGradient GetRelativeValue(object key, VertexGradient value) {
            return new VertexGradient {
                topLeft = start.topLeft + value.topLeft,
                topRight = start.topRight + value.topRight,
                bottomLeft = start.bottomLeft + value.bottomLeft,
                bottomRight = start.bottomRight + value.bottomRight
            };
        }

        /// <inheritdoc/>
        public override VertexGradient Evaluate(object key, float t) {
            if (relative) {
                var startValue = GetRelativeValue(key, start);
                var endValue = GetRelativeValue(key, end);
                return new VertexGradient {
                    topLeft = Color.LerpUnclamped(startValue.topLeft, endValue.topLeft, ease.Evaluate(t)),
                    topRight = Color.LerpUnclamped(startValue.topRight, endValue.topRight, ease.Evaluate(t)),
                    bottomLeft = Color.LerpUnclamped(startValue.bottomLeft, endValue.bottomLeft, ease.Evaluate(t)),
                    bottomRight = Color.LerpUnclamped(startValue.bottomLeft, endValue.bottomLeft, ease.Evaluate(t)),
                };
            }

            return new VertexGradient {
                topLeft = Color.LerpUnclamped(start.topLeft, end.topLeft, ease.Evaluate(t)),
                topRight = Color.LerpUnclamped(start.topRight, end.topRight, ease.Evaluate(t)),
                bottomLeft = Color.LerpUnclamped(start.bottomLeft, end.bottomLeft, ease.Evaluate(t)),
                bottomRight = Color.LerpUnclamped(start.bottomLeft, end.bottomLeft, ease.Evaluate(t)),
            };
        }
    }
}