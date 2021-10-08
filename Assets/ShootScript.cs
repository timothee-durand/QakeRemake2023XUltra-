using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ProjectilePrefab;
    public Transform Weapon;

    public int IdWeapon = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (IdWeapon)
            {
                case 0:
                    GameObject Projectile = Instantiate(ProjectilePrefab);
                    Projectile.GetComponent<Transform>().position
                        =
                        Weapon.GetComponent<Transform>().position;
                    Projectile.GetComponent<Rigidbody>().AddForce(GetComponent<Transform>().forward * 1000);
                    Destroy(Projectile, 20);
                    break;
                case 1:
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject Projectile2 = Instantiate(ProjectilePrefab);
                        Projectile2.GetComponent<Transform>().position
                            =
                            Weapon.GetComponent<Transform>().position;

                        Vector3 Delta = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));

                        Projectile2.GetComponent<Rigidbody>().AddForce((GetComponent<Transform>().forward + Delta) * 200);
                        Destroy(Projectile2, 20);
                    }
                   
                    break;
            }
                
        }

    }
}
