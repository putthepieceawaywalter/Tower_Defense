using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    Firebase.Auth.FirebaseAuth auth;

    public TMP_InputField email;
    public TMP_InputField password;

    public Button LoginButton;

    public GameObject popUpBox;

    private bool loggedIn = true;
    private bool finished = false;

    private string Menu = "MainMenu";
    // Start is called before the first frame update
    void Start()
    {

        email = GameObject.Find("Email").GetComponentInChildren<TMP_InputField>();
        password = GameObject.Find("Password").GetComponentInChildren<TMP_InputField>();

        // assign buttons
        LoginButton = GetComponentInChildren<Button>();
        LoginButton.onClick.AddListener(OnClickLogin);


        init();

     
    }
    public void OnClickLogin()
    {

        Debug.Log("Email: " + email.text.ToString());
        Debug.Log("Password: " + password.text.ToString());
        auth.SignInWithEmailAndPasswordAsync(email.text.ToString(), password.text.ToString()).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                loggedIn = false;

               // return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                loggedIn = false;

            }
            else
            {
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.Email, newUser.UserId);
                
                loggedIn = true;

            }
            if (loggedIn)
            {
                LoadScene();
            }
        });


    }
    private void init()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(Menu);
    }

}
