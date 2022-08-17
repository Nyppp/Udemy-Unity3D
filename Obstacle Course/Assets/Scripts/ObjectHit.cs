using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color defaultColor;

    void Awake()
    {
        //GetComponent : ��ũ��Ʈ�� ����ϴ� ������Ʈ�� ������Ʈ�� �����´�.(���׸� ����)
        meshRenderer = GetComponent<MeshRenderer>();

        defaultColor = meshRenderer.material.color;
    }

    void Update()
    {
        
    }

    //�浹�� ���� ����Ƽ �ݹ��Լ�
    //OnCollisionEnter : �浹�� ������ �� ����
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            meshRenderer.material.color = new Color(1, 0, 0);
        }
    }

    //OnCollisionExit : �浹���� ��� �� ����
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            meshRenderer.material.color = defaultColor;
        }
    }
}
