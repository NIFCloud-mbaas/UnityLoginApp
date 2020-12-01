using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NCMB;
#if UNITY_2019_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

//private InputField UserName;
//private InputField PassWord;

public class Loginsignin : MonoBehaviour
{
	public InputField UserName;
	public InputField PassWord;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Login ()
	{
		Debug.Log(UserName.text);
		Debug.Log(PassWord.text);

		//NCMBUserのインスタンス作成 
		NCMBUser user = new NCMBUser ();

		// ユーザー名とパスワードでログイン
		NCMBUser.LogInAsync (UserName.text, PassWord.text, (NCMBException e) => {    
			if (e != null) {
				UnityEngine.Debug.Log ("ログインに失敗: " + e.ErrorMessage);
			} else {
				UnityEngine.Debug.Log ("ログインに成功！");
#if UNITY_2019_3_OR_NEWER
				SceneManager.LoadScene("LogOut");
#else
				Application.LoadLevel("LogOut");
#endif
			}
		});

	}

	public void Signin ()
	{
		Debug.Log(UserName.text);
		Debug.Log(PassWord.text);


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
#if UNITY_2019_3_OR_NEWER
				SceneManager.LoadScene("LogOut");
#else
				Application.LoadLevel("LogOut");
#endif
			}
		});

	}
}
