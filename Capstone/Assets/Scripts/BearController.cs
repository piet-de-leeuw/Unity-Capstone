using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearController : MonoBehaviour
{
    
    [SerializeField] Transform homeBase;
    [SerializeField] Transform target;

    [SerializeField] float homebaseStopDistance = 2f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float stopingDistance = 3f;
    [SerializeField] float healt = 15f;

    [SerializeField] bool ReturnsHome = true;

    Transform rootTransform;

    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        rootTransform = transform.Find("Armature");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        float distanceToTarged = Vector3.Distance(rootTransform.position, target.position);
        bool inChaseRanche = distanceToTarged <= chaseRange;
        bool inStopDictance = distanceToTarged <= stopingDistance;

        float distanceToHomeBase = Vector3.Distance(rootTransform.position, homeBase.position);
        bool inHomeBaseStopDistance = distanceToHomeBase <= homebaseStopDistance;

        if (inChaseRanche)
        {
            if (!inStopDictance) 
            {
                agent.isStopped = false;
                animator.SetBool("attack", false);
                animator.SetBool("run", true);
                agent.destination = target.position;
            }
            else if (inStopDictance) 
            {
                agent.isStopped = true;
                animator.SetBool("attack", true);
                
            }

        }
        else
        {
            if (ReturnsHome)
            {
                if (!inHomeBaseStopDistance)
                {
                    agent.isStopped = false;
                    agent.destination = homeBase.position;
                }
                else if (inHomeBaseStopDistance) { agent.isStopped = true; }
            }

        }

    }


}
