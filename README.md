# unity-tween-playables
![image](https://github.com/DaitokuAmy/unity-tween-playables/assets/6957962/2086b861-34da-4bb2-9ad2-e2110dc712d7)

## 概要
#### 特徴
* Unity向けのTween操作可能なTimelineTrackの拡張パッケージ
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
        "com.daitokuamy.unityrenametool": "https://github.com/DaitokuAmy/unity-tween-playables.git?path=/Packages/com.daitokuamy.unitytweenplayables"
    }
}
```
バージョンを指定したい場合には以下のように記述します。  
https://github.com/DaitokuAmy/unity-tween-playables.git?path=/Packages/com.daitokuamy.unitytweenplayables#1.0.0
