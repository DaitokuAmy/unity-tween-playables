using System;
using UnityEngine;

namespace UnityTweenPlayables.Core {
    /// <summary>
    /// TweenPlayable用の設定インターフェース
    /// </summary>
    public interface ITweenPlayableConfig {
        /// <summary>
        /// テンプレートカーブのキー一覧を取得
        /// </summary>
        string[] GetTemplateCurveKeys();

        /// <summary>
        /// テンプレートカーブの検索
        /// </summary>
        AnimationCurve FindTemplateCurve(string key);
    }

    /// <summary>
    /// 設定ファイルアクセス用クラス
    /// </summary>
    public static class TweenPlayableConfig {
        /// <summary>
        /// 空のコンフィグ
        /// </summary>
        public class EmptyConfig : ITweenPlayableConfig {
            public string[] GetTemplateCurveKeys() => Array.Empty<string>();
            public AnimationCurve FindTemplateCurve(string key) => null;
        }

        private static ITweenPlayableConfig s_instance;

        /// <summary>シングルトンインスタンス</summary>
        public static ITweenPlayableConfig Instance {
            get {
                if (s_instance != null) {
                    return s_instance;
                }

                s_instance = Resources.Load<TweenPlayableConfigData>("UnityTweenPlayablesConfig");
                if (s_instance == null) {
                    s_instance = new EmptyConfig();
                }

                return s_instance;
            }
        }

        /// <summary>
        /// Singletonインスタンスの再読み込み
        /// </summary>
        public static void Reload() {
            s_instance = null;
            var temp = Instance;
        }
    }
}