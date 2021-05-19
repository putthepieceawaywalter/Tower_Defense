using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Guns : MonoBehaviour
{
    // Start is called before the first frame update

    // this script will control the guns in Tower Defense
    // currently two guns are supported, a handgun and an ak style assault rifle

    public float damage = 0f;
    public float range = 100f;
    public float repeatRate = 0f;


    public int bullets = 0;
    public int clipSize = 0;
    public int bulletsInClip;

    public float reloadTime = 1f;
    public float currentAccuracy;
    public int shotsHit = 0;
    public int shotsMissed = 0;

    public Camera fpsCam;

    //public Holster holster;

    ParticleSystem ps;
    bool isShooting;
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
            // user has hit some sort of an object
            shotsHit++;
            Debug.Log(hit.transform.name);


            EnemyController enemy = hit.transform.GetComponentInParent<EnemyController>();
            if (enemy != null)
            {
                // user has hit an enemy!
                enemy.TakeDamage(damage);
            }

        }
        else
        {
            // user has shot the gun but missed all targets

            shotsMissed++;
            
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
                // user has more total bullets remaining than space available in the weapon clip

                bulletsInClip = clipSize;
                bullets = bullets - clipSize;
            }
            else
            {
                // user does not have enough bullets remaining to fill clip

                bulletsInClip = bullets;
                bullets = 0;
            }
            Debug.Log("Reloading \t bullets remaining: " + bullets);
        }
        else
        {

            // oops some dummy called this function in a scenario where the user has 0 bullets
            Exception exception = new Exception();
            throw exception;
        }
        StartCoroutine(Waiting(reloadTime));
    }

}
