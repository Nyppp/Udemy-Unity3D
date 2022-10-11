using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GetComponent ������ ������Ʈ�� �����Ǵ� ���, ������ �߻���
//�̸� �����ϱ� ���� ������Ʈ���� �� ������Ʈ�� �ݵ�� �پ��ֵ��� �Ӽ��� �ο�
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Enemy Health Point")]
    [SerializeField] int maxHitPoints = 5;
    int currnetHitPoints = 0;

    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    Enemy enemy;

    private void OnEnable()
    {
        currnetHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        --currnetHitPoints;

        if(currnetHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
