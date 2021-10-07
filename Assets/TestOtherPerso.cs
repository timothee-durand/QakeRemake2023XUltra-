using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOtherPerso : MonoBehaviour
{
    public int Health = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
