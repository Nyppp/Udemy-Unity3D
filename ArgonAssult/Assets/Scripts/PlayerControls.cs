using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //키 입력에 따른 오브젝트 이동 코드

    //Input.GetAxis() -> 장치 의존적

    //혹은 InputAction.ReadValue<>() -> 장치에 의존적이지 않음,
    //편집기를 통해 입력액션 매핑 가능

    //[SerializeField] InputAction movement;

    [Header("General Settings")]
    [Tooltip("How Fast Ship moves Up and Down")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [Header("Laser Effect Array")]
    [Tooltip("Add all lasers here")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based Tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based Tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -10f;

    float xMove;
    float yMove;

    //인풋액션을 사용하면 enable과 disable 시에 활성, 비활성을 맞춰서 해야 한다.
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        //movement.Disable();
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

        //InputAction을 사용한 입력 시스템
        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //float verticalThrow = movement.ReadValue<Vector2>().y;
    }

    private void ProcessFiring()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            SetParticleActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SetParticleActive(false);
        }
    }

    private void SetParticleActive(bool isActive)
    {
        foreach (var laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlMove = yMove * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlMove;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xMove * controlRollFactor;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(pitch, yaw, roll), Time.deltaTime * 10f);
    }

    private void ProcessTranslation()
    {
        //기존 유니티 입력 시스템(로컬좌표 직접 수정)
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        float xOffset = xMove * Time.deltaTime * moveSpeed;
        float rawXPos = transform.localPosition.x + xOffset;

        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yMove * Time.deltaTime * moveSpeed;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition =
            new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }
}
