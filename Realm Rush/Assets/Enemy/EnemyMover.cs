using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
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
        
        //�±׸� ���� ������Ʈ Ž�� -> ���̾��Ű â ������� ����(Ʈ������ ����)
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        //Getchild ���
        /*int pathNum = parent.transform.childCount;

        for (int i = 0; i < pathNum; i++)
        {
            WayPoint wayPoint = parent.transform.GetChild(i).GetComponent<WayPoint>();
            if(wayPoint != null)
            {
                path.Add(wayPoint);
            }
        }*/

        //Ʈ������ ������ ���� �ڽ� ������Ʈ ������
        foreach (Transform child in parent.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();

            if(wayPoint != null)
            {
                path.Add(wayPoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
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

        FinishPath();
    }
}
