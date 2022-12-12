using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float batteryAmount = 50f;
    [SerializeField] float angleAmount = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FlashLightSystem>().RestoreLightIntensity(batteryAmount);
            other.gameObject.GetComponent<FlashLightSystem>().RestoreLightAngle(angleAmount);
            Destroy(gameObject);
        }
    }
}
