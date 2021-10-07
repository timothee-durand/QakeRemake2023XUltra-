using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLaunchBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletLaunchPoint;
    public float speedBullet = 1000f;
    public GameObject particles;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Transform>().position = bulletLaunchPoint.position;
            bullet.GetComponent<Rigidbody>().AddForce(GetComponent<Transform>().forward * speedBullet);
            Destroy(bullet, 100f);
        }
    }
}
