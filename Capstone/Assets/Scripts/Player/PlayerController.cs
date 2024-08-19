using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 10f;
    public float runRotationSpeed = 120f;
    public float jumpForce = 100f;
    public float jumpRotationSpeed = 60f;

    Rigidbody rbody;
    public Rigidbody Rigidbody { get { return rbody; } }
    Animator animator;

    PlayerBaseState currendState;

    // All possible states
    public readonly PlayerBaseState IdleState = new PlayerIdleState();
    public readonly PlayerBaseState RunState = new PlayerRunState();
    public readonly PlayerBaseState JumpState = new PlayerJumpState();
    public readonly PlayerBaseState AttackState = new PlayerAttackState();
    public readonly PlayerBaseState GetHitState = new PlayerGetHitState();
    public readonly PlayerBaseState DieState = new PlayerDieState();

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Don't use the SetState here. It will set the Idle animation but the animatercontroller already sets it by default.
        // It will cause a bug by transitioning (switching immediately back to idle after first transition.
        currendState = IdleState;
    }

    void Update()
    {
        currendState.Update(this);
    }

    private void FixedUpdate()
    {
        currendState.FixedUpdate(this);
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

    public void SetAnimationBlend(string blentFloat, float value)
    {
        animator.SetFloat(blentFloat, value);
    }
}
