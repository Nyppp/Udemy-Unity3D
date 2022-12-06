using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

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
        if (isDead)
        {
            return;
        }

        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
