using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //배열과 리스트의 차이
    //크기 : 배열 - 고정적 / 리스트 - 가변적
    //속도 : 배열 - 빠름 / 리스트 - 크기, 사용에 따라 다름

    //리스트는 힙공간에 불연속적으로 데이터가 쌓이게 된다.
    //스택 구조에서 리스트를 접근하는 경우, 메모리 캐싱과정이 오래 걸릴 수 있음

    //리스트와 배열은 모두 탐색 시 참조를 정확히 하지 않고 임시 변수를 사용하면
    //많은 가비지 컬렉션을 유발하기 때문에 참조를 이용해 최대한 GC를 방지해야 한다.

    [SerializeField] List<WayPoint> path = new List<WayPoint>();

    [Range(0f,5f)]
    [SerializeField] float speed = 1f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();
        
        //태그를 통한 오브젝트 탐색 -> 하이어라키 창 순서대로 정렬
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<WayPoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position; 
            Vector3 endPosition = waypoint.transform.position;

            float travelPercent = 0f;


            transform.LookAt(endPosition);
            
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

                yield return new WaitForEndOfFrame();
            }
        }

        gameObject.SetActive(false);
        enemy.StealGold();
    }
}
