using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    Rigidbody rigid;
    //특정 시간이 지난 뒤에 함수를 실행하는 방법
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;

        //Invoke를 사용해서 함수를 특정 시간 이후 호출하는 방법
        //Invoke("Drop", 3);

        //코루틴 사용
        StartCoroutine(CoroutineDrop());

        //Invoke와 코루틴의 차이
        //Invoke : 오브젝트의 active 여부에 상관없이 특정 시간 이후 수행하거나 반복적으로 수행한다.
        //엔트리 포인트나 특정 시간을 다시 정의할 수 없다.

        //코루틴 : 오브젝트가 active false가 되면, 코루틴 동작도 중단된다.
        //코루틴 내에서도 서브루틴을 만들어 다양한 갈래로 이어나갈 수 있으며, 시간도 내부 동작으로 변경가능하다.
    }

    void Drop()
    {
        rigid.useGravity = true;
    }
    
    //기본적인 코루틴 구조
    IEnumerator CoroutineDrop()
    {
        yield return new WaitForSeconds(3);
        Drop();
    }
}
