using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{

    public GameObject enemy;
    public bool stop = false;
    public float time;
    public float delay;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", time, delay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObject()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        if (stop)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
