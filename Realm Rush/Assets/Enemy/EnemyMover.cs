using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    //배열과 리스트의 차이
    //크기 : 배열 - 고정적 / 리스트 - 가변적
    //속도 : 배열 - 빠름 / 리스트 - 크기, 사용에 따라 다름

    //리스트는 힙공간에 불연속적으로 데이터가 쌓이게 된다.
    //스택 구조에서 리스트를 접근하는 경우, 메모리 캐싱과정이 오래 걸릴 수 있음

    //리스트와 배열은 모두 탐색 시 참조를 정확히 하지 않고 임시 변수를 사용하면
    //많은 가비지 컬렉션을 유발하기 때문에 참조를 이용해 최대한 GC를 방지해야 한다.
    [SerializeField] List<Node> path = new List<Node>();

    [Range(0f,5f)]
    [SerializeField] float speed = 1f;

    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void FindPath()
    {
        path.Clear();

        path = pathfinder.GetNewPath();

    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
        
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for(int i = 0; i < path.Count; ++i)
        {
            Vector3 startPosition = transform.position; 
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);

            float travelPercent = 0f;


            transform.LookAt(endPosition);
            
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
