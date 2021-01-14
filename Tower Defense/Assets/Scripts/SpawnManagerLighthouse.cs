using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLighthouse : MonoBehaviour
{

    public GameObject enemy;
    //public bool stop = false;
    //public float time;
    //public float delay;
    int count = 0;
    int enemyTotal = 2;
    bool isSpawning = false;
    private IEnumerator enemycoroutine;


    Vector3 spawnPoint1 = new Vector3(1, 0, 5);
    Vector3 spawnPoint2 = new Vector3(-7, 0, -10);
    Vector3 spawnPoint3 = new Vector3(-7, 0, -15);



    public GameObject[] enemies;

    Vector3[] startPoints = new Vector3[3];
    Quaternion[] rotations = new Quaternion[3];


    // Start is called before the first frame update
    void Start()
    {
        

        startPoints[0] = spawnPoint1;
        startPoints[1] = spawnPoint2;
        startPoints[2] = spawnPoint3;


        enemycoroutine = EnemyCoroutine(count, enemyTotal);

        isSpawning = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(! isSpawning)
        {
            isSpawning = true;
            ++count;
            if(count < enemyTotal)
            {
                StartCoroutine(enemycoroutine);
            }

            // int enemyIndex = Random.Range(0, enemies.Length);
            
        }


    }

    private IEnumerator EnemyCoroutine(int count, int enemyTotal)
    {

        yield return new WaitForSeconds(3f);

        var num = Random.Range(0, 3);
        Vector3 spawn = startPoints[num];

        Instantiate(enemy, spawn, transform.rotation);


        isSpawning = false;


    }

}
