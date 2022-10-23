using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    //private 변수에 대한 접근 방법
    [SerializeField] bool isPlacable;
    //프로퍼티를 통해 get, set 선언
    public bool IsPlacable { get { return isPlacable; } }

    //getter, setter함수를 통한 접근
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

            //타워 배치가 불가능한 공간 = 나무, 벽, 물가 등이 있기에 경로로 지정할 수 없음
            if(!IsPlacable)
            {
                //BlockNode로 지정해서 경로에서 제외시킨다.
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        //설치가 유효한 타일이며, 이곳에 설치하면 적이 이동할 경로가 없어지는지 체크
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
