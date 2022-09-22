using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parentTransform;
    
    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
        vfx.transform.parent = parentTransform;
        
        Destroy(this.gameObject);
    }
}
