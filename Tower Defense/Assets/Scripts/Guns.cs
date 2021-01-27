using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    // Start is called before the first frame update

    // this script will control the guns in Tower Defense
    // for the first iteration everything will be setup for the handgun, eventually several guns will be supported

    ParticleSystem ps;
    bool isShooting;
    private IEnumerator shoot;
    VRStandardAssets.Utils.VREyeRaycaster rc;
    



    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        rc = GetComponent<VRStandardAssets.Utils.VREyeRaycaster>();
        // eventually grab ui shoot button
        //int bullets = 100;
        //int magazineSize = 10;
        isShooting = false;


        


        
        //shoot = Shoot();


    }


    // Update is called once per frame
    void Update()
    {

        // eventually this will be changed to getting the input of the ui button
        if (!isShooting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ps.Play();
                
                //StartCoroutine(shoot);
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
