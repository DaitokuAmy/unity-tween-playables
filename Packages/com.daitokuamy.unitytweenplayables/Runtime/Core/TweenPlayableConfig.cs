using System;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

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

#if UNITY_EDITOR
                var data = PlayerSettings.GetPreloadedAssets().OfType<TweenPlayableConfigData>().FirstOrDefault();
                s_instance = data;
#endif

                if (s_instance == null) {
                    s_instance = new EmptyConfig();
                }

                return s_instance;
            }
        }

        /// <summary>
        /// Singletonインスタンスの再読み込み
        /// </summary>
        internal static void SetInstance(ITweenPlayableConfig config) {
            s_instance = config;
        }

#if UNITY_EDITOR
        /// <summary>
        /// コンフィグファイルの生成処理
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        [MenuItem("Assets/Create/Unity Tween Playables/Config Data")]
        private static void CreateConfigData() {
            // 既に存在していたらエラー
            var data = PlayerSettings.GetPreloadedAssets().OfType<TweenPlayableConfigData>().FirstOrDefault();
            if (data != null) {
                throw new InvalidOperationException($"{nameof(TweenPlayableConfigData)} already exists in preloaded assets.");
            }

            var assetPath = EditorUtility.SaveFilePanelInProject($"Save {nameof(TweenPlayableConfigData)}", nameof(TweenPlayableConfigData), "asset", "", "Assets");
            if (string.IsNullOrEmpty(assetPath)) {
                return;
            }

            // フォルダがなかったら作る
            var folderPath = Path.GetDirectoryName(assetPath);
            if (!string.IsNullOrEmpty(folderPath) && !Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
            }

            // アセットを作成してPreloadedAssetsに設定
            var instance = ScriptableObject.CreateInstance<TweenPlayableConfigData>();
            AssetDatabase.CreateAsset(instance, assetPath);
            var preloadedAssets = PlayerSettings.GetPreloadedAssets().ToList();
            preloadedAssets.Add(instance);
            PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
            AssetDatabase.SaveAssets();
        }
#endif
    }
}