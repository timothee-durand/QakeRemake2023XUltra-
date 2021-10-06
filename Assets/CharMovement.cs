using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{

   public float Speed;
   public float JumpForce;
   public int Health;

   // Start is called before the first frame update

   void Start()
   {
       GetComponent<Transform>().position = new Vector3(0, 0, 0);
   }

   // Update is called once per frame
   void Update()
   {
       if (Input.GetKey(KeyCode.RightArrow))
           GetComponent<Transform>().Rotate(new Vector3(0, 1, 0));

       if (Input.GetKey(KeyCode.LeftArrow))
           GetComponent<Transform>().Rotate(new Vector3(0, -1, 0));

       if (Input.GetKey(KeyCode.UpArrow))
           GetComponent<Rigidbody>().AddForce(GetComponent<Transform>().forward * Speed);

       if (Input.GetKey(KeyCode.DownArrow))
           GetComponent<Rigidbody>().AddForce(-GetComponent<Transform>().forward * Speed);

       if (Input.GetKey(KeyCode.Space))
           GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
    }
}