using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the character's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the character's position
    public float rotationSpeed = 5f; // Rotation speed

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired rotation angle
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Smoothly rotate the camera towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Set the camera's position to follow the character with the offset
        transform.position = target.position + offset;
    }
}
