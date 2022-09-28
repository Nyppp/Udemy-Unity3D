using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

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
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlacable = false;
        }
    }
}
