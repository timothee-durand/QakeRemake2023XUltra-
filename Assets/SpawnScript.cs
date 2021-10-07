using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject spawn;
    public GameObject[] respawnPlaces;

    void Start()
    {
        respawnPlaces = GameObject.FindGameObjectsWithTag("Respawn");
        GetComponent<Transform>().position = respawnPlaces[0].GetComponent<Transform>().position;
        respawnPlaces[0].tag = "Untagged";
        StartCoroutine("resetSpawn");
    }

    IEnumerator resetSpawn()
    {
        yield return new WaitForSeconds(5f);
        respawnPlaces[0].tag = "Respawn";
    }
}
