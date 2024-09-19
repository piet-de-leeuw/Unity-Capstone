using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEn_Disable : MonoBehaviour
{
    Collider thisCollider;

    private void Start()
    {
        thisCollider = GetComponent<Collider>();
    }

    public void ColliderEnable()
    {
        thisCollider.enabled = true;
    }

    public void ColliderDisable()
    {
        thisCollider.enabled = false;
    }
}
