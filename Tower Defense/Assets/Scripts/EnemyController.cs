using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

[RequireComponent(typeof(VRInteractiveItem))]
public class EnemyController : MonoBehaviour
{

    Vector3 user = new Vector3(0, 0, -10);
    public Transform target;
    float speed;

    VRInteractiveItem vri;
    Animator animator;

    private void Awake()
    {
        vri = GetComponent<VRInteractiveItem>();
        animator = GetComponent<Animator>();
    }

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


    // called when an enemy dies
    void Die()
    {
        animator.SetBool("isDying", true);
    }

    void OnEnable()
    {
        vri.OnClick += Die;
    }
    void OnDisable()
    {
        vri.OnClick -= Die;
    }
}
