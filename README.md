# 【Unity】アプリにログイン機能をつけよう！
![画像1](/readme-img/UnityLogin.png)

## 概要
* [ニフクラmobile backend](https://mbaas.nifcloud.com/)の『会員管理機能』を利用してUnityアプリにログイン機能を実装したサンプルプロジェクトです
* 簡単な操作ですぐに [ニフクラmobile backend](https://mbaas.nifcloud.com/)の機能を体験いただけます★☆

## ニフクラmobile backendって何？？
スマートフォンアプリのバックエンド機能（プッシュ通知・データストア・会員管理・ファイルストア・SNS連携・位置情報検索・スクリプト）が**開発不要**、しかも基本**無料**(注1)で使えるクラウドサービス！今回はデータストアを体験します

注1：詳しくは[こちら](https://mbaas.nifcloud.com/price.htm)をご覧ください

![画像2](/readme-img/002.png)

## 動作環境

* MacOS Mojave v10.15.6 (Catalina)
* Android studio: 4.0
* LG V20 plus (OS 8.0)
* Unity 2020.1.8f1
* iphone 7 14.0

※上記内容で動作確認をしています。


## 手順
### 1. [ニフクラmobile backend](https://mbaas.nifcloud.com/)の会員登録とログイン→アプリ作成

* 上記リンクから会員登録（無料）をします。登録ができたらログインをすると下図のように「アプリの新規作成」画面が出るのでアプリを作成します

![画像3](/readme-img/003.png)

* アプリ作成されると下図のような画面になります
* この２種類のAPIキー（アプリケーションキーとクライアントキー）はXcodeで作成するiOSアプリに[ニフクラmobile backend](https://mbaas.nifcloud.com/)を紐付けるために使用します

![画像4](/readme-img/004.png)

* 動作確認後に会員情報が保存される場所も確認しておきましょう

![画像5](/readme-img/005.png)

### 2. [GitHub](https://github.com/NIFCLOUD-mbaas/UnityLoginApp)からサンプルプロジェクトのダウンロード

* この画面([GitHub](https://github.com/NIFCLOUD-mbaas/UnityLoginApp))の![画像10](/readme-img/010.png)ボタンをクリックし、さらに![画像11](/readme-img/011.png)ボタンをクリックしてサンプルプロジェクトをMacにダウンロードします

### 3. Unityでアプリを起動

* ダウンロードしたフォルダを解凍し、Unityから開いてください。その後、Loginsigninシーンを開いてください。


### 4. APIキーの設定

* Loginsigninシーンの`NCMBSettings`を編集します
* 先程[ニフクラmobile backend](https://mbaas.nifcloud.com/)のダッシュボード上で確認したAPIキーを貼り付けます

![画像07](/readme-img/ApiKey.png)

* それぞれ`YOUR_NCMB_APPLICATION_KEY`と`YOUR_NCMB_CLIENT_KEY`の部分を書き換えます
* 書き換え終わったら`command + s`キーで保存をします

### 5. 動作確認
* Unity画面で上部真ん中の実行ボタン（さんかくの再生マーク）をクリックします

![画像12](/readme-img/UnityLogin.png)

* シミュレーターが起動したら、Login&SignIn画面が表示されます
* 初回は __`SignIn`__  ボタンをクリックして、会員登録を行います。

![画像14](/readme-img/LoginSignView.png)

* 2回目以降は`UserName`と`Password`を２つ入力してLoginボタンをタップします
* 会員登録が成功するとログインされ、下記画面が表示されます
 * このときmBaaS上に会員情報が作成されます！
 * ログインに失敗した場合は画面にエラー内容が表示されます
 * 万が一エラーが発生した場合は、[こちら](https://mbaas.nifcloud.com/doc/current/rest/common/error.html)よりエラー内容を確認いただけます

![画像15](/readme-img/LogOutView.png)

* __`Logout`__ ボタンをタップするとログアウトし、元の画面に戻ります
* 登録された会員情報を使ってLogin画面からログインが可能です（操作は同様です）

-----

* 保存に成功したら、[ニフクラmobile backend](https://mbaas.nifcloud.com/)のダッシュボードから「会員管理」を確認してみましょう！

![画像1](/readme-img/UnityLogin.png)

##### iOS端末へのビルド

* iOSビルド手順は以下のとおりです。  
iOS端末でビルドを行うには、Unityで.xcodeprojファイルを作成します。
- 「Build Settings」へ戻り、Platformで「iOS」を選択 -> 「Switch Platform」をクリックします。

<img src="readme-img/unity_ios_00001.png" width="700" alt="iOS" />


- ボタンが「Build」に変わったらクリックします。アプリ名を入力するとビルドが開始されるので、完了したらXcodeで開いてください。

- XcodeでPush Notificationの追加とプロビジョニングファイルの設定を行う必要があります。[iOSのドキュメント](https://mbaas.nifcloud.com/doc/current/push/basic_usage_ios.html#Xcodeでの対応)の「5.1 Xcodeでの対応」を実装してください。


###### Xcodeの追加設定

  * iOSであり、Unity SDK v4.0.4以上の場合、Xcode側にて「WebKit.framework」「UserNotifications.framework」を追加する必要があります。
  * Xcodeで「Unity-iPhone」-> General -> TARGETで「UnityFramework」を選択します。追加されているライブラリ一覧の下にある「＋」をクリックします。
  <img src="readme-img/add_frameworks_UnitySDK4.0.4.png" width="612"  alt="フレームワークの追加" />
  * 検索窓にて「Web」と入力し、「WebKit.framework」があるので選択しAddをクリックします。

<img src="readme-img/Webview_flow2.png" width="420" height="480" alt="リッチプッシュ設定方法2" />

* 「UserNotifications.framework」ライブラリも同じように検索して追加します

<img src="readme-img/unity_ios_00003.png" width="420" alt="iOS" />

ライブラリ一覧に追加されていることが確認できれば設定完了です。

※注意１: Unity SDK v4.2.0以上を使用している場合、上の２つに加えて「AuthencationServices.framework」も追加する必要があります。

<img src="readme-img/xcode_settings_005.png" width="680px;"/>

* 「Build Phases」 タブで「AuthenticationServices.framework」を「Optional」にします。  
<img src="readme-img/optional_AuthenticationServices.framework.png" width="680px;"/>

※注意２： Unity 2019.3未満の場合は、以下の画像のように TARGET->「Unity-iPhone」でフレームワークを追加するようにしてください。
こちらも「WebKit.framework」「UserNotifications.framework」「AuthenticationServices.framework」を追加する必要があります。

<img src="readme-img/target_Unity-iPhone.png" width="200px;"/>

- 上記が完了しましたら、iOS動作確認は可能となります。


## 解説
サンプルプロジェクトに実装済みの内容のご紹介

#### SDKのインポートと初期設定
* ニフクラmobile backend の[ドキュメント（クイックスタート）](https://mbaas.nifcloud.com/doc/current/introduction/quickstart_unity.html)をUnity版に書き換えたドキュメントをご用意していますので、ご活用ください
 
#### ロジック
 * `Loginsignin.cs`,`Logout.cs`にロジックを書いています
 * ログイン、会員登録、ログアウト部分の処理は以下のように記述されます　※ただし、左記処理以外のコードは除いています

`Loginsignin.cs`

```csharp
// ログイン
public void Login ()
    {
        print (UserName.text);
        print (PassWord.text);

        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser ();

        // ユーザー名とパスワードでログイン
        NCMBUser.LogInAsync (UserName.text, PassWord.text, (NCMBException e) => {    
            if (e != null) {
                UnityEngine.Debug.Log ("ログインに失敗: " + e.ErrorMessage);
            } else {
                UnityEngine.Debug.Log ("ログインに成功！");
                Application.LoadLevel ("LogOut");
            }
        });

    }
```


```csharp
//会員登録
    public void Signin ()
    {
        print (UserName.text);
        print (PassWord.text);


        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser ();
        
        //ユーザ名とパスワードの設定
        user.UserName = UserName.text;
        user.Password = PassWord.text;
        
        //会員登録を行う
        user.SignUpAsync ((NCMBException e) => { 
            if (e != null) {
                UnityEngine.Debug.Log ("新規登録に失敗: " + e.ErrorMessage);
            } else {
                UnityEngine.Debug.Log ("新規登録に成功");
                Application.LoadLevel ("LogOut");
            }
        });
    }
```

`Logout.cs`

```csharp
// ログアウト
public void Logout_user ()
    {
        NCMBUser.LogOutAsync ((NCMBException e) => { 
            if (e != null) {
                UnityEngine.Debug.Log ("ログアウトに失敗: " + e.ErrorMessage);
            } else {
                UnityEngine.Debug.Log ("ログアウトに成功");
                Application.LoadLevel ("Loginsignin");
            }
        });

    }
```

## 参考
* ニフクラmobile backend の[ドキュメント（会員管理）](https://mbaas.nifcloud.com/doc/current/user/basic_usage_unity.html)