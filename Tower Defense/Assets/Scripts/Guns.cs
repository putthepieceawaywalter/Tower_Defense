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
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;




    ParticleSystem ps;
    bool isShooting;
   // private IEnumerator shoot;
    //VRStandardAssets.Utils.VREyeRaycaster rc;
    public AudioSource bang;
    public Button btn;



    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        //rc = GetComponent<VRStandardAssets.Utils.VREyeRaycaster>();

        isShooting = false;


      
        bang = GetComponent<AudioSource>();
        btn = GetComponentInChildren<Button>();
        btn.onClick.AddListener(ButtonClick);

        



    }


    // Update is called once per frame
    void Update()
    {



        //// eventually this will be changed to getting the input of the ui button
        //if (!isShooting)
        //{
        //    //if (Input.GetMouseButtonDown(0))
        //    //{
        //    //    ps.Play();
        //    //    bang.Play();

        //    //    //bang.PlayOneShot((AudioClip)Resources.Load("handgun_01"));
        //    //    //bang.PlayOneShot((bangClip)Resources.Load("handgun_01");

        //    //    //StartCoroutine(shoot);
        //    //}

            
        //}
    }

    void ButtonClick()
    {

       if (!isShooting)
        {
            ps.Play();
            bang.Play();
            

            Shoot();
        }
    }

    void Shoot()
    {
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
    //private IEnumerator Shoot()
    //{

    //    isShooting = true;
    //    //rc.enabled = false;
    //    yield return new WaitForSeconds(1f);
    //    //rc.enabled = true;
    //    isShooting = false;
        
    //}
}
