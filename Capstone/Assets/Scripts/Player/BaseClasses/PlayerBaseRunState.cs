using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBaseRunState : PlayerBaseState
    {
        protected Vector3 moveDirection;
        protected Vector3 cameraForwardDirection;
        protected float vertical;

        public override void EnterState(PlayerController player)
        {

        }

        public override void Update(PlayerController player)
        {
            MoveInput(player, player.runRotationSpeed);

        }

        public override void FixedUpdate(PlayerController player)
        {
            Move(player, player.runSpeed, player.runRotationSpeed);
        }

        protected void MoveInput(PlayerController player, float rotationSpeed)
        {
            float horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            cameraForwardDirection = Camera.main.transform.forward;
            cameraForwardDirection.y = 0f;

            moveDirection = new Vector3(0f, 0f, vertical);
            moveDirection = player.transform.TransformDirection(moveDirection);

        }

        protected void Move(PlayerController player, float runSpeed, float rotationSpeed)
        {

            player.Rigidbody.MovePosition(player.Rigidbody.position + moveDirection * runSpeed * Time.deltaTime);

            if (moveDirection != Vector3.zero)
            {
                Quaternion rotateTo = Quaternion.LookRotation(cameraForwardDirection * rotationSpeed * Time.fixedDeltaTime, Vector3.up);
                player.Rigidbody.MoveRotation(rotateTo);
            }

        }


    }
}