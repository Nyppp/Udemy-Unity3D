using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //�迭�� ����Ʈ�� ����
    //ũ�� : �迭 - ������ / ����Ʈ - ������
    //�ӵ� : �迭 - ���� / ����Ʈ - ũ��, ��뿡 ���� �ٸ�

    //����Ʈ�� �������� �ҿ��������� �����Ͱ� ���̰� �ȴ�.
    //���� �������� ����Ʈ�� �����ϴ� ���, �޸� ĳ�̰����� ���� �ɸ� �� ����

    //����Ʈ�� �迭�� ��� Ž�� �� ������ ��Ȯ�� ���� �ʰ� �ӽ� ������ ����ϸ�
    //���� ������ �÷����� �����ϱ� ������ ������ �̿��� �ִ��� GC�� �����ؾ� �Ѵ�.

    [SerializeField] List<WayPoint> path = new List<WayPoint>();

    [Range(0f,5f)]
    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();
        
        //�±׸� ���� ������Ʈ Ž�� -> ���̾��Ű â ������� ����
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
    }
}
