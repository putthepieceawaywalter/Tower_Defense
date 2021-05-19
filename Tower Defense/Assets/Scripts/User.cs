using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class User : MonoBehaviour
{

    public float health = 100;
    public bool isPaused = false;

    // these buttons are used in both the death menu and pause menu and are only available while
    // those menus are up
    public Button menuButton;
    public Button restartLevelButton;

    // this button is availble during gameplay
    public Button pauseButton;

    Scene lighthouse;
    Scene mainMenu;

    public TMP_Text healthText;
    public TMP_Text ammoText;

    public Guns guns;
    public Holster holster;

    public GameObject dieMenuUI;
    public GameObject pauseMenuUI;
    void Start()
    {
        mainMenu = SceneManager.GetSceneByName("MainMenu");
        lighthouse = SceneManager.GetSceneByName("LighthouseScene");
        dieMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);

        //guns = GetComponentInChildren<Guns>();
        holster = GetComponentInChildren<Holster>();


        healthText = GameObject.Find("HealthText").GetComponentInChildren<TMP_Text>();
        ammoText = GameObject.Find("AmmoText").GetComponentInChildren<TMP_Text>();


        pauseButton = GameObject.Find("PauseButton").GetComponentInChildren<Button>();
        pauseButton.onClick.AddListener(Pause);
        menuButton.onClick.AddListener(ReturnToMainMenu);
        restartLevelButton.onClick.AddListener(RestartLevel);

    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 0)
        {
            healthText.text = health.ToString();
        }
        else
        {
            healthText.text = "0";
        }

        ammoText.text = holster.bulletsInClip[holster.currentWeapon].ToString() + " / " + holster.bullets[holster.currentWeapon].ToString();
        //ammoText.text = guns.bulletsInClip.ToString() + " / " + guns.bullets.ToString();
    }

   public void TakeUserDamage(float damage)
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

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        menuButton = GameObject.Find("MainMenuButton").GetComponentInChildren<Button>();
        restartLevelButton = GameObject.Find("ReloadLevelButton").GetComponentInChildren<Button>();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
