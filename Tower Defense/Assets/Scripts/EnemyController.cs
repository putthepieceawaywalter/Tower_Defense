using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;


public class EnemyController : MonoBehaviour
{

    Vector3 user = new Vector3(0, 0, -10);
    public Transform target;
    float speed;

    VRInteractiveItem vriChild;
    Animator animator;


    public BoxCollider collider;

    SpawnManagerLighthouse spawnManager;

    public bool isDead = false;

    // I'd like this to default to false once there is more than one type of enemy
    // when that happens the spawn manager will manually assign a starting value for this
    // for example a running zombie would be instantiated, then from the spawn manager manually assign isRunning to true;
    public bool isSlowWalk = true;
    public bool isRunning = false;
    public bool isWalk = false;



    //private IEnumerator delete;

    private void Awake()
    {
        vriChild = GetComponentInChildren<VRInteractiveItem>();
        collider = GetComponentInChildren<BoxCollider>();

        animator = GetComponentInParent<Animator>();

        spawnManager = GetComponent<SpawnManagerLighthouse>();

     
    }

    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {


       
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {


        if (isDead)
        {
            moveSpeed = 0f;
        }
        else if (isSlowWalk)
        {
            moveSpeed = .2f;
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

        

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, user, moveSpeed * Time.deltaTime);
        


    }


    // called when an enemy dies
    void Die()
    {
        animator.SetBool("isDying", true);
        isDead = true;

        
        UnityEngine.Object.Destroy(spawnManager.enemy, 5f);




    }

    void OnEnable()
    {
        vriChild.OnClick += Die;
        

    }
    void OnDisable()
    {

        vriChild.OnClick -= Die;
    }


}







