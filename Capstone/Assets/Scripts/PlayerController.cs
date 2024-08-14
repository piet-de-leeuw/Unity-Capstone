using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbody;

    [SerializeField] float runSpeed = 6f;
    [SerializeField] float rotationSpeed = 4f;


    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //Move forward/ backwards
        float vertlicalMovement = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertlicalMovement);

        //rotate with mouse
        float horizontalRotate = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(0, horizontalRotate, 0);
    }
}
