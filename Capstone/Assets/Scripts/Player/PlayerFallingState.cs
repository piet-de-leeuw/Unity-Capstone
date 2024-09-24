using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerFallingState : PlayerBaseRunState
    {
        Ray hitGround;
        bool isFalling;

        public override void EnterState(PlayerController player)
        {
            isFalling = true;
            player.SetAnimation("isFalling", isFalling);

        }

        public override void Update(PlayerController player)
        {
            base.Update(player);
            if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("FallingLoop"))
            {
                hitGround = new Ray(player.groundCkeckOrigin.position, Vector3.down);
                bool groundCheck = Physics.SphereCast(hitGround, 0.35f, 1.2f, player.groundCkeckLayerMask);
                if (groundCheck) { isFalling = false; }
            }

            if (!isFalling)
            {
                player.SetAnimation("isFalling", isFalling);
                if (moveDirection != Vector3.zero) { player.SetState(player.RunState); }
                else { player.SetState(player.IdleState); }
            }
        }
        public override void FixedUpdate(PlayerController player)
        {
            base.FixedUpdate(player);
        }
    }
}