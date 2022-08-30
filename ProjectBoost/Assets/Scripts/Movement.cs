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
        //�⺻ input�� ���� ���ε�
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


    //ȸ�� �Է��� �����ӿ� ���������� ����ϱ� ���� Ű �Է��� Update������, ȸ�������� FixedUpdate���� ���
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
