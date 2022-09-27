using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

//�����͸��, �÷��� ��忡�� ��� �Ȱ��� ������ ���ִ� �Ӽ���
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinate();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            //������ ��忡���� ����
            DisplayCoordinate();
            UpdateObejctName();
        }
    }

    void DisplayCoordinate()
    {
        //���� ��ǥ / ������ ���� ���� ũ��� ������, ���ϴ� ��ǥ���� �� �� ����
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinate.x},{coordinate.y}";
    }

    void UpdateObejctName()
    {
        transform.parent.name = coordinate.ToString();
    }
}
