using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
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

    //충돌(게임오버)시 씬 리로드
    void RestartGame()
    {
        if (isTransitioning)
            return;
        else
        {
            isTransitioning = true;
            GetComponent<PlayerControls>().enabled = false;
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(loadDelay);
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx);
    }
}
