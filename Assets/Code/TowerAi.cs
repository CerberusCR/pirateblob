using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAi : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>(); // List of target objects' Transforms
    public float range = 10.0f; // Range within which the follower object follows a target
    public float rotationSpeed = 5.0f; // Speed of the smooth transition
    private int currentTargetIndex = 0; // Index of the current target
    private Quaternion targetRotation;

    void Update()
    {
        if (targets.Count == 0)
            return; // No targets to follow

        if (currentTargetIndex >= targets.Count)
            currentTargetIndex = 0; // Reset to the first target if we've reached the end of the list

        Transform currentTarget = targets[currentTargetIndex];

        if (currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

            if (distanceToTarget <= range)
            {
                // Calculate the target rotation
                targetRotation = Quaternion.LookRotation(currentTarget.position - transform.position);

                // Smoothly interpolate the rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                // Move to the next target if the current target is out of range
                currentTargetIndex++;
            }
        }
    }
}
