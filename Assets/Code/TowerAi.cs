using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAi : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>(); // List of target objects' Transforms
    public GameObject launchableObject; // Reference to the existing launchable object
    public float range = 10.0f; // Range within which the follower object follows a target
    public float rotationSpeed = 5.0f; // Speed of the smooth transition
    public float launchSpeed = 10.0f; // Speed to launch the object
    public float respawnDelay = 2.0f; // Time in seconds to respawn the launchable object
    private int currentTargetIndex = 0; // Index of the current target
    private Animator animator;
    private Vector3 launchDirection;

    private Vector3 initialLaunchableObjectPosition;
    private Quaternion initialLaunchableObjectRotation;

    void Start()
    {
        animator = GetComponent<Animator>();
        initialLaunchableObjectPosition = launchableObject.transform.position;
        initialLaunchableObjectRotation = launchableObject.transform.rotation;
    }

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
                Quaternion targetRotation = Quaternion.LookRotation(currentTarget.position - transform.position);

                // Smoothly interpolate the rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Play the animation
                animator.SetBool("IsInRange", true);

                // Calculate the launch direction
                launchDirection = transform.forward;

                // Launch the object when the target is in range
                LaunchObject();
            }
            else
            {
                // Stop the animation
                animator.SetBool("IsInRange", false);
            }
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

    void LaunchObject()
    {
        if (launchableObject != null)
        {
            // Move the object using translation
            launchableObject.transform.Translate(launchDirection * launchSpeed * Time.deltaTime);
        }
    }

    IEnumerator RespawnLaunchableObject()
    {
        yield return new WaitForSeconds(respawnDelay);

        // Reset the launchable object's position and rotation
        launchableObject.transform.position = initialLaunchableObjectPosition;
        launchableObject.transform.rotation = initialLaunchableObjectRotation;

        // Re-enable the launchable object and its Collider
        launchableObject.SetActive(true);
        Collider launchableObjectCollider = launchableObject.GetComponent<Collider>();
        if (launchableObjectCollider != null)
        {
            launchableObjectCollider.enabled = true;
        }
    }
}
