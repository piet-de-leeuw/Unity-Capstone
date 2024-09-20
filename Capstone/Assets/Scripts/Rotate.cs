using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
