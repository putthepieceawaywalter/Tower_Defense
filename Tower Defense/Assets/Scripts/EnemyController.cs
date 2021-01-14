using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{

    Vector3 user = new Vector3(0, 0, -10);
    float speed;
    Quaternion userRotation = new Quaternion(0, 90, 0, 90);
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
        transform.LookAt(user);
    }



}
