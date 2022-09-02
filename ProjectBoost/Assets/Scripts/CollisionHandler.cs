using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float loadDelay = 1f;

    public AudioClip crashSound;
    public AudioClip finishSound;

    public ParticleSystem finishParticle;
    public ParticleSystem crashParticle;

    AudioSource audioSource;

    //���� ��ȯ ����(�� �ε� ���, ��� ó�� ��)
    bool isTransitioning = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        isTransitioning = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning == true) { return; }
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("���� ���������� �ֽ��ϴ�");
                break;
            case "Fuel":
                Debug.Log("���� ����");
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    //���� ����
    void StartCrashSequence()
    {
        Debug.Log("��ֹ��� �浹, ���� �����");
        gameObject.GetComponent<Movement>().enabled = false;

        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);

        crashParticle.Play();

        isTransitioning = true;

        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        //���� ������� ���� ����� ��ȣ�� �����´�.
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx);
    }

    //���� Ŭ����
    void StartFinishSequence()
    {
        Debug.Log("�������� Ŭ����");
        gameObject.GetComponent<Movement>().enabled = false;

        audioSource.Stop();
        audioSource.PlayOneShot(finishSound);

        finishParticle.Play();

        isTransitioning = true;

        Invoke("LoadNextLevel", loadDelay);
    }

    void LoadNextLevel()
    {
        //���� ���������� �ѱ��. ��� Ŭ�����ߴٸ�, 1����������.
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIdx;

        if (currentSceneIdx == 0)
        {
            nextSceneIdx = currentSceneIdx+1;
        }
        else
        {
            nextSceneIdx = 0;
        }

        SceneManager.LoadScene(nextSceneIdx);
    }
}
