using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputs : MonoBehaviour
{
    public GameObject inventoryGO;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("OpenInventory"))
        {
            inventoryGO.SetActive(!inventoryGO.activeSelf);
        }
    }
}
