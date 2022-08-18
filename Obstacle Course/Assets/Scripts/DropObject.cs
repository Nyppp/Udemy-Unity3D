using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    Rigidbody rigid;
    MeshRenderer meshRenderer;

    //Ư�� �ð��� ���� �ڿ� �Լ��� �����ϴ� ���
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;

        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

        //Invoke�� ����ؼ� �Լ��� Ư�� �ð� ���� ȣ���ϴ� ���
        //Invoke("Drop", 3);

        //�ڷ�ƾ ���
        StartCoroutine(CoroutineDrop());

        //Invoke�� �ڷ�ƾ�� ����
        //Invoke : ������Ʈ�� active ���ο� ������� Ư�� �ð� ���� �����ϰų� �ݺ������� �����Ѵ�.
        //��Ʈ�� ����Ʈ�� Ư�� �ð��� �ٽ� ������ �� ����.

        //�ڷ�ƾ : ������Ʈ�� active false�� �Ǹ�, �ڷ�ƾ ���۵� �ߴܵȴ�.
        //�ڷ�ƾ �������� �����ƾ�� ����� �پ��� ������ �̾�� �� ������, �ð��� ���� �������� ���氡���ϴ�.
    }

    void Drop()
    {
        rigid.useGravity = true;
        meshRenderer.enabled = true;
    }
    
    //�⺻���� �ڷ�ƾ ����
    IEnumerator CoroutineDrop()
    {
        yield return new WaitForSeconds(3);
        Drop();
    }
}
