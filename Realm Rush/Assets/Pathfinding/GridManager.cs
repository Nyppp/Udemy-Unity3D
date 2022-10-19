using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;

    [Tooltip("유니티 에디터에서의 스냅 크기")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

    //타일의 실제 좌표벡터를 키로 가지고, 타일 정보를 담은 Node를 값으로 하는 딕셔너리 생성
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public void ResetNode()
    {
        foreach (KeyValuePair<Vector2Int, Node> entry  in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isVisited = false;
            entry.Value.isPath = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinate = new Vector2Int();

        coordinate.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinate.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinate;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinate)
    {
        Vector3 position = new Vector3();

        position.x = coordinate.x * unityGridSize;
        position.z = coordinate.y * unityGridSize;

        return position;
    }

    private void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; ++x)
        {
            for(int y = 0; y < gridSize.y; ++y)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}
