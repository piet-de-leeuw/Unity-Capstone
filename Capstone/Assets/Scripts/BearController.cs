using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearController : MonoBehaviour, IController
{
    
    [SerializeField] Transform homeBase;
    [SerializeField] Transform target;

    [SerializeField] float homebaseStopDistance = 4f;
    [SerializeField] float ChaseRange = 17f;
    [SerializeField] float AttackRange = 2.4f;
    

    [SerializeField] bool ReturnsHome = true;

    Transform rootTransform;

    NavMeshAgent agent;
    Animator animator;

    bool isDeath = false;
    bool getHit = false;

    int weaponDamage = 20;
    public int WeaponDamage {  get { return  weaponDamage; } }


    void Start()
    {
        rootTransform = transform.Find("Armature");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        getHit = animator.GetCurrentAnimatorStateInfo(0).IsName("Bear_GetHit");
        if (isDeath || getHit) { return; }
        
        float distanceToTarged = Vector3.Distance(rootTransform.position, target.position);
        bool inChaseRange = distanceToTarged <= ChaseRange;
        bool inAttackRange = distanceToTarged <= AttackRange;

        float distanceToHomeBase = Vector3.Distance(rootTransform.position, homeBase.position);
        bool inHomeBaseStopDistance = distanceToHomeBase <= homebaseStopDistance;


        if (inChaseRange)
        {
            if (!inAttackRange)
            {

                agent.isStopped = false;
                animator.SetBool("attack", false);
                animator.SetBool("run", true);
                agent.destination = target.position;
            }
            else if (inAttackRange)
            {

                agent.velocity = Vector3.zero;
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


    public void Die()
    {
        isDeath = true;
        animator.SetTrigger("die");
    }

    public void GetHit()
    {
        animator.SetTrigger("getHit");
    }
}
