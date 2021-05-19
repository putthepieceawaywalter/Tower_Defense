using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{

    Vector3 userPosition = new Vector3(0, 0, -10);
    public Transform target;
    float speed;

    public User user;


    public float attackInterval = 2.63f;

    public AudioSource attackClip;
    public bool isAudioPlaying;
    public float health = 50f;
   

  
    Animator animator;


    public BoxCollider collider;


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
        attackClip = GetComponent<AudioSource>();
        animator = GetComponentInParent<Animator>();
        isAudioPlaying = false;

       
    }

    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        


       // this rotates the enemy to look at the user
       transform.LookAt(target);

        //user = GetComponentInParent<User>();
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

            // moveSpeed should be .2f
            // the high speed moveSpeed is for demo use only
            // moveSpeed = 1f;
            moveSpeed = .5f;
        }
        else if (isWalk)
        {
            moveSpeed = .5f;
        }
        else if (isRunning)
        {
            moveSpeed = 2f;
        }
        else
        {
            // this could be used for idling or something
            moveSpeed = 0f; 
        }


        // distance = Vector3.Distance(obj.transform.positition, obj2.transform.position);
        

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, userPosition, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(this.transform.position, userPosition) < 1.5f && !user.isPaused)
        {
            // begin attacking
            if (!isAttacking)
            {
                if (!isAudioPlaying)
                {
                    PlayAudio();
                }

                float damage = Random.Range(1, 10);
                isAttacking = true;
                animator.SetBool("isAttacking", true);


                if (user.health > 0)
                {
                    user.TakeDamage(damage);
                }
                
               

                StartCoroutine(AttackUser());


                
            }

        }
        else if (user.isPaused)
        {
            attackClip.Stop();
        }

    }


    // called when an enemy dies
    void Die()
    {
        //AudioSource.DestroyImmediate(attackClip, true);
        attackClip.Stop();
        animator.SetBool("isDying", true);
        isDead = true;
        StopCoroutine(AttackUser());
        UnityEngine.Object.Destroy(gameObject, 5f);


    }

    void PlayAudio()
    {
        isAudioPlaying = true;
        attackClip.Play();
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            int run = Random.Range(1, 10);
            if (run > 7)
            {
                animator.SetBool("isRunning", true);
                setAllSpeedsFalse();
                isRunning = true;

            }
            else
            {
                animator.SetBool("isRunning", false);
                setAllSpeedsFalse();
                isWalk = true;
            }
        }
    }


    public void setAllSpeedsFalse()
    {
        isWalk = false;
        isSlowWalk = false;
        isRunning = false;
        isAttacking = false;

    }

    private IEnumerator AttackUser()
    {
        yield return new WaitForSeconds(attackInterval);
        isAttacking = false;
    }

    //public void Pause()
    //{
    //    // stop attacking, turn off audio
    //    // user has died or paused the game
    //    isPaused = true;
    //    attackClip.Stop();



    //}
}







