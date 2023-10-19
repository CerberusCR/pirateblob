using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightingflashing : MonoBehaviour
{
    public float minRange = 1.45f;
    public float maxRange = 1.55f;
    public float changeSpeed = 1.0f;

    private Light areaLight;
    private float currentRange;

    private void Start()
    {
        // Get the Area Light component attached to the same GameObject
        areaLight = GetComponent<Light>();
        currentRange = areaLight.range;
    }

    private void Update()
    {
        // Calculate a new range value
        float newRange = Mathf.PingPong(Time.time * changeSpeed, maxRange - minRange) + minRange;

        // Update the Area Light's range
        areaLight.range = newRange;
    }
}
