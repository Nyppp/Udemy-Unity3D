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

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    //인풋액션을 사용하면 enable과 disable 시에 활성, 비활성을 맞춰서 해야 한다.
    private void OnEnable()
    {
        //movement.Enable();
    }

    private void OnDisable()
    {
        //movement.Disable();
    }

    void Update()
    {
        //기존 유니티 입력 시스템(로컬좌표 직접 수정)
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        float xOffset = xMove * Time.deltaTime * moveSpeed;
        float rawXPos = transform.localPosition.x + xOffset;

        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yMove * Time.deltaTime * moveSpeed;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition =
            new Vector3(clampXPos, clampYPos, transform.localPosition.z);

        //InputAction을 사용한 입력 시스템
        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //float verticalThrow = movement.ReadValue<Vector2>().y;
    }
}
