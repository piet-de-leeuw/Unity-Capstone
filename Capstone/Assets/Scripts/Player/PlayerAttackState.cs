using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("attack");
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
        
    }
    public override void FixedUpdate(PlayerController player)
    {

    }

}
