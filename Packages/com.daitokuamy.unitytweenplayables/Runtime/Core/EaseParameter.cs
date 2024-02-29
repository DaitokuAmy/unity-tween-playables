using System;
using UnityEngine;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// イージング指定用パラメータ
    /// </summary>
    [Serializable]
    public class EaseParameter {
        /// <summary>
        /// 指定モード
        /// </summary>
        public enum Mode {
            [Tooltip("計算による指定")]
            Arithmetic,
            [Tooltip("テンプレートによる指定")]
            Template,
            [Tooltip("カスタムカーブ")]
            Custom,
        }

        [Tooltip("指定モード")]
        public Mode mode;
        [Tooltip("計算時のタイプ")]
        public EaseType easeType;
        [Tooltip("テンプレートのキー")]
        public string templateCurveKey;
        [Tooltip("カスタムカーブ")]
        public AnimationCurve customCurve;

        /// <summary>
        /// 補間値取得
        /// </summary>
        public float Evaluate(float t) {
            switch (mode) {
                case Mode.Arithmetic:
                    return easeType.Evaluate(t);
                case Mode.Template:
                    var curve = TweenPlayableConfig.Instance.FindTemplateCurve(templateCurveKey);
                    return curve?.Evaluate(t) ?? t;
                case Mode.Custom:
                    return customCurve.Evaluate(t);
            }

            return t;
        }
    }
}