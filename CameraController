using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character; // Reference to the character
    public Vector3 offset; // Offset from the character
    public float mouseSensitivity = 100f;

    private float pitch = 0f;
    private float yaw = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void LateUpdate()
    {
        HandleCameraRotation();
        FollowCharacter();
    }

    void HandleCameraRotation()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate rotation
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Clamp the pitch to avoid flipping the camera

        // Apply rotation to the camera
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    void FollowCharacter()
    {
        // Set the camera position based on the character's position and the offset
        transform.position = character.position + offset;
    }
}
