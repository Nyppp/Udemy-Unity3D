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

    public List<Node> GetNewPath()
    {
        gridManager.ResetNode();
        BFS();

        return BuildPath();
    }


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

    void BFS()
    {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;

        frontier.Clear();
        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

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
}
