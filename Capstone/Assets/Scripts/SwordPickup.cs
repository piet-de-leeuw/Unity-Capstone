using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject player;
    [SerializeField] BearController bear;
    [SerializeField] Door door;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == player.tag)
        {
            Sword.SetActive(true);
            door.openDoor = true;
            bear.isInactive = false;
            Destroy(gameObject);
        }
    }
}
