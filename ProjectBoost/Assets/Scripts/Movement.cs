using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigid;

    public float jumpPower;
    public float rotatePower;

    float rotateFlag;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rotateFlag = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //기본 input에 대한 바인딩
        ProcessThrust();
        ProcessRotation();
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotatePower * rotateFlag);
    }

    void ProcessThrust()
    {
        if(Input.GetButton("Jump"))
        {
            rigid.AddRelativeForce(Vector3.up * jumpPower * Time.deltaTime);
        }
    }


    //회전 입력을 프레임에 독립적으로 사용하기 위해 키 입력은 Update문에서, 회전동작은 FixedUpdate에서 사용
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rotateFlag = 1;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rotateFlag = -1;
        }
        else
        {
            rotateFlag = 0;
        }
    }
}
