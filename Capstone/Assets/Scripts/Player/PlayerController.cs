using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbody;
    Rigidbody Rigidbody { get { return rbody; } }
    Animator animator;

    PlayerBaseState currendState;

    // All possible states
    readonly PlayerBaseState IdleState = new PlayerIdleState();
    readonly PlayerBaseState RunState = new PlayerRunState();
    readonly PlayerBaseState JumpState = new PlayerJumpState();
    readonly PlayerBaseState AttackState = new PlayerAttackState();
    readonly PlayerBaseState GetHitState = new PlayerGetHitState();
    readonly PlayerBaseState DieState = new PlayerDieState();

    // Animation Triggers
    string idle = "idle";
    string run = "run";
    string jump = "jump";
    string attack = "attack";
    string getHit = "getHit";
    string die = "die";

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        SetState(IdleState);
    }

    void Update()
    {
        currendState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currendState.OnCollisionEnter(this);
    }

    private void OnTriggerExit(Collider other)
    {
        currendState.OnTriggerExit(this);
    }

    public void SetState(PlayerBaseState state)
    {
        currendState = state;
        currendState.EnterState(this);
    }

    public void SetAnimation(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
