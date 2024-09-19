using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    BearController bear;

    void Start()
    {
        bear = transform.root.gameObject.GetComponent<BearController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { bear.inAttackRange = true; }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) { bear.inAttackRange = false; }
    }

}
