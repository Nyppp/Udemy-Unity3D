using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color defaultColor;

    void Awake()
    {
        //GetComponent : 스크립트를 사용하는 오브젝트의 컴포넌트를 가져온다.(제네릭 형식)
        meshRenderer = GetComponent<MeshRenderer>();

        defaultColor = meshRenderer.material.color;
    }

    void Update()
    {
        
    }

    //충돌에 관한 유니티 콜백함수
    //OnCollisionEnter : 충돌을 시작할 때 동작
    private void OnCollisionEnter(Collision collision)
    {
        meshRenderer.material.color = new Color(1, 0, 0);
        
    }

    //OnCollisionExit : 충돌에서 벗어날 때 동작
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
