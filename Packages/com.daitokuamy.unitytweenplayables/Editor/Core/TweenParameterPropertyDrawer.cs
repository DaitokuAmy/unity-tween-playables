using UnityEditor;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.Editor.Core {
    /// <summary>
    /// EaseParameter用のエディタ拡張
    /// </summary>
    [CustomPropertyDrawer(typeof(TweenParameter<>), true)]
    public class TweenParameterPropertyDrawer : PropertyDrawer {
        /// <summary>
        /// GUI描画
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // Active状態の時にタイトル名にアイコンを付ける
            var active = property.FindPropertyRelative("active").boolValue;
            var iconContent = EditorGUIUtility.IconContent(active ? "d_greenLight" : "d_redLight");
            iconContent.text = label.text;
            iconContent.tooltip = label.tooltip;
            
            var rect = position;
            var spacing = EditorGUIUtility.standardVerticalSpacing;
            
            // タイトルプロパティの描画
            var currentProp = property;
            rect.height = EditorGUI.GetPropertyHeight(currentProp, false);
            EditorGUI.PropertyField(rect, currentProp, iconContent, false);
            rect.y += rect.height + spacing;
            
            // 子階層プロパティの描画
            if (currentProp.isExpanded) {
                var depth = -1;
                EditorGUI.indentLevel++;
                
                while (currentProp.NextVisible(true) || depth == -1) {
                    // Depthが元よりも低いなら終わり
                    if (depth != -1 && currentProp.depth < depth) {
                        break;
                    }

                    // Depthが違う物は描画しない
                    if (depth != -1 && currentProp.depth != depth) {
                        continue;
                    }

                    depth = currentProp.depth;
                    rect.height = EditorGUI.GetPropertyHeight(currentProp, true);
                    EditorGUI.PropertyField(rect, currentProp, true);
                    rect.y += rect.height + spacing;
                }

                EditorGUI.indentLevel--;
            }
        }

        /// <summary>
        /// プロパティの高さを取得
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUI.GetPropertyHeight(property, true);
        }
    }
}