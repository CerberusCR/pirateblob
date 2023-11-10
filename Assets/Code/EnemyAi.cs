using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform targetA; // Reference to the first target object
    public Transform targetB; // Reference to the second target object
    public float moveSpeed = 1.0f; // Speed of movement
    public float rotationSpeed = 270.0f; // Speed of rotation (degrees per second)

    private Transform currentTarget;

    private void Start()
    {
        currentTarget = targetA; // Start with target A
    }

    private void Update()
    {
        // Move towards the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

        // Calculate the rotation step based on rotation speed
        float rotationStep = rotationSpeed * Time.deltaTime;

        // Calculate the Y-axis rotation only
        Vector3 targetDirection = currentTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up); // Specify the up direction

        // Maintain the current X and Z axis values
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        targetRotation.eulerAngles = new Vector3(eulerAngles.x, targetRotation.eulerAngles.y, eulerAngles.z);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationStep);

        // Check if we've reached the current target
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
        {
            // Switch to the other target
            currentTarget = (currentTarget == targetA) ? targetB : targetA;
        }
    }
}
