using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {

        player.SetAnimation("idle");
    }

    public override void OnCollisionEnter(PlayerController player)
    {
 
    }

    public override void OnTriggerExit(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) { player.SetState(player.RunState); }
        if (Input.GetKeyDown(KeyCode.Space)) {  player.SetState(player.JumpState); }
        
    }

    public override void FixedUpdate(PlayerController player)
    {
        
    }
}
