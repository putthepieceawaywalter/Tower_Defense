using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{

    Vector3 user = new Vector3(0, 0, -10);
    Transform target;
    float speed;
    Quaternion userRotation = new Quaternion(0, 0, 0, 0);
    


    private float moveSpeed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, user, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, userRotation, step);

    }

}
