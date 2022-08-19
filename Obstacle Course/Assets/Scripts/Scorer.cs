using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits;
    private void Awake()
    {
        hits = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Hit" && collision.gameObject.tag != "Ground")
        { 
            Debug.Log("Á¡¼ö : " + (++hits));
        }
    }

}
