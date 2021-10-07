using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{

    public float JumpForce = 150;
    public float Speed;
    public bool isGrounded;
    public float NumberJumps = 0f;
    public float MaxJumps = 1;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        GetComponent<Transform>().Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0));

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
               rb.AddForce(new Vector3(1f, 0, 0));

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
               rb.AddForce(new Vector3(-1f, 0, 0));

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
               rb.AddForce(GetComponent<Transform>().forward * Speed);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
               rb.AddForce(-GetComponent<Transform>().forward * Speed);




        if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, JumpForce, 0));
                NumberJumps += 1;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        NumberJumps = 0;
    }
    void OnCollisionExit(Collision other)
    {

    }
}
