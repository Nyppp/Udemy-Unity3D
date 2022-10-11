using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GetComponent 이전에 오브젝트가 삭제되는 경우, 에러가 발생함
//이를 방지하기 위해 오브젝트에게 이 컴포넌트가 반드시 붙어있도록 속성값 부여
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
