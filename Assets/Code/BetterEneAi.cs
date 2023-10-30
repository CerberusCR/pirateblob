using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterEneAi : MonoBehaviour
{
    public List<Transform> targets; // List of target objects
    public float moveSpeed = 1.0f; // Speed of movement
    public float rotationSpeed = 270.0f; // Speed of rotation (degrees per second)

    private int currentTargetIndex = 0;

    private void Update()
    {
        if (targets.Count == 0)
        {
            Debug.LogWarning("No targets assigned to the list. Please assign targets in the inspector.");
            return;
        }

        // Get the current target
        Transform currentTarget = targets[currentTargetIndex];

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
            // Move to the next target in the list
            currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        }
    }
}
