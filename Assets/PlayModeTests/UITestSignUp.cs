using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using NCMB;

public class UITestSignUp : MonoBehaviour
{

    [SetUp]
    public void init()
    {
        SceneManager.LoadScene("Loginsignin");
        UITestSettings.CallbackFlag = false;
    }

    [UnityTest]
    public IEnumerator testSignUp()
    {
        NCMBUser.LogInAsync ("testuser1", "123456", (NCMBException e1) => {    
            if (e1 != null) {     
                UITestSettings.CallbackFlag = true;                   
            } else {
                    NCMBUser.CurrentUser.DeleteAsync((NCMBException e2) => {
                    UITestSettings.CallbackFlag = true;
                });
            }
        });
        yield return UITestSettings.AwaitAsync();

        var ifUsernameGameObj = GameObject.Find("UserName");
        var ifUsername = ifUsernameGameObj.GetComponent<InputField>();

        var ifPasswordGameObj = GameObject.Find("Password");
        var ifPassword = ifPasswordGameObj.GetComponent<InputField>();

        ifUsername.text = "testuser1";
        ifPassword.text = "123456";

        var btnLogInGameObject = GameObject.Find("SignIn");
        var btnLogIn = btnLogInGameObject.GetComponent<Button>();
        btnLogIn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnLogOutGameObject = GameObject.Find("LogOutButton");
        var btnLogOut = btnLogOutGameObject.GetComponent<Button>();
        Assert.NotNull(btnLogOut);

    }

    [UnityTest]
    public IEnumerator testLogoutAfterSignUp()
    {
        NCMBUser.LogInAsync ("testuser1", "123456", (NCMBException e1) => {    
            if (e1 != null) {     
                UITestSettings.CallbackFlag = true;                   
            } else {
                    NCMBUser.CurrentUser.DeleteAsync((NCMBException e2) => {
                    UITestSettings.CallbackFlag = true;
                });
            }
        });
        yield return UITestSettings.AwaitAsync();

        var ifUsernameGameObj = GameObject.Find("UserName");
        var ifUsername = ifUsernameGameObj.GetComponent<InputField>();

        var ifPasswordGameObj = GameObject.Find("Password");
        var ifPassword = ifPasswordGameObj.GetComponent<InputField>();

        ifUsername.text = "testuser1";
        ifPassword.text = "123456";

        var btnLogInGameObject = GameObject.Find("SignIn");
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
