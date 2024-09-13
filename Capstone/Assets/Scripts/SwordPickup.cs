using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject player;
    [SerializeField] Door door;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == player.tag)
        {
            Sword.SetActive(true);
            door.openDoor = true;
            Destroy(gameObject);
        }
    }
}
