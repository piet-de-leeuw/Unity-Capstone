using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerDieState : PlayerBaseState
    {
        public override void EnterState(PlayerController player)
        {
            player.SetAnimation("die");
        }

        public override void Update(PlayerController player)
        {

        }
        public override void FixedUpdate(PlayerController player)
        {

        }
    }
}