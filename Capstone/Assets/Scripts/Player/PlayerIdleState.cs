using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
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
        player.SetState(player.GetHitState);

    }

    public override void Update(PlayerController player)
    {
        if (Input.GetButton("Vertical")) { player.SetState(player.RunState);}
        else if (Input.GetKeyDown(KeyCode.Space)) {  player.SetState(player.JumpState); }
        else if (Input.GetMouseButtonUp(0)) { player.SetState(player.AttackState);}

        
    }

    public override void FixedUpdate(PlayerController player)
    {
        
    }
}
