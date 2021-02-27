using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Guns : MonoBehaviour
{
    // Start is called before the first frame update

    // this script will control the guns in Tower Defense
    // for the first iteration everything will be setup for the handgun, eventually several guns will be supported


    // the following code is the beginning of removing vreyeraycaster and moving that code over to the gun
    // this will allow me to manage the muzzle flash, audio clip and shooting mechanics all in one clear and concise file
    public float damage = 0f;
    public float range = 100f;
    public float repeatRate = 0f;


    public int bullets = 0;
    public int clipSize = 0;
    public int bulletsInClip;

    public float reloadTime = 1f;



    public Camera fpsCam;


    public Holster holster;


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

        isShooting = false;


        bang = GetComponent<AudioSource>();
        btn = GetComponentInChildren<Button>();
        btn.onClick.AddListener(ButtonClick);

    }

    void ButtonClick()
    {

        if (!isShooting)
        {
        
            if (bulletsInClip > 0)
            {
                ps.Play();
                bang.Play();
                isShooting = true;
                bulletsInClip--;
                Debug.Log(bulletsInClip);
                Shoot();
            }
            else if (bullets > 0)
            {
                Reload();
            }
            else
            {
                // out of bullets for this gun
                Debug.Log("You are out of bullets!");
            }


            StartCoroutine(Waiting(repeatRate));
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


            }

        }


    }
    private IEnumerator Waiting(float time)
    {
        yield return new WaitForSeconds(time);
        //rc.enabled = true;
        isShooting = false;

    }

    public void SetCurrentWeaponStats(float setDamage, int setBullets, int setClipSize, int setBulletsInClip, float setRepeatRate)
    {

        damage = setDamage;
        bullets = setBullets;
        clipSize = setClipSize;
        bulletsInClip = setBulletsInClip;
        repeatRate = setRepeatRate;

    }

    void Reload()
    {
       

        if (bullets > 0)
        {
            if (bullets > clipSize)
            {

                bulletsInClip = clipSize;
                bullets = bullets - clipSize;
            }
            else
            {
                bulletsInClip = bullets;
                bullets = 0;
            }
            Debug.Log("Reloading \t bullets remaining: " + bullets);
        }
        else
        {
            Exception exception = new Exception();
            throw exception;
        }
        StartCoroutine(Waiting(reloadTime));
    }

}
