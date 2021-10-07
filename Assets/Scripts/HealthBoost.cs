using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public int boostValue;
    public int maxHealth = 200;
    public float boostDisabledTime = 10f;
    public GameObject marker;
    public Light halo;
    public Material materialDisabled;
    public Color colorDisabled;

    private bool isBonus = false;
    private float timer = 0f;
    private TestMovementScript boost;
    private Material materialNormal;
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
        if (isBonus)
        {
            timer += Time.deltaTime;

            if (timer >= boostDisabledTime)
            {
                timer = 0f;
                isBonus = false;
                SetDisabled(false);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isBonus)
        {
            boost = other.gameObject.GetComponent<TestMovementScript>();
            if (boost)
            {
                boost.Health += boostValue;
                boost.Health = Mathf.Clamp(boost.Health, 0, maxHealth);
                Debug.Log("Life " + boost.Health);
                isBonus = true;
                SetDisabled(true);
            }
        }
    }

    private void SetDisabled(bool value)
    {
        if (value)
        {
            halo.color = colorDisabled;
            markerRenderer.material = materialDisabled;
        }
        else
        {
            halo.color = colorNormal;
            markerRenderer.material = materialNormal;
        }
    }
}
