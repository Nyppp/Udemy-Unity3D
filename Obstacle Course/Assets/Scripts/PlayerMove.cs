using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //SerializeFiled �Ӽ� : private ������ �ν����� â�� �����Ű����, �ܺ� ��ũ��Ʈ�� ������ �����ϱ� ���� ���
    /*[SerializeField]
    float xValue = 0f;
    [SerializeField]
    float yValue = 0f;
    [SerializeField]
    float zValue = 0f;*/

    //public�� �ٷ� �ν����� â�� ��Ÿ����, �ٸ� ��ũ��Ʈ������ ���� ����
    public int moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Translate -> �Ű������� �־��� ���͸�ŭ, ������ Ʈ�������� ����
        //�Ű������� ���� ���� �ִ� ���
        //transform.Translate(0.01f, 0, 0);

        //�� �Է¿� ���� �Է°��� �޾ƿ��� ���͸� ����� �̵�
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(xValue, 0, zValue);

        //�Ű������� ������ �־� ����ϴ� ���
        transform.Translate(moveVec * Time.deltaTime * moveSpeed);
    }
}
