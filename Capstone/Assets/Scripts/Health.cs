using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 50;

    public void GetDamage(int amount)
    {
        health -= amount;
    }

}
