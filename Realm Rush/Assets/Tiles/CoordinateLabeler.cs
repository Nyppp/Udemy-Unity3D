using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

//�����͸��, �÷��� ��忡�� ��� �Ȱ��� ������ ���ִ� �Ӽ���
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.white;

    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    WayPoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<WayPoint>();

        label.enabled = false;

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

        ColorCoordinates();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    private void ColorCoordinates()
    {
        if(waypoint.IsPlacable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
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
