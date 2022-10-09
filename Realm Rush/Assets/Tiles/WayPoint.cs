using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    //private 변수에 대한 접근 방법
    [SerializeField] bool isPlacable;

    //프로퍼티를 통해 get, set 선언
    public bool IsPlacable
    {
        get { return isPlacable; }
    }

    //getter, setter함수를 통한 접근
    /*public bool GetIsPlacable()
    {
        return isPlacable;
    }*/

    void OnMouseDown()
    {
        if (isPlacable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlacable = !isPlaced;
        }
    }
}
