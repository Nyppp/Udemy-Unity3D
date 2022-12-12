using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light playerLight;

    private void Start()
    {
        playerLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float reastoreAngle)
    {
        playerLight.spotAngle = reastoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        playerLight.intensity += intensityAmount;
    }

    private void DecreaseLightIntensity()
    {
        playerLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (playerLight.spotAngle <= minAngle)
        {
            return;
        }
        else
        {
            playerLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
}
