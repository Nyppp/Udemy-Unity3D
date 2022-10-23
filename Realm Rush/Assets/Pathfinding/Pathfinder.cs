using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    //출발지, 목적지에 대한 getter 프로퍼티
    public Vector2Int StartCoordinates { get { return startCoordinates; } }
    public Vector2Int DestinationCoordinates { get { return destinationCoordinates; } }

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    //방문 여부를 저장하는 딕셔너리
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Queue<Node> frontier = new Queue<Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    
    GridManager gridManager;

    //웨이브 이동 경로범위에 대한 모든 좌표정보
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            //유니티 프로젝트 설정에서, 스크립트 실행 순서를 임의로 설정 가능
            //현재 설정은, 그리드매니저 -> 패스파인더 -> 그 외 코드들의 실행 순서로,
            //Awake에서 그리드매니저를 불러와도 그리드매니저가 가장 먼저 실행되어 초기화되기에
            //문제가 발생하지 않음. 그러나 순서를 설정하지 않으면 초기화 오류 발생.
            grid = gridManager.Grid;
            startNode = grid[startCoordinates];
            destinationNode = grid[destinationCoordinates];
        }
    }


    void Start()
    {
        startNode = gridManager.Grid[startCoordinates];
        destinationNode = gridManager.Grid[destinationCoordinates];

        GetNewPath();
    }

    //시작점에서 경로를 재설정 하는 함수와, 중간 지점에서 재설정하는 함수
    //오버로딩을 사용해 구현
    public List<Node> GetNewPath()
    {
        return GetNewPath(startCoordinates);
    }

    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetNode();
        BFS(coordinates);
        return BuildPath();
    }

    //길찾기 알고리즘에서 큐에 경로가 될 수 있는 타일정보를 모두 삽입
    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int dir in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + dir;

            if(grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
            }
        }

        foreach (Node neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    //길찾기 알고리즘 - 최단경로 탐색(큐를 사용한 BFS)
    void BFS(Vector2Int coordinates)
    {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;

        frontier.Clear();
        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(grid[coordinates]);
        reached.Add(coordinates, grid[coordinates]);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isVisited = true;
            ExploreNeighbors();

            if(currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }

    //타일들은 모두 다음 경로가 어디인지 가리키는 connectedTo를 가지고 있음
    //만약 경로가 아니라면, 이 값은 null임. -> 이 값들을 모두 저장하면, 적이 이동하는 경로가 됨
    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            bool prevState = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = prevState;

            //BFS로 경로 탐색 시, 경로가 가로막히면 목적지 단 한개만을 경로로 설정하게 되어
            //최단거리가 1 이하인 경로가 반환됨. 이는 길이 가로막힌 경우로 예외처리
            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }

        return false;
    }

    //브로드캐스트메시지 -> 모노비헤이비어를 상속하는 모든 객체에게 이 함수를 실행하라는 메시지 전송
    //해당 함수를 가지고 있는 객체는 메세지를 받고, 함수를 실행하게 된다.
    //센드메시지는 이 메시지를 전달하는 오브젝트와 붙어있는 오브젝트만,
    //브로드캐스트메시지는 씬 전체의 오브젝트에게(모든 모노비헤이비어 오브젝트) 전달한다.
    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false , SendMessageOptions.DontRequireReceiver);
    }
}
