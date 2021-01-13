using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Transform transform;
    public GameObject enemy;
    //Vector3 startPosition = (3, 0, 0);
    public int enemyCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //transform.GetComponent<Transform>();
        //startPosition = GameObje;
        StartCoroutine(EnemyDrop());  
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            if (enemyCount % 2 == 0)
            {
                Instantiate(enemy, new Vector3(3, 0, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, new Vector3(3, 0, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1);
            enemyCount += 1;

        }
    }

}
