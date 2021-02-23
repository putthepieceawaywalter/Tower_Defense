using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    public int currentWeapon = 0;

    public int totalTypesOfWeapons = 2;

    public WeaponSwitching ws;

    public Canvas switchCanvas;
    
    public Button switchWeapon;
    // Start is called before the first frame update
    void Start()
    {

        switchWeapon = GameObject.Find("SwitchWeaponCanvas").GetComponentInChildren<Button>();


        //ws = GameObject.Find("Holster").GetComponent<WeaponSwitching>();
        
        //switchWeapon = GetComponentInChildren<Button>();
        
        SelectWeapon();
        switchWeapon.onClick.AddListener(ButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
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
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
