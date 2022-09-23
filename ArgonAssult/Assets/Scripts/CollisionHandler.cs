using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    bool isTransitioning = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        RestartGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        RestartGame();
    }

    //�浹(���ӿ���)�� �� ���ε�
    void RestartGame()
    {
        if (isTransitioning)
            return;
        else
        {
            ProcessPlayerDead();
        }
    }

    private void ProcessPlayerDead()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        isTransitioning = true;
        GetComponent<PlayerControls>().enabled = false;
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(loadDelay);
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx);
    }
}
