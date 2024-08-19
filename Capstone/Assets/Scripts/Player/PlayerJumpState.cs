using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerRunState
{
    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("jump");
        player.Rigidbody.AddForce(Vector3.up * player.jumpForce);
    }

    public override void OnCollisionEnter(PlayerController player)
    {
        player.SetAnimation("hitGround");
        if (base.moveDirection != Vector3.zero) { player.SetState(player.RunState); }
        else { player.SetState(player.IdleState); }
    }

    public override void OnTriggerExit(PlayerController player)
    {
        base.OnTriggerExit(player);
    }

    public override void Update(PlayerController player)
    {
        base.Move(player, player.runSpeed, player.jumpRotationSpeed);
    }

    public override void FixedUpdate(PlayerController player)
    {
        float jumpBlend = player.Rigidbody.velocity.y;
        player.SetAnimationBlend("jumpBlend", jumpBlend);
    }

}
