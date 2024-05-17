using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Rotation speed

    private Vector3 lastMousePosition; // Last recorded mouse position

    void Update()
    {
        // Check for mouse button down
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button
        {
            // Record current mouse position
            lastMousePosition = Input.mousePosition;
        }

        // Rotate camera based on mouse drag
        if (Input.GetMouseButton(0)) // Assuming left mouse button
        {
            // Calculate the difference in mouse position between frames
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            // Calculate rotation amount based on mouse movement
            float rotationAmount = mouseDelta.x * rotationSpeed * Time.deltaTime;

            // Rotate the camera around its up axis (Y-axis)
            transform.Rotate(Vector3.up, rotationAmount, Space.World);

            // Update last mouse position
            lastMousePosition = Input.mousePosition;
        }
    }
}
