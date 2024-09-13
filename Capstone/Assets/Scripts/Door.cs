using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform door;
    [SerializeField] float speed = 1.0f;
    public bool openDoor = false;

    void Update()
    {
        if (openDoor && door.localPosition.y > -3f)
        {
            door.transform.Translate(0f, -2f * speed * Time.deltaTime, 0f);
        }
        
    }
}
