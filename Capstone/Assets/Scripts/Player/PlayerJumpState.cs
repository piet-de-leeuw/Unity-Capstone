using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerJumpState : PlayerBaseRunState
    {
        float highestPoint;
        float currentHeight;
        public override void EnterState(PlayerController player)
        {
            player.SetAnimation("jump");
            player.Rigidbody.AddRelativeForce(Vector3.up * player.jumpForce);
            highestPoint = 0f;
            currentHeight = 0f;
        }

        public override void Update(PlayerController player)
        {
            base.Update(player);
        }

        public override void FixedUpdate(PlayerController player)
        {
            base.FixedUpdate(player);

            highestPoint = player.transform.position.y;

            if (highestPoint > currentHeight) { currentHeight = highestPoint; }
            else if (highestPoint < currentHeight) { player.SetState(player.FallState); }
            else { player.SetState(player.FallState); }

        }

    }
}