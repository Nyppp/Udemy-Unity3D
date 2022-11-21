using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;

        BroadcastMessage("OnDamagedTaken");
        
        if (hitPoints <= 0f) 
        {
            SetDead();
        }
    }

    private void SetDead()
    {
        gameObject.SetActive(false);
    }
}
