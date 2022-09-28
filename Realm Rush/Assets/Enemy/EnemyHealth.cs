using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currnetHitPoints = 0;

    private void Start()
    {
        currnetHitPoints = maxHitPoints;
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
        }
    }
}
