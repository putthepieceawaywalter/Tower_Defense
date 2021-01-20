using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyController : MonoBehaviour
{

    Vector3 user = new Vector3(0, 0, -10);
    public Transform target;
    float speed;

    public Animator animator;

    public Button click;



    private float moveSpeed = .2f;
    // Start is called before the first frame update
    void Start()
    {

        transform.LookAt(target);
        Button btn = click.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        animator = GetComponent<Animator>();
}

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, user, moveSpeed * Time.deltaTime);



    }

    // the enemy has been shot
    void TaskOnClick()
    {
        // change animation to dying animation
        animator.SetBool("isDying", true);
    }




}
