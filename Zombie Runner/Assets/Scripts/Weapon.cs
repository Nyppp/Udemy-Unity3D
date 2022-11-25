using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50f;

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect; //Instantiate를 위해 게임오브젝트로 선언

    //Ammo클래스에 대해 선언했으나 Ammo클래스를 포함한 Player 인스턴스 자체를 할당하면,
    //narrow 캐스팅으로 Ammo클래스를 참조할 수 있음
    [SerializeField] Ammo ammo;
    [SerializeField] float shootDelay = 1f;

    bool canShoot = true;
    

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if(ammo.GetCurrentAmmo() > 0 )
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammo.ReduceCurrentAmmo();
            canShoot = false;
        }


        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            // TODO : 히트 이펙트, 총알 맞는 사운드 추가
            CreateHitImpact(hit);

            // 적이 총에 맞은 경우 체력감소
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject Impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(Impact, 0.1f);
    }
}
