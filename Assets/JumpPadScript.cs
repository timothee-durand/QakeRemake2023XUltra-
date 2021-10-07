using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public float jumpForce = 1000f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
         
            Rigidbody rBody = other.gameObject.GetComponent<Rigidbody>();
            
            rBody.AddForce(other.gameObject.transform.up * jumpForce);
        }
        
    }
  
}
