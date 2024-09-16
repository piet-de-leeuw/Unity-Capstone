using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseRunState
{
    float highestPoint;
    float currentHeight;
    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("jump");
        player.Rigidbody.AddForce(Vector3.up * player.jumpForce);
        highestPoint = 0f;
        currentHeight = 0f;
    }

    public override void OnCollisionEnter(PlayerController player, Collision collision)
    {

    }

    public override void OnTriggerEnter(PlayerController player)
    {
        player.SetState(player.GetHitState);
    }

    public override void OnTriggerExit(PlayerController player)
    {
        base.OnTriggerExit(player);
    }

    public override void Update(PlayerController player)
    {
        
    }

    public override void FixedUpdate(PlayerController player)
    {
        base.Move(player, player.runSpeed, player.jumpRotationSpeed);

        highestPoint = player.Rigidbody.velocity.y;

        if (highestPoint <= currentHeight) { player.SetState(player.FallState); }
        
        if (highestPoint > currentHeight) { currentHeight = highestPoint; }

    }

}
