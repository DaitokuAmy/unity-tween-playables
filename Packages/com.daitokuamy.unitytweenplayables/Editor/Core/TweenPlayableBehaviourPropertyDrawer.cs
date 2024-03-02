using UnityEditor;
using UnityEngine;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.Editor.Core {
    /// <summary>
    /// TweenPlayableBehaviour用のエディタ拡張
    /// </summary>
    [CustomPropertyDrawer(typeof(TweenPlayableBehaviour<>), true)]
    public class TweenPlayableBehaviourPropertyDrawer : PropertyDrawer {
        /// <summary>
        /// GUI描画
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var rect = position;
            var spacing = EditorGUIUtility.standardVerticalSpacing;
            var currentProp = property;
            
            // 子階層プロパティのみ描画
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

        /// <summary>
        /// プロパティの高さを取得
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var height = 0.0f;
            var spacing = EditorGUIUtility.standardVerticalSpacing;
            var currentProp = property;
            
            // 子階層プロパティの高さを合計
            var depth = -1;
            
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
                height += EditorGUI.GetPropertyHeight(currentProp, true) + spacing;
            }

            return height;
        }
    }
}