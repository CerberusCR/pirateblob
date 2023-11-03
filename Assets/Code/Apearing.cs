using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apearing : MonoBehaviour
{
    public Transform appearAt;
    public Transform disappearAt;
    public GameObject parentObject; // The parent object that the objectToControl is a child of
    public GameObject objectToControl; // The object to appear/disappear

    private bool isVisible = false; // Indicates whether the object is visible or not

    private void Start()
    {
        // Start with the object hidden
        SetObjectVisibility(false);
    }

    private void Update()
    {
        // Check the distance between the parentObject and the appearAt and disappearAt points.
        float distanceToAppear = Vector3.Distance(parentObject.transform.position, appearAt.position);
        float distanceToDisappear = Vector3.Distance(parentObject.transform.position, disappearAt.position);

        // Toggle the visibility of the object based on the distances.
        if (distanceToAppear < 0.5f)
        {
            if (!isVisible)
            {
                SetObjectVisibility(true); // Object appears
                isVisible = true;
            }
        }
        else if (distanceToDisappear < 0.5f)
        {
            if (isVisible)
            {
                SetObjectVisibility(false); // Object disappears
                isVisible = false;
            }
        }
    }

    private void SetObjectVisibility(bool visible)
    {
        objectToControl.SetActive(visible);
    }
}
