using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    //�����, �������� ���� getter ������Ƽ
    public Vector2Int StartCoordinates { get { return startCoordinates; } }
    public Vector2Int DestinationCoordinates { get { return destinationCoordinates; } }

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    //�湮 ���θ� �����ϴ� ��ųʸ�
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Queue<Node> frontier = new Queue<Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    
    GridManager gridManager;

    //���̺� �̵� ��ι����� ���� ��� ��ǥ����
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            //����Ƽ ������Ʈ ��������, ��ũ��Ʈ ���� ������ ���Ƿ� ���� ����
            //���� ������, �׸���Ŵ��� -> �н����δ� -> �� �� �ڵ���� ���� ������,
            //Awake���� �׸���Ŵ����� �ҷ��͵� �׸���Ŵ����� ���� ���� ����Ǿ� �ʱ�ȭ�Ǳ⿡
            //������ �߻����� ����. �׷��� ������ �������� ������ �ʱ�ȭ ���� �߻�.
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

    //���������� ��θ� �缳�� �ϴ� �Լ���, �߰� �������� �缳���ϴ� �Լ�
    //�����ε��� ����� ����
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

    //��ã�� �˰��򿡼� ť�� ��ΰ� �� �� �ִ� Ÿ�������� ��� ����
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

    //��ã�� �˰��� - �ִܰ�� Ž��(ť�� ����� BFS)
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

    //Ÿ�ϵ��� ��� ���� ��ΰ� ������� ����Ű�� connectedTo�� ������ ����
    //���� ��ΰ� �ƴ϶��, �� ���� null��. -> �� ������ ��� �����ϸ�, ���� �̵��ϴ� ��ΰ� ��
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

            //BFS�� ��� Ž�� ��, ��ΰ� ���θ����� ������ �� �Ѱ����� ��η� �����ϰ� �Ǿ�
            //�ִܰŸ��� 1 ������ ��ΰ� ��ȯ��. �̴� ���� ���θ��� ���� ����ó��
            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }

        return false;
    }

    //��ε�ĳ��Ʈ�޽��� -> �������̺� ����ϴ� ��� ��ü���� �� �Լ��� �����϶�� �޽��� ����
    //�ش� �Լ��� ������ �ִ� ��ü�� �޼����� �ް�, �Լ��� �����ϰ� �ȴ�.
    //����޽����� �� �޽����� �����ϴ� ������Ʈ�� �پ��ִ� ������Ʈ��,
    //��ε�ĳ��Ʈ�޽����� �� ��ü�� ������Ʈ����(��� �������̺�� ������Ʈ) �����Ѵ�.
    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false , SendMessageOptions.DontRequireReceiver);
    }
}
