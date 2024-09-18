using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public int WeaponDamage { get; }

    void GetHit();

    void Die();
}
