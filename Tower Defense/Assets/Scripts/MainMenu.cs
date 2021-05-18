using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    Firebase.FirebaseApp app;


    public Button PlayButton;
    public Button LoginButton;
    public Button RegisterButton;
    public Button AboutButton;


    private string About = "About";
    private string Register = "Register";
    private string Login = "Login";

    // play should go to a level select screen which will show the user the levels they have unlocked.
    // in the mean time it will just take the user directly to the only level that is implemented

    private string Play = "LighthouseScene";

    
    // Start is called before the first frame update

    void Start()
    {

        PlayButton = GameObject.Find("PlayButton").GetComponentInChildren<Button>();
        LoginButton = GameObject.Find("LoginButton").GetComponentInChildren<Button>();
        RegisterButton = GameObject.Find("RegisterButton").GetComponentInChildren<Button>();
        AboutButton = GameObject.Find("AboutButton").GetComponentInChildren<Button>();
       
       
        RegisterButton.onClick.AddListener(OnClickRegister);
        AboutButton.onClick.AddListener(OnClickAbout);
        LoginButton.onClick.AddListener(OnClickLogin);
        PlayButton.onClick.AddListener(OnClickPlay);


        


        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                Debug.Log("Firebase is fired up");
                //isReady = true;
                //init();
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
    
    void OnClickRegister()
    {
        // take user to registration scene
        SceneManager.LoadScene(Register);
    }
    void OnClickAbout()
    {
        SceneManager.LoadScene(About);
    }

    void OnClickLogin()
    {
        SceneManager.LoadScene(Login);
    }

    void OnClickPlay()
    {
        SceneManager.LoadScene(Play);
    }

}
