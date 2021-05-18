using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    //Firebase.FirebaseApp app;
    Firebase.Auth.FirebaseAuth auth;

    public TMP_InputField email;
    public TMP_InputField password;

    public Button RegisterButton;
    public Scene menuScene;
    public Scene firstLevel;
    bool isReady = false;


    void Start()
    {

        email = GetComponentInChildren<TMP_InputField>();
        password = GetComponentInChildren<TMP_InputField>();

        // assign buttons
        RegisterButton = GetComponentInChildren<Button>();
        RegisterButton.onClick.AddListener(OnClickRegister);

        // this code is required to confirm google play service version requirements.

        //app = GetComponentInParent<Firebase.FirebaseApp>();

    }

    public void OnClickRegister()
    {
        Debug.Log("register");
        //if (!isReady)
        //{
        //    init();
        //}
        init();
        Debug.Log("Register Button clicked");
        Debug.Log("Email: " + email.text.ToString());
        Debug.Log("Pass: " + password.text.ToString());
        Debug.Log("Auth?: " + auth.ToString());

        auth.CreateUserWithEmailAndPasswordAsync(email.text.ToString(), password.text.ToString()).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            // send user back to main menu where they can login or 
            SceneManager.LoadScene(menuScene.ToString());
        });
    }



    public void init()
    {
        // this cannot be run in start method because it needs to be run after CheckAndFixDependenciesAsync is finished.
 
        
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;


    }

}
