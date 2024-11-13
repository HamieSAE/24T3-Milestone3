using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera Control

public class PlayerController : MonoBehaviour
{
    public Transform target; // Target to follow (player)
    public float distance = 5.0f; // Distance from target
    public float sensitivity = 2.0f; // Mouse sensitivity
    public float heightOffset = 1.5f; // Height offset for camera

    private float rotationX = 0.0f; // Vertical rotation
    private float rotationY = 0.0f; // Horizontal rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        Cursor.visible = false; // Hide cursor
    }

    void Update()
    {
        HandleCameraInput();
    }

    void HandleCameraInput()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Update horizontal rotation
        rotationY += mouseX;

        // Update vertical rotation and clamp it
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
    }

    void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        // Calculate the offset position around the target based on rotation
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 offsetPosition = rotation * new Vector3(0, 0, -distance) + Vector3.up * heightOffset;

        // Set camera position and rotation to look at the target
        transform.position = target.position + offsetPosition;
        transform.LookAt(target.position + Vector3.up * heightOffset);
    }
}
