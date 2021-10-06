using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public string bonusName;
    public int bonusValue;
    public float boostTime = 10f;
    private bool isBonus = false;

    private float timer = 0f;
    private float originalValue = -1f;
    private MovementScript boost;

    public GameObject marker;
    public Light halo;
    public Material materialDisabled;
    private Material materialNormal;
    public Color colorDisabled;
    private Color colorNormal;
    private MeshRenderer markerRenderer;
    private AnimationScript markerAnimationScript;
   

    public void Start()
    {
        markerRenderer = marker.GetComponent<MeshRenderer>();
        markerAnimationScript = marker.GetComponent<AnimationScript>();
        materialNormal = markerRenderer.material;
        colorNormal = halo.color;
    }

    private void Update()
    {
        if(isBonus)
        {
            timer += Time.deltaTime;

            if (timer >= boostTime)
            {
                timer = 0f;
                isBonus = false;
                boost.speed = originalValue;
                SetDisabled(false);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isBonus)
        {
            boost = other.gameObject.GetComponent<MovementScript>();
            if(boost)
            {
                originalValue = boost.speed;
                boost.speed = originalValue + bonusValue;
                isBonus = true;
                SetDisabled(true);
            }
        }
    }

    private void SetDisabled (bool value)
    {
        if(value)
        {
            halo.color = colorDisabled;
            markerRenderer.material = materialDisabled;
        } else
        {
            halo.color = colorNormal;
            markerRenderer.material = materialNormal;
        }
    }
}
