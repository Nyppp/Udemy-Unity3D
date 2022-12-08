using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamagedTaken()
    {
        Debug.Log(name + " damaged");
    }

    public void AttackHitEvent()
    {
        if(target == null)
        {
            return;
        }
        
        target.GetComponent<PlayerHealth>().TakeDamage(damage);

        Debug.Log("플레이어가 공격당함");
    }
}
