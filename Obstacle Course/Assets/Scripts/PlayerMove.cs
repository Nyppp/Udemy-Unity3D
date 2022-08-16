using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //SerializeFiled 속성 : private 변수를 인스펙터 창에 노출시키지만, 외부 스크립트의 수정은 불허하기 위해 사용
    /*[SerializeField]
    float xValue = 0f;
    [SerializeField]
    float yValue = 0f;
    [SerializeField]
    float zValue = 0f;*/

    //public은 바로 인스펙터 창에 나타나며, 다른 스크립트에서도 수정 가능
    public int moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstcution();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    //모노비헤이비어 상속으로 사용하는 Start나, Update들은 콜백함수이며,
    //사용자가 직접 스크립트에서 이처럼 함수를 작성하여 사용할 수 있다.
    void PrintInstcution()
    {
        Debug.Log("Welcom to the game");
        Debug.Log("Move your player with WASD or Arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {
        //Translate -> 매개변수로 주어진 벡터만큼, 액터의 트랜스폼에 더함
        //매개변수로 직접 값을 넣는 경우
        //transform.Translate(0.01f, 0, 0);

        //축 입력에 대해 입력값을 받아오고 벡터를 만들어 이동
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(xValue, 0, zValue);

        //매개변수로 변수를 넣어 사용하는 경우
        transform.Translate(moveVec * Time.deltaTime * moveSpeed);
    }

}
