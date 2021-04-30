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
    
    // Start is called before the first frame update

    void Start()
    {

        PlayButton = GameObject.Find("PlayButton").GetComponentInChildren<Button>();
        LoginButton = GameObject.Find("LoginButton").GetComponentInChildren<Button>();
        RegisterButton = GameObject.Find("RegisterButton").GetComponentInChildren<Button>();
        AboutButton = GameObject.Find("AboutButton").GetComponentInChildren<Button>();
       
       
        RegisterButton.onClick.AddListener(OnClickRegister);
        


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
        SceneManager.LoadScene("Register");
    }
    


}
