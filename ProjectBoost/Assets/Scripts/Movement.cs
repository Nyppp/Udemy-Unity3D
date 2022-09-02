using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audioSource;

    public float jumpPower;
    public float rotatePower;

    public AudioClip engineSound;

    public ParticleSystem mainBoost;
    public ParticleSystem leftBoost;
    public ParticleSystem rightBoost;

    float rotateFlag;
    float rotateAngle;
    bool isAlive;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rotateFlag = 0f;
        rotateAngle = 0f;
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void FixedUpdate()
    {
        RotateFixed();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }
    
    void StartThrust()
    {
        rigid.AddRelativeForce(Vector3.up * jumpPower * Time.deltaTime);

        if (!mainBoost.isPlaying)
        {
            mainBoost.Play();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineSound);
        }
    }

    void StopThrust()
    {
        mainBoost.Stop();
        audioSource.Stop();
    }

    

    void RotateFixed()
    {
        if (rotateFlag == 0)
        {
            rigid.freezeRotation = true;
        }
        else
        {
            rigid.freezeRotation = false;
            rotateAngle += rotateFlag;
            transform.rotation = Quaternion.Euler(0, 0, rotateAngle);
        }
    }

    //회전 입력을 프레임에 독립적으로 사용하기 위해 키 입력은 Update문에서, 회전동작은 FixedUpdate에서 사용
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotate();
        }
    }

    void StopRotate()
    {
        leftBoost.Stop();
        rightBoost.Stop();

        rotateFlag = 0;
    }

    void RotateRight()
    {
        rotateFlag = -1;

        if (!rightBoost.isPlaying)
        {
            rightBoost.Play();
        }
    }

    void RotateLeft()
    {
        rotateFlag = 1;

        if (!leftBoost.isPlaying)
        {
            leftBoost.Play();
        }
    }
}
