using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHitState : PlayerBaseState
{
    float hitForce = 200;
    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("getHit");
        player.Rigidbody.AddRelativeForce(-Vector3.forward * hitForce);
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

        if (Input.GetButton("Vertical")) { player.SetState(player.RunState); }
        else { player.SetState(player.IdleState); }
    }
    public override void FixedUpdate(PlayerController player)
    {

    }

}
