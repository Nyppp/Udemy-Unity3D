using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] float displayTime = 0.2f;

    private void Start()
    {
        img.enabled = false;
    }

    public void EnableHitEffect()
    {
        StartCoroutine(EnableImage());
    }

    IEnumerator EnableImage()
    {
        img.enabled = true;
        yield return new WaitForSeconds(displayTime);
        img.enabled = false;
    }
}
