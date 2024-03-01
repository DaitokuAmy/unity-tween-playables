using UnityEngine;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// 値操作用のユーティリティ
    /// </summary>
    public static class ValueUtility {
        /// <summary>
        /// Vector2の値をマスクする
        /// </summary>
        /// <param name="source">基礎値</param>
        /// <param name="baseValue">置き換え値</param>
        /// <param name="mask">マスク(1が基礎値を使用)</param>
        /// <returns>マスク後の値</returns>
        public static Vector2 Mask(this Vector2 source, Vector2 baseValue, int mask) {
            for (var i = 0; i < 2; i++) {
                if ((mask & (1 << i)) != 0) {
                    continue;
                }

                source[i] = baseValue[i];
            }

            return source;
        }

        /// <summary>
        /// Vector3の値をマスクする
        /// </summary>
        /// <param name="source">基礎値</param>
        /// <param name="baseValue">置き換え値</param>
        /// <param name="mask">マスク(1が基礎値を使用)</param>
        /// <returns>マスク後の値</returns>
        public static Vector3 Mask(this Vector3 source, Vector3 baseValue, int mask) {
            for (var i = 0; i < 3; i++) {
                if ((mask & (1 << i)) != 0) {
                    continue;
                }

                source[i] = baseValue[i];
            }

            return source;
        }

        /// <summary>
        /// Vector4の値をマスクする
        /// </summary>
        /// <param name="source">基礎値</param>
        /// <param name="baseValue">置き換え値</param>
        /// <param name="mask">マスク(1が基礎値を使用)</param>
        /// <returns>マスク後の値</returns>
        public static Vector4 Mask(this Vector4 source, Vector4 baseValue, int mask) {
            for (var i = 0; i < 4; i++) {
                if ((mask & (1 << i)) != 0) {
                    continue;
                }

                source[i] = baseValue[i];
            }

            return source;
        }

        /// <summary>
        /// Vector4の値をマスクする
        /// </summary>
        /// <param name="source">基礎値</param>
        /// <param name="baseValue">置き換え値</param>
        /// <param name="mask">マスク(1が基礎値を使用)</param>
        /// <returns>マスク後の値</returns>
        public static RectOffset Mask(this RectOffset source, RectOffset baseValue, int mask) {
            if ((mask & (1 << 0)) == 0) {
                source.left = baseValue.left;
            }

            if ((mask & (1 << 0)) == 0) {
                source.right = baseValue.right;
            }

            if ((mask & (1 << 0)) == 0) {
                source.top = baseValue.top;
            }

            if ((mask & (1 << 0)) == 0) {
                source.bottom = baseValue.bottom;
            }

            return source;
        }

        /// <summary>
        /// Colorの値をマスクする
        /// </summary>
        /// <param name="source">基礎値</param>
        /// <param name="baseValue">置き換え値</param>
        /// <param name="mask">マスク(1が基礎値を使用)</param>
        /// <returns>マスク後の値</returns>
        public static Color Mask(this Color source, Color baseValue, int mask) {
            for (var i = 0; i < 4; i++) {
                if ((mask & (1 << i)) != 0) {
                    continue;
                }

                source[i] = baseValue[i];
            }

            return source;
        }
    }
}