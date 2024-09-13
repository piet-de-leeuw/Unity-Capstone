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
    [SerializeField] float stopingDistance = 2f;
    [SerializeField] float healt = 15f;

    [SerializeField] bool ReturnsHome = true;

    NavMeshAgent agent;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarged = Vector3.Distance(transform.position, target.position);
        bool inChaseRanche = distanceToTarged <= chaseRange;
        bool inStopDictance = distanceToTarged <= stopingDistance;

        float distanceToHomeBase = Vector3.Distance(transform.position, homeBase.position);
        bool inHomeBaseStopDistance = distanceToHomeBase <= homebaseStopDistance;

        if (inChaseRanche)
        {
            if (!inStopDictance) 
            {
                agent.isStopped = false;
                agent.destination = target.position;
            }
            else if (inStopDictance) { agent.isStopped = true; }

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
