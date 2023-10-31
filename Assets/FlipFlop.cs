using UnityEngine;

public class FlipFlop : MonoBehaviour {
    public Transform ship;
    public float waveIntensity, rollIntensity;

    private void Update() {
        float thingieValue = Mathf.Sin(Time.time);
        float rollThingieValue = Mathf.Sin(Time.time);
        Quaternion rotation = Quaternion.identity;
        Vector3 alsoRotation = new Vector3(thingieValue * waveIntensity, 0f, rollThingieValue * rollIntensity);
        rotation.eulerAngles = alsoRotation;
        ship.rotation = rotation;
    }
}
