using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;

    [SerializeField] int HitPoint = 3;
    [SerializeField] int scorePerHit = 5;
    
    Scoreboard scoreboard;
    GameObject parentGameobject;

    private void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        parentGameobject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();
        rigid.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        --HitPoint;
        scoreboard.IncreaseScore(scorePerHit);

        GameObject vfx = Instantiate(hitVFX, transform.position, transform.rotation);
        vfx.transform.parent = parentGameobject.transform;

        if (HitPoint == 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
        vfx.transform.parent = parentGameobject.transform;

        scoreboard.IncreaseScore(HitPoint);

        Destroy(this.gameObject);
    }
}
