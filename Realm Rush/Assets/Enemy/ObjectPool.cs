using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject obj;

    [Range(0,50)]
    [SerializeField] int poolSize = 5;

    [Range(0.1f, 30f)]
    [SerializeField] float spawnDelay = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; ++i)
        {
            pool[i] = Instantiate(obj, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while(true)
        {
            EnableObejctInPool();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void EnableObejctInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
