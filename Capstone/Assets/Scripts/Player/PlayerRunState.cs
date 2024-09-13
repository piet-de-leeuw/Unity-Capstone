using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRunState : PlayerBaseRunState
{
    public override void EnterState(PlayerController player)
    {
        Debug.Log("run");
        base.EnterState(player);
        player.SetAnimation("run");
    }

    public override void FixedUpdate(PlayerController player)
    {
        base.FixedUpdate(player);
    }

    public override void OnCollisionEnter(PlayerController player, Collision collision)
    {
        base.OnCollisionEnter(player, collision);
    }

    public override void OnTriggerEnter(PlayerController player)
    {
        base.OnTriggerEnter(player);
    }

    public override void OnTriggerExit(PlayerController player)
    {
        base.OnTriggerExit(player);
    }

    public override void Update(PlayerController player)
    {
        base.Update(player);

        if (Input.GetKeyDown(KeyCode.Space)) { player.SetState(player.JumpState); }
        if (moveDirection == Vector3.zero) { player.SetState(player.IdleState); }
    }
}
