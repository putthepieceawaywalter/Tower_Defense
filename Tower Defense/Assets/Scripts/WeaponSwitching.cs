using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
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
