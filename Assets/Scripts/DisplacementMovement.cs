using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -19.62f;
    public float jumpHeight = .5f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float waitTime = 1f;

    public LayerMask groundMask;
    bool isGrounded;
    bool isWait;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        groundCheck = GetComponent<Transform>();
        isWait = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKey(KeyCode.Space))
        {

            if (isWait == false)
            {
                StartCoroutine("waitingJump");
            }

        }

    }

    public IEnumerator waitingJump()
    {

        isWait = true;
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        yield return new WaitForSeconds(waitTime);

        isWait = !isWait;
    }
}