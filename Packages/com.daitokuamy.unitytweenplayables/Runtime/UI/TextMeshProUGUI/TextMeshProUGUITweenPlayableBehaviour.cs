using System;
using TMPro;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.UI {
    /// <summary>
    /// TextMeshProUGUIをTweenで動かすためのPlayableBehaviour
    /// </summary>
    [Serializable]
    public class TextMeshProUGUITweenPlayableBehaviour : TweenPlayableBehaviour<TextMeshProUGUI> {
        public ColorTweenParameter color;
        public FloatTweenParameter fontSize;
        public FloatTweenParameter characterSpacing;
        public FloatTweenParameter wordSpacing;
        public FloatTweenParameter lineSpacing;
        public FloatTweenParameter paragraphSpacing;
        public FloatTweenParameter typewriteProgress;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void SetupInternal(TextMeshProUGUI playerData) {
            color.SetInitialValue(playerData, playerData.color);
            fontSize.SetInitialValue(playerData, playerData.fontSize);
            characterSpacing.SetInitialValue(playerData, playerData.characterSpacing);
            wordSpacing.SetInitialValue(playerData, playerData.wordSpacing);
            lineSpacing.SetInitialValue(playerData, playerData.lineSpacing);
            paragraphSpacing.SetInitialValue(playerData, playerData.paragraphSpacing);
            typewriteProgress.SetInitialValue(playerData, playerData.maxVisibleCharacters);
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        protected override void CleanupInternal(TextMeshProUGUI playerData) {
            if (playerData != null) {
                playerData.maxVisibleCharacters = int.MaxValue;
            }
        }
    }
}