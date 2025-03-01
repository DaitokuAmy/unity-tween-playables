using System;
using TMPro;
using UnityEngine;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// 値をブレンドするためのクラス
    /// </summary>
    [Serializable]
    public abstract class ValueMixer<T> {
        /// <summary>値</summary>
        public T Value { get; private set; }
        /// <summary>ブレンドしている値の総数</summary>
        public int ValueCount { get; private set; }
        /// <summary>値が有効か</summary>
        public bool IsValid => ValueCount > 0;

        /// <summary>
        /// 値のクリア
        /// </summary>
        public virtual void Clear() {
            Value = default;
            ValueCount = 0;
        }

        /// <summary>
        /// 値のブレンド
        /// </summary>
        /// <param name="val">ブレンドする基礎値</param>
        /// <param name="weight">重み</param>
        public virtual void Blend(T val, float weight) {
            Value = Add(Value, val, weight);
            ValueCount++;
        }

        /// <summary>
        /// 値の加算
        /// </summary>
        /// <param name="baseValue">ベース値</param>
        /// <param name="addValue">加算値</param>
        /// <param name="weight">重み</param>
        /// <returns>Valueに加算した後の値</returns>
        protected abstract T Add(T baseValue, T addValue, float weight);
    }

    /// <summary>
    /// 浮動小数点用補間パラメータ
    /// </summary>
    [Serializable]
    public class FloatValueMixer : ValueMixer<float> {
        /// <inheritdoc/>
        protected override float Add(float baseValue, float addValue, float weight) {
            return baseValue + addValue * weight;
        }
    }

    /// <summary>
    /// Vector2用補間パラメータ
    /// </summary>
    [Serializable]
    public class Vector2ValueMixer : ValueMixer<Vector2> {
        /// <inheritdoc/>
        protected override Vector2 Add(Vector2 baseValue, Vector2 addValue, float weight) {
            return baseValue + addValue * weight;
        }
    }

    /// <summary>
    /// Vector3用補間パラメータ
    /// </summary>
    [Serializable]
    public class Vector3ValueMixer : ValueMixer<Vector3> {
        /// <inheritdoc/>
        protected override Vector3 Add(Vector3 baseValue, Vector3 addValue, float weight) {
            return baseValue + addValue * weight;
        }
    }

    /// <summary>
    /// Vector4用補間パラメータ
    /// </summary>
    [Serializable]
    public class Vector4ValueMixer : ValueMixer<Vector4> {
        /// <inheritdoc/>
        protected override Vector4 Add(Vector4 baseValue, Vector4 addValue, float weight) {
            return baseValue + addValue * weight;
        }
    }

    /// <summary>
    /// Quaternion用補間パラメータ
    /// </summary>
    [Serializable]
    public class QuaternionValueMixer : ValueMixer<Quaternion> {
        /// <inheritdoc/>
        protected override Quaternion Add(Quaternion baseValue, Quaternion addValue, float weight) {
            return baseValue * Quaternion.Slerp(Quaternion.identity, addValue, weight);
        }
    }

    /// <summary>
    /// Vector4用補間パラメータ
    /// </summary>
    [Serializable]
    public class RectOffsetValueMixer : ValueMixer<RectOffset> {
        private Vector4 _floatValue;

        /// <summary>
        /// 値のクリア
        /// </summary>
        public override void Clear() {
            _floatValue = default;
            base.Clear();
        }

        /// <summary>
        /// 値のブレンド
        /// </summary>
        /// <param name="val">ブレンドする基礎値</param>
        /// <param name="weight">重み</param>
        public override void Blend(RectOffset val, float weight) {
            var floatVal = new Vector4(val.left, val.right, val.top, val.bottom);
            _floatValue += floatVal * weight;
        }
        
        /// <inheritdoc/>
        protected override RectOffset Add(RectOffset baseValue, RectOffset addValue, float weight) {
            var floatVal = new Vector4(addValue.left, addValue.right, addValue.top, addValue.bottom);
            _floatValue += floatVal * weight;
            return new RectOffset((int)floatVal.x, (int)floatVal.y, (int)floatVal.z, (int)floatVal.w);
        }
    }

    /// <summary>
    /// Color用補間パラメータ
    /// </summary>
    [Serializable]
    public class ColorValueMixer : ValueMixer<Color> {
        /// <inheritdoc/>
        protected override Color Add(Color baseValue, Color addValue, float weight) {
            return baseValue + addValue * weight;
        }
    }

    /// <summary>
    /// TextMeshProのVertexGradient用補間パラメータ
    /// </summary>
    [Serializable]
    public class VertexGradientValueMixer : ValueMixer<VertexGradient> {
        /// <inheritdoc/>
        protected override VertexGradient Add(VertexGradient baseValue, VertexGradient addValue, float weight) {
            return new VertexGradient {
                topLeft = baseValue.topLeft + addValue.topLeft * weight,
                topRight = baseValue.topRight + addValue.topRight * weight,
                bottomLeft = baseValue.bottomLeft + addValue.bottomLeft * weight,
                bottomRight = baseValue.bottomRight + addValue.bottomRight * weight,
            };
        }
    }
}