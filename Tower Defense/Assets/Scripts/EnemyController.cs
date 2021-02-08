using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{

    Vector3 user = new Vector3(0, 0, -10);
    public Transform target;
    float speed;


    public float health = 50f;
   

    //VRInteractiveItem vriChild;
    Animator animator;


    public BoxCollider collider;

    //SpawnManagerLighthouse spawnManager;

    public bool isDead = false;
    public bool isAttacking = false;

    // I'd like this to default to false once there is more than one type of enemy
    // when that happens the spawn manager will manually assign a starting value for this
    // for example a running zombie would be instantiated, then from the spawn manager manually assign isRunning to true;
    public bool isSlowWalk = true;
    public bool isRunning = false;
    public bool isWalk = false;



    //private IEnumerator delete;

    private void Awake()
    {
        //vriChild = GetComponentInChildren<VRInteractiveItem>();
        collider = GetComponentInChildren<BoxCollider>();

        animator = GetComponentInParent<Animator>();
     
    }

    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {


       // this rotates the enemy to look at the user
       transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {


        if (isDead || isAttacking)
        {
            moveSpeed = 0f;
        }
        else if (isSlowWalk)
        {
            moveSpeed = 10f;
        }
        else if (isWalk)
        {
            moveSpeed = .5f;
        }
        else if (isRunning)
        {
            moveSpeed = 1f;
        }
        else
        {
            // this could be used for idling or something
            moveSpeed = 0f; 
        }


        // distance = Vector3.Distance(obj.transform.positition, obj2.transform.position);
        

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, user, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(this.transform.position, user) < 1.5f)
        {
            // begin attacking
            Attack();
        }

    }


    // called when an enemy dies
    void Die()
    {
        animator.SetBool("isDying", true);
        isDead = true;
        UnityEngine.Object.Destroy(gameObject, 5f);


    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        animator.SetBool("isAttacking", true);
        isAttacking = true;
    }

}







