using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerBaseState
    {
        public abstract void EnterState(PlayerController player);

        public abstract void Update(PlayerController player);

        public abstract void FixedUpdate(PlayerController player);

    } 
}

