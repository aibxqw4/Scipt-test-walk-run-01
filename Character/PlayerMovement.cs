using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6.0f;
    public float runSpeed = 12.0f;
    public float gravity = -9.8f;
    private bool isRunning = false; // Flag to track if the player is currently running



    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // Toggle running state with a single tap of the Shift key
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = !isRunning;
            }

            // Set the speed based on the running state
            float speed = isRunning ? runSpeed : walkSpeed;

            // Get horizontal movement input
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Set movement direction based on input
            moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        // Apply gravity
        moveDirection.y += gravity * Time.deltaTime;

        // Move the character
        characterController.Move(moveDirection * Time.deltaTime);
    }
}