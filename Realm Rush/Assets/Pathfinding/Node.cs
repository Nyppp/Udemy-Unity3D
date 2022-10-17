using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������̺� ������� �ʴ� ���� C# Ŭ����
//Ÿ���� ��ǥ���� �׷��� �������� ��� �����ϱ� ���� ��� Ŭ���� �ۼ�
//�׷����� ���� ��ǥ����, ���̺�� ��Ÿ���� �� ������Ʈ���� ��ã��(BFS)�� ���� ��� Ž��

//�������̺� ������� �ʴ� Ŭ������ �ν����Ϳ� ǥ���ϱ� ���� �Ӽ� �ο�
[System.Serializable]
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;

    public bool isVisited;
    public bool isPath;

    public Node connectedTo;

    public Node(Vector2Int _coordinates, bool _isWakable) 
    {
        this.coordinates = _coordinates;
        this.isWalkable = _isWakable;
    }

}
