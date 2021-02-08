using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class User : MonoBehaviour
{

    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {

            // user has died
            // eventually this should play a graphic or something that indicates to the user that they have died
            // for now the scene just reloads

            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

    }
}
