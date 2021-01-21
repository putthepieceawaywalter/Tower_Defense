using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    int count;
    int enemyTotal = 10;
    bool isSpawning = false;
    private IEnumerator enemycoroutine;


    public GameObject[] enemies;



    public EnemyController ec;


    Vector3 spawnPoint1 = new Vector3(1, 0, 5);
    Vector3 spawnPoint2 = new Vector3(-7, 0, -10);
    Vector3 spawnPoint3 = new Vector3(-7, 0, -15);

    Vector3[] startPoints = new Vector3[3];
    Quaternion[] rotations = new Quaternion[3];


    // Start is called before the first frame update
    void Start()
    {

        count = 0;

        enemies = new GameObject[enemyTotal];


        startPoints[0] = spawnPoint1;
        startPoints[1] = spawnPoint2;
        startPoints[2] = spawnPoint3;


        ec = GetComponent<EnemyController>();




        enemycoroutine = EnemyCoroutine(enemyTotal);

    }

    // Update is called once per frame
    void Update()
    {

        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(enemycoroutine);



        }

    }

    private IEnumerator EnemyCoroutine(int enemyTotal)
    {
        

       
       


        for (int i = 0; i < enemyTotal; ++i)
        {
            var num = Random.Range(0, 3);
            Vector3 spawn = startPoints[num];
            Instantiate(enemy, spawn, transform.rotation);
            yield return new WaitForSeconds(3f);
        }


        isSpawning = false;
    }
}
