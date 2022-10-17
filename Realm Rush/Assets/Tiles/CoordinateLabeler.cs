using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

//�����͸��, �÷��� ��忡�� ��� �Ȱ��� ������ ���ִ� �Ӽ���
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.white;
    [SerializeField] Color visitedColor = Color.yellow;
    [SerializeField] Color pathColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();

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
            label.enabled = true;
            Time.timeScale = 5f;
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
        if (gridManager == null)
            return;

        Node node = gridManager.GetNode(coordinate);

        if (node == null) return;

        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isVisited)
        {
            label.color = visitedColor;
        }
        else
        {
            label.color = defaultColor;
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
