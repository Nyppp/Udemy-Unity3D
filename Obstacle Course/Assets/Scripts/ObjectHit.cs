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

    //�浹�� ���� ����Ƽ �ݹ��Լ�
    //OnCollisionEnter : �浹�� ������ �� ����
    private void OnCollisionEnter(Collision collision)
    {
        //�±׸� ����� �浹 ������Ʈ�� ���� ����
        if (collision.gameObject.tag == "Player")
        {
            meshRenderer.material.color = new Color(1, 0, 0);
            gameObject.tag = "Hit";
        }
    }

    //OnCollisionExit : �浹���� ��� �� ����
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
