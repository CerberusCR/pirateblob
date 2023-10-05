using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public Transform teleportTarget;

    private GameObject player;

    private void Start()
    {
        player = GetComponent<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player character.
        if (other.CompareTag("Player"))
        {
            // Teleport the player character to the target object's position.
            other.transform.position = teleportTarget.position;
        }
    }
}
