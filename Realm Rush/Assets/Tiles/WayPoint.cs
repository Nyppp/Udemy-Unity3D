using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    //private ������ ���� ���� ���
    [SerializeField] bool isPlacable;

    //������Ƽ�� ���� get, set ����
    public bool IsPlacable
    {
        get { return isPlacable; }
    }

    //getter, setter�Լ��� ���� ����
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
