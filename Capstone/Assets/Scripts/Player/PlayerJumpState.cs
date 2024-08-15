using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerRunState
{
    public override void EnterState(PlayerController player)
    {
        base.EnterState(player);
    }

    public override void OnCollisionEnter(PlayerController player)
    {
        base.OnCollisionEnter(player);
    }

    public override void OnTriggerExit(PlayerController player)
    {
        base.OnTriggerExit(player);
    }

    public override void Update(PlayerController player)
    {
        base.Update(player);
    }
}
