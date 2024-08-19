using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRunState : PlayerBaseState
{
    protected Vector3 moveDirection;

    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("run");
    }

    public override void OnCollisionEnter(PlayerController player)
    {

    }

    public override void OnTriggerExit(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {
        


        Move(player, player.runSpeed, player.runRotationSpeed);

        if (Input.GetKeyDown(KeyCode.Space)) { player.SetState(player.JumpState); }
        if (moveDirection == Vector3.zero) { player.SetState(player.IdleState); }

    }

    public override void FixedUpdate(PlayerController player)
    {

    }

    protected void Move(PlayerController player, float runSpeed, float rotationSpeed)
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = player.transform.TransformDirection(moveDirection);

        player.transform.Translate(moveDirection * runSpeed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {
            Quaternion rotateTo = Quaternion.LookRotation(moveDirection, Vector3.up);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, rotateTo, rotationSpeed * Time.deltaTime);

        }
    }
}
