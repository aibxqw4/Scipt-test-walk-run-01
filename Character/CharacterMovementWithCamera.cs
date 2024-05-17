using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementWithCamera : MonoBehaviour
{
    public float walkSpeed = 6.0f; // Walking speed
    public float runSpeed = 12.0f; // Running speed
    public float jumpHeight = 3.0f; // Jump height
    public float gravity = -9.81f; // Gravity force
    public float rotationSpeed = 10.0f; // Rotation speed
    public Transform cameraTransform; // Reference to the camera transform

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset the downward velocity
        }

        // Get input from the W, A, S, and D keys
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Keep the direction strictly horizontal
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Determine the desired direction based on input
        Vector3 move = (forward * moveZ + right * moveX).normalized;

        // Move the character
        if (move.magnitude >= 0.1f)
        {
            // Calculate target angle and smooth the rotation
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Check if the Left Shift key is held down for running
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            controller.Move(move * speed * Time.deltaTime);
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
