using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("플레이어 체력 : " + health);
        GetComponent<DisplayDamage>().EnableHitEffect();

        if(health <= 0f)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}

