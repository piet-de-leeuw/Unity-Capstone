using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFallingState : PlayerBaseRunState
{
    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("fall");
    }

    public override void FixedUpdate(PlayerController player)
    {
        base.FixedUpdate(player);
    }

    public override void OnCollisionEnter(PlayerController player, Collision collision)
    {
        List<ContactPoint> contactPoints = new List<ContactPoint>();
        collision.GetContacts(contactPoints);
        
        if (contactPoints.Exists( x => x.thisCollider == player.feetCollider))
        {
            player.SetAnimation("hitGround");
            if (base.moveDirection != Vector3.zero) { player.SetState(player.RunState); }
            else { player.SetState(player.IdleState); }
        }
        

    }

    public override void OnTriggerEnter(PlayerController player)
    {


    }

    public override void OnTriggerExit(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {
        base.Update(player);
    }
}
