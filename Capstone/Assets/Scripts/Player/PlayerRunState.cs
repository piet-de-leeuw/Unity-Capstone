using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerRunState : PlayerBaseRunState
    {
        public override void EnterState(PlayerController player)
        {
            base.EnterState(player);
            player.SetAnimation("run");
        }

        public override void Update(PlayerController player)
        {
            base.Update(player);

            if (Input.GetKeyDown(KeyCode.Space)) { player.SetState(player.JumpState); }
            else if (moveDirection == Vector3.zero) { player.SetState(player.IdleState); }
            else if (Input.GetMouseButtonUp(0) && player.sword.gameObject.activeSelf) { player.SetState(player.AttackState); }
        }
        public override void FixedUpdate(PlayerController player)
        {
            base.FixedUpdate(player);
        }
    }
}