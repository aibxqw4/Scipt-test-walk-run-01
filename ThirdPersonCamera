using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float distance = 5.0f; // Distance from the player
    public float mouseSensitivity = 2.0f; // Sensitivity of the mouse movement
    public float minYAngle = -40.0f; // Minimum vertical angle
    public float maxYAngle = 80.0f; // Maximum vertical angle

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Update()
    {
        // Get the mouse movement inputs
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle); // Clamp the vertical angle
    }

    void LateUpdate()
    {
        // Calculate the camera's position and rotation
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.position + rotation * direction;
        transform.LookAt(player.position);
    }
}
