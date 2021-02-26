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
    public float damage = 0f;
    public float range = 100f;
    public float timeBetweenShots = .001f;



    public int[] bullets;
    public int[] clipSize;
    public int[] bulletsInClip;

    public int handgunBullets = 20;
    public int akBullets = 50;
    public int handgunClip = 10;
    public int akClip = 2;

    public int totalWeapons = 2;

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

        bullets = new int[totalWeapons];
        bulletsInClip = new int[totalWeapons];
        clipSize = new int[totalWeapons];
        
        ps = GetComponentInChildren<ParticleSystem>();
        //rc = GetComponent<VRStandardAssets.Utils.VREyeRaycaster>();


        bullets.SetValue(handgunBullets, 0);
        bullets.SetValue(akBullets, 1);
        bulletsInClip.SetValue(akBullets, 1);
        bulletsInClip.SetValue(akBullets, 1);

        clipSize.SetValue(handgunClip, 0);
        clipSize.SetValue(akBullets, 1);
        //bullets[0] = handgunBullets;

        //bulletsInClip[0] = handgunBullets;
        //bulets[1] = akBullets;
        //bulletsInClip[1] = akBullets;

        //clipSize[0] = handgunClip;
        //clipSize[1] = akClip;

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

            bang.Play();
         

            isShooting = true;

            SetCurrentWeaponStats();

            if (bulletsInClip[currentWeapon] > 0)
            {
                --bulletsInClip[currentWeapon];
                Debug.Log(bulletsInClip[currentWeapon]);
                Shoot();
                StartCoroutine(Waiting());
            }
            else
            {
                // reload if there are bullets to reload with
                if(bullets[currentWeapon] > 0)
                {
                    Reload();
                }
                else
                {
                    // user is out of bullets
                }
            }
        }
    }

    void Shoot()
    {
        // isShooting = false;


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
                timeBetweenShots = .1f;
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

    void Reload()
    {
        if (bullets[currentWeapon] > clipSize[currentWeapon])
        {
            bulletsInClip[currentWeapon] = clipSize[currentWeapon];
            bullets[currentWeapon] = bullets[currentWeapon] - clipSize[currentWeapon];

        }
        else
        {
            // there are bullets remaining but not enough to fill the clip

            bulletsInClip[currentWeapon] = bullets[currentWeapon];
            bullets[currentWeapon] = 0;

        }
    }

}
