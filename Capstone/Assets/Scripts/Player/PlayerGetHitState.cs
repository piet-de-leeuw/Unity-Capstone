using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerGetHitState : PlayerBaseState
    {
        public override void EnterState(PlayerController player)
        {
            player.SetAnimation("getHit");

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
}