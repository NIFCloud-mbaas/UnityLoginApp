using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using NCMB;

public class UITestLogin : MonoBehaviour
{
    [SetUp]
    public void init()
    {
        SceneManager.LoadScene("Loginsignin");
        UITestSettings.CallbackFlag = false;
    }

    [UnityTest]
    public IEnumerator testLogin()
    {
        var ifUsernameGameObj = GameObject.Find("UserName");
        var ifUsername = ifUsernameGameObj.GetComponent<InputField>();

        var ifPasswordGameObj = GameObject.Find("Password");
        var ifPassword = ifPasswordGameObj.GetComponent<InputField>();

        ifUsername.text = "testuser";
        ifPassword.text = "123456";

        var btnLogInGameObject = GameObject.Find("LogIn");
        var btnLogIn = btnLogInGameObject.GetComponent<Button>();
        btnLogIn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnLogOutGameObject = GameObject.Find("LogOutButton");
        var btnLogOut = btnLogOutGameObject.GetComponent<Button>();
        Assert.NotNull(btnLogOut);

    }

    [UnityTest]
    public IEnumerator testLogoutAfterLogin()
    {
        var ifUsernameGameObj = GameObject.Find("UserName");
        var ifUsername = ifUsernameGameObj.GetComponent<InputField>();

        var ifPasswordGameObj = GameObject.Find("Password");
        var ifPassword = ifPasswordGameObj.GetComponent<InputField>();

        ifUsername.text = "testuser";
        ifPassword.text = "123456";

        var btnLogInGameObject = GameObject.Find("LogIn");
        var btnLogIn = btnLogInGameObject.GetComponent<Button>();
        btnLogIn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnLogOutGameObject = GameObject.Find("LogOutButton");
        var btnLogOut = btnLogOutGameObject.GetComponent<Button>();
        Assert.NotNull(btnLogOut);

        btnLogOut.onClick.Invoke();
        yield return new WaitForSeconds(3);

        btnLogInGameObject = GameObject.Find("LogIn");
        btnLogIn = btnLogInGameObject.GetComponent<Button>();
        Assert.NotNull(btnLogIn);
    }

    [TearDown]
    public void TearDown()
    {

    }
}
