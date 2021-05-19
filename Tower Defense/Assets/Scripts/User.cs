using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class User : MonoBehaviour
{

    public float health = 100;
    public bool isPaused = false;
    public Button menuButton;
    public Button restartLevelButton;

    Scene lighthouse;
    Scene mainMenu;

    public GameObject dieMenuUI;
    void Start()
    {


        mainMenu = SceneManager.GetSceneByName("MainMenu");
        lighthouse = SceneManager.GetSceneByName("LighthouseScene");
        dieMenuUI.SetActive(false);

        menuButton.onClick.AddListener(ReturnToMainMenu);
        restartLevelButton.onClick.AddListener(RestartLevel);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void TakeDamage(float damage)
    {
        health -= damage;

        //attackClip.Play();
        
        if (health <= 0)
        {
            Die();
            // user has died
            // eventually this should play a graphic or something that indicates to the user that they have died
            // for now the scene just reloads

           
        }

    }



    public void RestartLevel()
    {
       
        SceneManager.LoadScene(lighthouse.name);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        
        SceneManager.LoadScene(mainMenu.name);
    }

    public void Die()
    {
        dieMenuUI.SetActive(true);
        menuButton = GameObject.Find("MainMenuButton").GetComponentInChildren<Button>();
        restartLevelButton = GameObject.Find("ReloadLevelButton").GetComponentInChildren<Button>();
        isPaused = true;

        Time.timeScale = 0f;
    }
}
