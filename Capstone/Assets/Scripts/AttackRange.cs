using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    IAttackRange bear;

    void Start()
    {
        bear = transform.root.gameObject.GetComponent<IAttackRange>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { bear.InAttackRange = true; }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) { bear.InAttackRange = false; }
    }

}
