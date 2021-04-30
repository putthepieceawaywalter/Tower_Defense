using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    Firebase.FirebaseApp app;




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
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                Debug.Log("Firebase is fired up");
                isReady = true;
                init();
            }
            else
            {
                Debug.Log("firebase not working");
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });


    }

    public void OnClickRegister()
    {
        Debug.Log("register");
        if (!isReady)
        {
            init();
        }
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


    //TO DO:
        // logging in will be a different menu and corresponding script.  This code will go there once it is created.

    //public void Login()
    //{
    //    if (!isReady)
    //    {
    //        init();
    //    }
    //    auth.SignInWithEmailAndPasswordAsync(email.text.ToString(), password.text.ToString()).ContinueWith(task =>
    //    {
    //        if (task.IsCanceled)
    //        {
    //            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
    //            return;
    //        }
    //        if (task.IsFaulted)
    //        {
    //            Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
    //            return;
    //        }

    //        Firebase.Auth.FirebaseUser newUser = task.Result;
    //        Debug.LogFormat("User signed in successfully: {0} ({1})",
    //            newUser.DisplayName, newUser.UserId);
    //    });



    //    // TO DO: verify that user has signed in correclty.
    //    // inform them either way
    //    // if login has failed give them useful info (user not found or something)


    //    SceneManager.LoadScene(firstLevel.ToString()) ;
    //}

    public void init()
    {
        
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//        Debug.Log(auth.ToString());
//        Debug.Log("jkkjdfkjdf");

//        // 
////        email = GetComponentInChildren<TMP_InputField>();

//        password = GetComponentInChildren<TMP_InputField>();

//        Debug.Log("oops");

//        //// TO DO:
//        // password.inputType = TMP_InputField.InputType.Password;
//        // password.contentType = TMP_InputField.ContentType.Password;

//        // assign buttons
//        RegisterButton = GetComponentInChildren<Button>();
//        RegisterButton.onClick.AddListener(OnClickRegister);

        //LoginButton = GetComponentInChildren<Button>();
        //LoginButton.onClick.AddListener(Login);

        //if (RegisterButton == null)
        //{
        //    Debug.Log("oops");
        //}
        //Debug.Log("exiting init");
    }

}
