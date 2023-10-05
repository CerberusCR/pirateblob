using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform player;
    public float sent;
    public float x;
    public float y;
    public float cameraVerticalRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        sent = 2f;
        cameraVerticalRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Mouse X") * sent;
        y = Input.GetAxis("Mouse Y") * sent;

        cameraVerticalRotation -= y;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * x);
    }
}
