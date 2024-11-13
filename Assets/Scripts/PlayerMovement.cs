using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f; // Movement speed for WASD movement
    public Transform cameraTransform; // Reference to the camera transform

    private Rigidbody rb; // Rigidbody reference for movement

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        WASD();
    }

    void WASD()
    {
        // Step 1: Get WASD input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Step 2: Get the camera's forward and right directions, ignoring the y component
        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(cameraTransform.right, new Vector3(1, 0, 1)).normalized;

        // Step 3: Calculate movement direction relative to the camera's orientation
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal) * movementSpeed * Time.deltaTime;

        // Step 4: Apply movement to Rigidbody, preserving current Y velocity
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
