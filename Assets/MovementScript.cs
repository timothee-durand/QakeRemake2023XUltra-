using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float jumpForce = 1f;
    public int Health = 100;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Rigidbody rBody = GetComponent<Rigidbody>();
        Transform tr = GetComponent<Transform>();
        if (Input.GetKey(KeyCode.D))
            tr.Rotate(new Vector3(0, 1, 0));
        if (Input.GetKey(KeyCode.Q))
            tr.Rotate(new Vector3(0, -1, 0));
        if (Input.GetKey(KeyCode.Z))
            rBody.AddForce(tr.forward * speed);
        if (Input.GetKey(KeyCode.S))
            rBody.AddForce(tr.forward * -speed);
        if (Input.GetKey(KeyCode.Space))
            rBody.AddForce(new Vector3(0, this.jumpForce, 0));
    }
}
