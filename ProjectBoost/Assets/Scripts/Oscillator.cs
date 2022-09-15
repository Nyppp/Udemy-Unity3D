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
            //���� �ð��� �帧�� �ֱ�� ������, ���� ���� sin�Լ��� ����
            //������Ʈ�� Ư�� �ֱ⿡ ���� �����̰� �Ѵ�
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 2;

            float rawSinWave = Mathf.Sin(tau * cycles);

            factor = (rawSinWave + 1f) / 2f;

            Vector3 offset = (destPos * factor);

            transform.position = startPos + offset;
        }
    }
}
