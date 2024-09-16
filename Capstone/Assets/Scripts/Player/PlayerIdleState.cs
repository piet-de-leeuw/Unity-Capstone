using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        Debug.Log("Idle");
        player.SetAnimation("idle");
    }

    public override void OnCollisionEnter(PlayerController player, Collision collision)
    {
 
    }

    public override void OnTriggerEnter(PlayerController player)
    {

    }

    public override void OnTriggerExit(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {
        Debug.Log("IdleStateUpdate");
        if (Input.GetButton("Vertical")) { player.SetState(player.RunState); Debug.Log("ToRunState"); }
        if (Input.GetKeyDown(KeyCode.Space)) {  player.SetState(player.JumpState); }
        
    }

    public override void FixedUpdate(PlayerController player)
    {
        
    }
}
