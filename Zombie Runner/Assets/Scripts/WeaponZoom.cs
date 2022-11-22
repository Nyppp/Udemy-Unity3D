using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraView;
    [SerializeField] float zoomFov = 30f;
    [SerializeField] float defaultFov = 60f;

    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    RigidbodyFirstPersonController fpsController;

    private void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            cameraView.fieldOfView = Mathf.Lerp(cameraView.fieldOfView, zoomFov, 0.1f);
            fpsController.mouseLook.XSensitivity = zoomInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomInSensitivity;
            
        }
        else
        {
            cameraView.fieldOfView = Mathf.Lerp(cameraView.fieldOfView, defaultFov, 0.1f);
            fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
        }
    }
}
