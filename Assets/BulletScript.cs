using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage = 10;
    public GameObject particles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TestOtherPerso otherPlayer = collision.gameObject.GetComponent<TestOtherPerso>();

            if (otherPlayer)
            {
                otherPlayer.Health -= damage;
                GameObject particle = Instantiate(particles);
                particle.GetComponent<Transform>().position = collision.GetContact(0).point;
                Destroy(particle, 5f);
            }
        }
        Destroy(gameObject);


    }
}