using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

// this is a script which ensures the menu items are facing the user 
[RequireComponent(typeof(VRInteractiveItem))]
public class MenuItemController : MonoBehaviour
{

    // vr interactive object component
    VRInteractiveItem vrItem;
    public string sceneName;
    

    // This is called when the script is started
    void Awake()
    {
        // grab component
        vrItem = GetComponent<VRInteractiveItem>();
        vrItem.enabled = true;
        vrItem.OnClick += ChangeScene;
  

    }

    private void Update()
    {
        // this should run once per frame
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.enabled = true;
        }
    }

    // send player to specified scene
    void ChangeScene()
    {

        SceneManager.LoadScene(sceneName);

    }


    // sets vrItem's OnClick to be the ChangeScene function 
    void onEnable()
    {
        vrItem.OnClick += ChangeScene;
    }

    // disables OnClick to ChangeScene connection
    void onDisable()
    {
        vrItem.OnClick -= ChangeScene;
    }
}
