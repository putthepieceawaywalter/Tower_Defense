using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    int enemyTotal = 10;
    int numSpawnPoints = 5;
    int lastSpawnPoint = 0;
    bool isSpawning = false;
    private IEnumerator enemycoroutine;

    public GameObject[] enemies;


    //public EnemyController ec;


    // These are spawn points custom picked for the lighthouse scene, They will almost certainly not work for other scenes

    Vector3 spawnPoint1 = new Vector3(1, 0, 5);
    Vector3 spawnPoint2 = new Vector3(-7, 0, -8);
    Vector3 spawnPoint3 = new Vector3(-7, 0, -15);
    Vector3 spawnPoint4 = new Vector3(4, 0, 8);
    Vector3 spawnPoint5 = new Vector3(-7, 0, -11);



    Vector3[] startPoints = new Vector3[5];
    //Quaternion[] rotations = new Quaternion[3];


    // Start is called before the first frame update
    void Start()
    {

       

        enemies = new GameObject[enemyTotal];


        startPoints[0] = spawnPoint1;
        startPoints[1] = spawnPoint2;
        startPoints[2] = spawnPoint3;
        startPoints[3] = spawnPoint4;
        startPoints[4] = spawnPoint5;


        //ec = GetComponent<EnemyController>();

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
            int num = lastSpawnPoint;
            while (num == lastSpawnPoint)
            {
                // make sure there are no repeat spawn points
                num = Random.Range(0, numSpawnPoints);
            }
            lastSpawnPoint = num;
            Vector3 spawnPoint = startPoints[num];
            Instantiate(enemy, spawnPoint, transform.rotation);
            yield return new WaitForSeconds(3f);
          
        }

        isSpawning = false;
    }
}
