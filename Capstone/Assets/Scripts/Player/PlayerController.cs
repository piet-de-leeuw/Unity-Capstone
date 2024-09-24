using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController
{
    [SerializeField] ColliderEn_Disable weaponColliderEnDisabled;
    public Transform groundCkeckOrigin;
    public LayerMask groundCkeckLayerMask;

    public float runSpeed = 10f;
    public float runRotationSpeed = 160f;
    public float jumpForce = 300f;
    public float jumpRotationSpeed = 60f;

    Rigidbody rbody;
    public Rigidbody Rigidbody { get { return rbody; } }

    private int weaponDamage = 25;
    public int WeaponDamage { get { return weaponDamage; } }

    public SphereCollider feetCollider;
    public Collider bodyCollider;

    public GameObject sword;
    [HideInInspector]  public Animator animator;

    Health health;
    [SerializeField] Health blackBearBoss;
    [SerializeField] Health bearBoss;

    PlayerBaseState currendState;
    

    // All possible states
    public readonly PlayerBaseState IdleState = new PlayerIdleState();
    public readonly PlayerBaseState RunState = new PlayerRunState();
    public readonly PlayerBaseState JumpState = new PlayerJumpState();
    public readonly PlayerBaseState FallState = new PlayerFallingState();
    public readonly PlayerBaseState AttackState = new PlayerAttackState();
    public readonly PlayerBaseState GetHitState = new PlayerGetHitState();
    public readonly PlayerBaseState DieState = new PlayerDieState();

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        feetCollider = GetComponent<SphereCollider>();
        bodyCollider = GetComponent<CapsuleCollider>();
        health = GetComponent<Health>();

        // Don't use the SetState here. It will set the Idle animation but the animatercontroller already sets it by default.
        // It will cause a bug by transitioning (switching immediately back to idle after first transition.
        currendState = IdleState;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

    }

    void Update()
    {
        if (health.isDeath) { GameObject.Find("SceneManager").GetComponent<LoadSceneManager>().LoadGameOver(); }
        if (blackBearBoss.isDeath && bearBoss.isDeath) { GameObject.Find("SceneManager").GetComponent<LoadSceneManager>().LoadNextScene(3f); }
        currendState.Update(this);
    }

    private void FixedUpdate()
    {
        currendState.FixedUpdate(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currendState.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        currendState.OnTriggerEnter(this);
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

    public void SetAnimation(string trigger, bool value)
    {
        animator.SetBool(trigger, value);
    }

    // Are called from Health.cs component
    public void GetHit()
    {
        SetState(GetHitState);
    }

    public void Die()
    {
        SetState(DieState);
    }

    // Are called from MeeleeAttack animation

    void Enabled() { weaponColliderEnDisabled.ColliderEnable(); }

    void Disabled() { weaponColliderEnDisabled.ColliderDisable(); }
}
