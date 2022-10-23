using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    //private ������ ���� ���� ���
    [SerializeField] bool isPlacable;
    //������Ƽ�� ���� get, set ����
    public bool IsPlacable { get { return isPlacable; } }

    //getter, setter�Լ��� ���� ����
    /*public bool GetIsPlacable()
    {
        return isPlacable;
    }*/

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            //Ÿ�� ��ġ�� �Ұ����� ���� = ����, ��, ���� ���� �ֱ⿡ ��η� ������ �� ����
            if(!IsPlacable)
            {
                //BlockNode�� �����ؼ� ��ο��� ���ܽ�Ų��.
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        //��ġ�� ��ȿ�� Ÿ���̸�, �̰��� ��ġ�ϸ� ���� �̵��� ��ΰ� ���������� üũ
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);

            if (isSuccessful)
            {
                gridManager.BlockNode(coordinates);
            }

            pathfinder.NotifyReceivers();
        }
    }
}
