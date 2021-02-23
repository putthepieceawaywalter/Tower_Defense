using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class HandGun : MonoBehaviour
{
    // Start is called before the first frame update

    // this script will control the guns in Tower Defense
    // for the first iteration everything will be setup for the handgun, eventually several guns will be supported


    // the following code is the beginning of removing vreyeraycaster and moving that code over to the gun
    // this will allow me to manage the muzzle flash, audio clip and shooting mechanics all in one clear and concise file
    public float damage = 10f;
    public float range = 100f;
    public float timeBetweenShots = .001f;

    public WeaponSwitching ws;

    public Camera fpsCam;




    ParticleSystem ps;
    bool isShooting;
    int currentWeapon = 0;
   // private IEnumerator shoot;
    //VRStandardAssets.Utils.VREyeRaycaster rc;
    public AudioSource bang;
    public Button btn;



    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        //rc = GetComponent<VRStandardAssets.Utils.VREyeRaycaster>();

        isShooting = false;


        ws = GetComponentInParent<WeaponSwitching>();

        

      
        bang = GetComponent<AudioSource>();
        btn = GetComponentInChildren<Button>();
        btn.onClick.AddListener(ButtonClick);

    }

    void ButtonClick()
    {

        if (!isShooting)
        {
            ps.Play();


            // bang should be set in the set weapon stats function
            // protecting this line until I have ak47 audio clips
            currentWeapon = ws.currentWeapon;
            if (currentWeapon == 0)
            {
                bang.Play();
            }

            isShooting = true;


            Shoot();
            StartCoroutine(Waiting());




        }
    }

    void Shoot()
    {
        // isShooting = false;

        SetCurrentWeaponStats();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // we have hit something!
            Debug.Log(hit.transform.name);

            EnemyController enemy = hit.transform.GetComponentInParent<EnemyController>();
            if (enemy != null)
            {
                // we have hit an enemy!
                enemy.TakeDamage(damage);

                //isShooting = false;
               // yield return new WaitForSeconds(timeBetweenShots);

            }

        }


    }
    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        //rc.enabled = true;
        isShooting = false;

    }
    
    void SetCurrentWeaponStats()
    {
        currentWeapon = ws.currentWeapon;
        switch(currentWeapon)
        {
            case 0:
                // handgun
                damage = 10f;
                timeBetweenShots = .001f;
                break;
            case 1:
                // ak 47
                damage = 3f;
                timeBetweenShots = .0001f;
                break;
            default:
                // should not be reachable
                break;
        }
    }
}
