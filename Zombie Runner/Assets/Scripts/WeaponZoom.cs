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

    [SerializeField] RigidbodyFirstPersonController fpsController;

    private void Start()
    {
        //fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        cameraView.fieldOfView = Mathf.Lerp(cameraView.fieldOfView, zoomFov, 0.1f);
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    void ZoomOut()
    {
        cameraView.fieldOfView = Mathf.Lerp(cameraView.fieldOfView, defaultFov, 0.1f);
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void OnDisable()
    {
        cameraView.fieldOfView = defaultFov;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

}
