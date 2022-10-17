using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//모노비헤이비어를 상속하지 않는 순수 C# 클래스
//타일의 좌표들을 그래프 형식으로 묶어서 관리하기 위해 노드 클래스 작성
//그래프로 묶은 좌표들은, 웨이브로 나타나는 적 오브젝트들이 길찾기(BFS)를 통해 경로 탐색

//모노비헤이비어를 상속하지 않는 클래스를 인스펙터에 표시하기 위한 속성 부여
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
