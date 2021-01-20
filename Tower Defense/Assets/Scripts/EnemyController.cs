using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{

    Vector3 user = new Vector3(0, 0, -10);
    public Transform target;
    float speed;



    private float moveSpeed = .2f;
    // Start is called before the first frame update
    void Start()
    {

        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, user, moveSpeed * Time.deltaTime);



    }

}
