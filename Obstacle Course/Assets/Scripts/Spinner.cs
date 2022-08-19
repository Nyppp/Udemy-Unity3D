using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float spinSpeed;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0,spinSpeed,0);
    }
}
