# unity-tween-playables
![unity_tween_playables](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/a6455984-d504-4979-8715-3de1ef88f643)

## 概要
#### 特徴
- Unity向けのTween操作可能なTimelineTrackの拡張パッケージです
- 各種ClipはAnimationTrackのように重ねる事でブレンド可能な設計になっています
- 各種ClipはAnimation Extrapolation(直前の値反映、直後の値反映の指定)に対応しています
- 基本的なイージング関数の他に、Template指定によるオリジナルカーブの指定、直接入力カーブの指定に対応しています
- 以下のクラスを継承する事で、比較的容易に独自のTrackを追加できるようにしています
  - TweenPlayableTrack
  - TweenPlayableClip
  - TweenPlayableBehaviour
  - TweenPlayableMixerBehaviour
     
## セットアップ
#### インストール
1. Window > Package ManagerからPackage Managerを開く
2. 「+」ボタン > Add package from git URL
3. 以下を入力してインストール
   * https://github.com/DaitokuAmy/unity-tween-playables.git?path=/Packages/com.daitokuamy.unitytweenplayables
   ![image](https://user-images.githubusercontent.com/6957962/209446846-c9b35922-d8cb-4ba3-961b-52a81515c808.png)
あるいはPackages/manifest.jsonを開き、dependenciesブロックに以下を追記します。
```json
{
    "dependencies": {
        "com.daitokuamy.unitytweenplayables": "https://github.com/DaitokuAmy/unity-tween-playables.git?path=/Packages/com.daitokuamy.unitytweenplayables"
    }
}
```
バージョンを指定したい場合には以下のように記述します。  
https://github.com/DaitokuAmy/unity-tween-playables.git?path=/Packages/com.daitokuamy.unitytweenplayables#1.0.0

## 使い方
#### 基本的なClipの追加方法
1. Playable Directorの用意  
  TimelineAssetも必要に応じて作成、設定します
  ![image](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/d993d2e1-8010-4390-9bfe-61a0f2cc8b2e)
2. Trackの追加から Unity Tween Playables の中にある任意のTrackを選択し、Tween操作可能なTrackを追加します
  ![image](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/59c8e322-a2f7-4ae9-ade4-8480d31353f2)
3. Trackに操作対象のComponentを追加し、タイムライン上を右クリックして Add ～ Tween Playable Clip を選択してキー入力用のClipを追加します
  ![image](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/05b6b8b4-fce5-4d9c-9fbc-63535ce1cfc4)
4. 追加したClipを選択し、Inspectorウィンドウからアニメーションする値を指定します
  ![image](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/187b3141-f0c3-4b10-8f35-513a8e0685a6)
5. 完成です
![sample](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/3ebdfd55-2bf3-4650-9411-d6432d68715e)
#### Templateカーブの使用方法
1. 任意のResourcesフォルダを右クリックし、「Create > Unity Tween Playables > Config Data」と選択して設定ファイルを作成し、以下のようにカーブを追加します
  ![image](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/3d1709df-be60-43a2-9936-19966a65ed36)
2. Clip選択時のInspectorより、Easeの指定をMode:Templateにする事で、Configに指定したカーブが選択できるようになります
   ![image](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/24f456d2-9279-4d37-896e-e9e18bffafe3)
