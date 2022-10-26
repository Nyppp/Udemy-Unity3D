using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        { 
            Debug.Log(hit.transform.name);

            // TODO : 히트 이펙트, 총알 맞는 사운드 추가

            // 적이 총에 맞은 경우 체력감소
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
        else
        {
            return;
        }
    }
}
