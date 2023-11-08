using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAi : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>(); // List of target objects' Transforms
    public float range = 10.0f; // Range within which the follower object follows a target
    public float rotationSpeed = 5.0f; // Speed of the smooth transition
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (targets.Count == 0)
            return; // No targets to follow

        Transform currentTarget = GetNearestInRangeTarget();

        if (currentTarget != null)
        {
            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(currentTarget.position - transform.position);

            // Smoothly interpolate the rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Play the animation
            animator.SetBool("IsInRange", true);
        }
        else
        {
            // Stop the animation
            animator.SetBool("IsInRange", false);
        }

        // Disable the Animator when no target is in range
        if (!AnyTargetInRange())
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }
    }

    Transform GetNearestInRangeTarget()
    {
        Transform nearestTarget = null;
        float nearestDistance = range + 1.0f; // Set to a value greater than the range

        foreach (Transform target in targets)
        {
            if (target != null)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (distanceToTarget <= range && distanceToTarget < nearestDistance)
                {
                    nearestDistance = distanceToTarget;
                    nearestTarget = target;
                }
            }
        }

        return nearestTarget;
    }

    bool AnyTargetInRange()
    {
        foreach (Transform target in targets)
        {
            if (target != null)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (distanceToTarget <= range)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
