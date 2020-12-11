using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    public float playerSpeed;
    public float playerRotationSpeed;
    
    private CharacterController _controller;
    private Rigidbody _rb;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Player movement
        transform.Rotate(0, Input.GetAxis("Horizontal") * playerRotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = transform.TransformDirection(move);
        _controller.Move(move * playerSpeed);
    }
}