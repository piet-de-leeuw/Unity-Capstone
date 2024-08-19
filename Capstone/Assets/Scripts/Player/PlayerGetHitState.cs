using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHitState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("getHit");
    }

    public override void OnCollisionEnter(PlayerController player)
    {
        
    }

    public override void OnTriggerExit(PlayerController player)
    {
        
    }

    public override void Update(PlayerController player)
    {
        
    }
    public override void FixedUpdate(PlayerController player)
    {

    }

}
