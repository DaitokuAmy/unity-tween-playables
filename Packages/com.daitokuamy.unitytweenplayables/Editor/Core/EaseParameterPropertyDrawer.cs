using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.Editor.Core {
    /// <summary>
    /// EaseParameter用のエディタ拡張
    /// </summary>
    [CustomPropertyDrawer(typeof(EaseParameter))]
    public class EaseParameterPropertyDrawer : PropertyDrawer {
        /// <summary>
        /// GUI描画
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var rect = position;
            var spacing = EditorGUIUtility.standardVerticalSpacing;

            rect.height = EditorGUIUtility.singleLineHeight + spacing * 2;
            EditorGUI.LabelField(rect, label);
            rect.y += rect.height;
            EditorGUI.indentLevel++;

            var modeProp = property.FindPropertyRelative("mode");
            rect.height = EditorGUI.GetPropertyHeight(modeProp) + spacing * 2;
            EditorGUI.PropertyField(rect, modeProp);
            rect.y += rect.height;

            var mode = (EaseParameter.Mode)modeProp.intValue;
            switch (mode) {
                case EaseParameter.Mode.Arithmetic: {
                    var easeTypeProp = property.FindPropertyRelative("easeType");
                    rect.height = EditorGUI.GetPropertyHeight(easeTypeProp) + spacing * 2;
                    EditorGUI.PropertyField(rect, easeTypeProp);
                    rect.y += rect.height;
                    break;
                }
                case EaseParameter.Mode.Template: {
                    var templateCurveKey = property.FindPropertyRelative("templateCurveKey");
                    rect.height = EditorGUIUtility.singleLineHeight + spacing * 2;
                    var keys = TweenPlayableConfig.Instance.GetTemplateCurveKeys();
                    var index = keys.ToList().IndexOf(templateCurveKey.stringValue);
                    index = EditorGUI.Popup(rect, new GUIContent(templateCurveKey.displayName, null, templateCurveKey.tooltip), index, keys.Select(x => new GUIContent(x)).ToArray());
                    templateCurveKey.stringValue = index >= 0 && index < keys.Length ? keys[index] : "";
                    rect.y += rect.height;
                    break;
                }
                case EaseParameter.Mode.Custom: {
                    var customCurveProp = property.FindPropertyRelative("customCurve");
                    rect.height = EditorGUI.GetPropertyHeight(customCurveProp) + spacing * 2;
                    EditorGUI.PropertyField(rect, customCurveProp);
                    rect.y += rect.height;
                    break;
                }
            }
            
            EditorGUI.indentLevel--;
        }

        /// <summary>
        /// GUI高さ取得
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var height = 0.0f;
            var spacing = EditorGUIUtility.standardVerticalSpacing;

            height += EditorGUIUtility.singleLineHeight + spacing * 2;

            var modeProp = property.FindPropertyRelative("mode");
            height += EditorGUI.GetPropertyHeight(modeProp) + spacing * 2;

            var mode = (EaseParameter.Mode)modeProp.intValue;
            switch (mode) {
                case EaseParameter.Mode.Arithmetic: {
                    var easeTypeProp = property.FindPropertyRelative("easeType");
                    height += EditorGUI.GetPropertyHeight(easeTypeProp) + spacing * 2;
                    break;
                }
                case EaseParameter.Mode.Template: {
                    var templateCurveKey = property.FindPropertyRelative("templateCurveKey");
                    height += EditorGUI.GetPropertyHeight(templateCurveKey) + spacing * 2;
                    break;
                }
                case EaseParameter.Mode.Custom: {
                    var customCurveProp = property.FindPropertyRelative("customCurve");
                    height += EditorGUI.GetPropertyHeight(customCurveProp) + spacing * 2;
                    break;
                }
            }

            return height;
        }
    }
}