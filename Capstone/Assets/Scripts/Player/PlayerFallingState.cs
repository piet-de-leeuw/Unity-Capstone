using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFallingState : PlayerBaseRunState
{
    Ray hitGround;
    bool isFalling;

    public override void EnterState(PlayerController player)
    {
        Debug.Log("FallingState");
        isFalling = true;
        player.SetAnimation("isFalling", isFalling);

    }

    public override void FixedUpdate(PlayerController player)
    {
        base.FixedUpdate(player);
    }

    public override void OnCollisionEnter(PlayerController player, Collision collision)
    {
        //List<ContactPoint> contactPoints = new List<ContactPoint>();
        //collision.GetContacts(contactPoints);
        //if (contactPoints.Exists( x => x.thisCollider == player.feetCollider))
        //{
            
        //    player.SetAnimation("hitGround");
        //    if (base.moveDirection != Vector3.zero) { player.SetState(player.RunState); }
        //    else { player.SetState(player.IdleState); }
        //}

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
        if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("FallingLoop"))
        {
            hitGround = new Ray(player.groundCkeckOrigin.position, Vector3.down);
            bool groundCheck = Physics.SphereCast(hitGround, 0.35f, 1.2f, player.groundCkeckLayerMask);
            Debug.DrawRay(hitGround.origin, new Vector3(0, -1.2f, 0));
            if (groundCheck) { isFalling = false; }
        }
        

        if (!isFalling)
        {
            player.SetAnimation("isFalling", isFalling);
            if (base.moveDirection != Vector3.zero) { player.SetState(player.RunState); }
            else { player.SetState(player.IdleState); }
        }
    }
}
