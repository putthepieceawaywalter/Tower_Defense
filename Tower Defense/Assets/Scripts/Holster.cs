using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Holster : MonoBehaviour
{
    public int currentWeapon = 0;

    public int totalTypesOfWeapons = 2;

    public Guns guns;

    public int handgunBullets = 10;
    public int akBullets = 50;
    public int handgunClip = 10;
    public int akClip = 20;
    public float handgunRepeat = 2f;
    public float akRepeat = 1f;
    public float handgunDamage = 10f;
    public float akDamage = 4f;


    // hold information for bullets on each gun
    // total bullets
    // clip size
    // quantity in clip

    // remove that information from Guns.cs
    // 



    // these are arrays of the various gun stats
    // this is the gun order in all three arrays
    // 0: handgun
    // 1: ak 47
    public int[] bullets; 
    public int[] clipSize;           
    public int[] bulletsInClip;
    public float[] repeatRates;
    public float[] damage;

    public Canvas switchCanvas;
    public string gameplayCanvas = "GameplayUICanvas";

    public Button switchWeaponButton;
    // Start is called before the first frame update
    void Start()
    {
        bullets = new int[2];
        clipSize = new int[2];
        bulletsInClip = new int[2];
        repeatRates = new float[2];
        damage = new float[2];
        bullets[0] = handgunBullets;
        bullets[1] = akBullets;
        clipSize[0] = handgunClip;
        clipSize[1] = akClip;
        bulletsInClip[0] = handgunClip;
        bulletsInClip[1] = akClip;
        repeatRates[0] = handgunRepeat;
        repeatRates[1] = akRepeat;
        damage[0] = handgunDamage;
        damage[1] = akDamage;

        //switchWeapon = GameObject.Find(gameplayCanvas).GetComponentInChildren<Button>();

        switchWeaponButton = GameObject.Find("SwitchWeaponButton").GetComponentInChildren<Button>();
        SelectWeapon();
        switchWeaponButton.onClick.AddListener(ButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentWeapon = 1;
            SelectWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            currentWeapon = 0;
            SelectWeapon();
        }
    }

    void ButtonClick()
    {

        // First update the holster to the current bullet quantities

        bullets[currentWeapon] = guns.bullets;
        bulletsInClip[currentWeapon] = guns.bulletsInClip;

        if (currentWeapon < totalTypesOfWeapons - 1)
        {
            currentWeapon++;
        }
        else
        {
            currentWeapon = 0;
        }
        SelectWeapon();
    }

    void SelectWeapon()
    {
        // loop through all weapons
        // disable all weapons except the one the user wants

        int i = 0;
        foreach (Transform weapon in transform)
        {

            if (i == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
                guns = GetComponentInChildren<Guns>();

                //  public void SetCurrentWeaponStats(float setDamage, int setBullets, int setClipSize, int setBulletsInClip, float setRepeatRate)
                guns.SetCurrentWeaponStats(damage[i], bullets[i], clipSize[i], bulletsInClip[i], repeatRates[i]);

            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
