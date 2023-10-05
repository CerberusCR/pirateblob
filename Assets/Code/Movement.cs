using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float hor;
    public float ver;
    public Vector3 move;
    public Vector3 jump;
    public float jumpF;
    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        speed = 6f;
        jumpF = 2.0f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        move.x = hor;
        move.z = ver;
        transform.Translate(move * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(jump * jumpF, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
