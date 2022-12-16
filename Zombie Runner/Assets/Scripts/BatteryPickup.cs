using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float batteryAmount = 1f;
    [SerializeField] float angleAmount = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(batteryAmount);
            other.gameObject.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(angleAmount);
            Destroy(gameObject);
        }
    }
}
