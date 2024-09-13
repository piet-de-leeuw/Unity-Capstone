using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    [SerializeField] Transform homeBase;
    [SerializeField] Transform target;

    [SerializeField] float homebaseStopingDistance = 2f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float stopingDistance = 2f;
    [SerializeField] float runSpeed = 4f;
    [SerializeField] float healt = 15f;

    Rigidbody rbody;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarged = Vector3.Distance(transform.position, target.position);
        bool inChaseRanche = distanceToTarged <= chaseRange;
        if (inChaseRanche)
        {
            
        }

    }
}
