using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{


    /// <summary>
    /// ADDING STUFF TO COMBINE THIS WITH THE MENU ITEM CONTROLLER
    /// 
    /// </summary>



    VREnemyController vrItem;
    public string sceneName;


    ////////////////////////////////////////////////////////////////////////////////////











    // this is an array of waypoints you can set up to walk from one to the other
    [SerializeField]
    private Transform[] waypoints;

    Animator ani;

    // set the walk speed
    [SerializeField]
    private float speed = 2f;

    // index of waypoint character is currently at
    private int waypointIndex = 0;


    bool isDead = false;
    bool isForward = true;
    // Start is called before the first frame update
    void Start()
    {

        ///////////////////////////////////////////////////////////////////////
        // grab component
        vrItem = GetComponent<VREnemyController>();
        vrItem.enabled = true;
        vrItem.OnClick += ChangeScene;
        ////////////////////////////////////////////////////////////////////////








        // initializes the charcter at the 0th waypoint

        transform.position = waypoints[waypointIndex].transform.position;

       // transform.Rotate(0, 270, 0);

        // gets the animator object
        ani = GetComponent<Animator>();
        ani.SetBool("isWalking", true);

    }

    // Update is called once per frame
    void Update()
    {

        //ani.SetBool("isWalking", true);

        //if (!isDead)
        //{
        //    if (Input.GetKey(KeyCode.Q))
        //    {
        //        ani.SetBool("isDead", true);
        //        isDead = true;
        //    }
        //    else
        //    {
        //        Move();
        //    }

        //}

        ani.SetBool("isWalking", true);

        if (ani.GetBool("isDead") == false)
        {
            Move();
        }

    }








    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    // send player to specified scene
    void ChangeScene()
    {
       // SceneManager.LoadScene(sceneName);

    }

    


    private void OnEnable()
    {

        //vrItem.OnClick += ChangeScene;
    }
    private void OnDisable()
    {
        //vrItem.OnClick -= ChangeScene;
    }


    private void Move()
    {
        // make character walk in one direction, turn around and walk in other direction



        if (isForward)
        {
            // walk him forward 
            // if statement for if its at the last waypoint
            // if we are at the last way point to a transform.rotate to turn his ass around
            // set isForward to false

            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
            ani.SetBool("isWalking", true);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                ++waypointIndex;
            }
            if (waypointIndex == waypoints.Length)
            {
                isForward = false;
                waypointIndex -= 2;
                transform.Rotate(0, 180, 0);
            }

        }
        else
        {
            // walk him backwards
            // if statement for if he is back to the first waypoint
            // if he is at the first waypoint then turn his ass around and make him walk forward
            // set isForward to true

            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
            ani.SetBool("isWalking", true);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                --waypointIndex;
            }
            if (waypointIndex == -1)
            {
                waypointIndex = 1;
                isForward = true;
                transform.Rotate(0, 180, 0);
            }

        }
    }
}
