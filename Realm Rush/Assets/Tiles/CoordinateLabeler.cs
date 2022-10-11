using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

//에디터모드, 플레이 모드에서 모두 똑같은 실행을 해주는 속성값
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
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
            //에디터 모드에서만 실행
            DisplayCoordinate();
            UpdateObejctName();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    private void SetLabelColor()
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
        //현재 좌표 / 에디터 기준 스냅 크기로 나누면, 원하는 좌표값을 얻어낼 수 있음
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinate.x},{coordinate.y}";
    }

    void UpdateObejctName()
    {
        transform.parent.name = coordinate.ToString();
    }
}
