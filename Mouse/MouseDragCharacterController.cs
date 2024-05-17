using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragCharacterController : MonoBehaviour
{
    public float mouseSensitivity = 100.0f; // Sensitivity of the mouse movement

    private float xRotation = 0f; // Current x rotation of the camera


    public Transform playerBody; // Reference to the character's transform
  
    private bool isCursorVisible = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor initially
    }
    void Update()
    {
        // Check if the left Alt key is being held down
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            // Show the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCursorVisible = true;
        }
        else
        {
            // Hide the cursor and lock it to the center
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCursorVisible = false;
        }




        // Get the mouse movement inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply the vertical mouse movement to the camera's rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamping to prevent flipping

        // Rotate the character left/right
        transform.Rotate(Vector3.up * mouseX);

        // Apply the vertical rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
