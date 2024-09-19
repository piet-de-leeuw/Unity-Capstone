using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearDoorTrigger : MonoBehaviour
{
    [SerializeField] Door door;
    Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        if (health.isDeath)
        {
            door.openDoor = true;
        }
    }
}
