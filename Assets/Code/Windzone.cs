using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windzone : MonoBehaviour
{
    public Cloth cloth;
    public WindZone windZone;

    void Update()
    {
        Vector3 windForce = windZone.transform.forward * windZone.windMain;
        // Apply the wind force to the cloth
        cloth.externalAcceleration = windForce;
    }
}
