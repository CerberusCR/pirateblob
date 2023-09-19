
using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float moveSpeed = 5.0f;

    public float rotationSpeed = 5.0f;


    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypoint].position;
            Vector3 moveDirection = targetPosition - transform.position;
            moveDirection.y = 0; // Ensure the enemy doesn't tilt up or down

            // Smoothly rotate the enemy to face the next waypoint
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the enemy
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                currentWaypoint++;
            }
        }
        else
        {
            // Enemy has reached the end of the path, handle accordingly (e.g., reduce player's health).
            Destroy(gameObject);
        }
    }
}