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

    //상태 전환 여부(씬 로딩 대기, 사망 처리 중)
    bool isTransitioning = false;
    bool isCollisionDisable = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        isTransitioning = false;
    }

    void Update()
    {
        DebugFunction();
    }

    private void DebugFunction()
    {
        //다음 씬 호출
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        //콜리젼 비활성화 토글
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCollisionDisable = !isCollisionDisable;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning == true || isCollisionDisable == true) { return; }
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("현재 안전지역에 있습니다");
                break;
            case "Fuel":
                Debug.Log("연료 충전");
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    //게임 오버
    void StartCrashSequence()
    {
        Debug.Log("장애물과 충돌, 게임 재시작");
        gameObject.GetComponent<Movement>().enabled = false;

        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);

        crashParticle.Play();

        isTransitioning = true;

        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        //현재 사용중인 씬의 빌드씬 번호를 가져온다.
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx);
    }

    //게임 클리어
    void StartFinishSequence()
    {
        Debug.Log("스테이지 클리어");
        gameObject.GetComponent<Movement>().enabled = false;

        audioSource.Stop();
        audioSource.PlayOneShot(finishSound);

        finishParticle.Play();

        isTransitioning = true;

        Invoke("LoadNextLevel", loadDelay);
    }

    void LoadNextLevel()
    {
        //다음 스테이지로 넘긴다. 모두 클리어했다면, 1스테이지로.
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
