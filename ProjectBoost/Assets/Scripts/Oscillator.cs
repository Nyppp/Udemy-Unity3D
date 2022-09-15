using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField]
    Vector3 destPos;
    float factor;
    [SerializeField]
    float period = 2f;

    private void Start()
    {
        startPos = transform.position;
        destPos = new Vector3(10, 0, 0);
    }

    private void Update()
    {
        if (period > Mathf.Epsilon)
        {
            //실제 시간의 흐름을 주기로 나누고, 라디안 값에 sin함수를 취해
            //오브젝트가 특정 주기에 따라 움직이게 한다
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 2;

            float rawSinWave = Mathf.Sin(tau * cycles);

            factor = (rawSinWave + 1f) / 2f;

            Vector3 offset = (destPos * factor);

            transform.position = startPos + offset;
        }
    }
}
