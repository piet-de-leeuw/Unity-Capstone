using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlackBearController : MonoBehaviour, IController, IAttackRange
{
    [SerializeField] Transform homeBase;
    [SerializeField] Transform target;

    [SerializeField] float homebaseStopDistance = 4f;
    [SerializeField] float ChaseRange = 17f;

    [SerializeField] bool ReturnsHome = true;

    bool inAttackRange = false;
    public bool InAttackRange { get { return inAttackRange; } set { inAttackRange = value; } }

    Transform rootTransform;

    NavMeshAgent agent;
    Animator animator;

    int hitCount = 0;

    bool isDeath = false;
    bool getHit = false;

    int weaponDamage = 40;
    public int WeaponDamage { get { return weaponDamage; } }


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
                else if (inHomeBaseStopDistance)
                {
                    agent.isStopped = true;
                    animator.SetBool("run", false);
                }
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
        hitCount++;
        if (hitCount >= 2)
        {
            hitCount = 0;
            animator.SetTrigger("getHit");
        }
    }
}
