using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalnce = 150;
    [SerializeField ]int currentBalance;
    [SerializeField] TextMeshProUGUI goldLabel;

    public int CurrnetBalance
    {
        get { return currentBalance; }
    }

    private void Awake()
    {
        currentBalance = startingBalnce;
        UpdateDisplay();
    }

    //매개변수로 들어오는 int에 대해 정확한 계산을 위해 절대값으로 계산하고,
    //돈이 들어오는 동작과 돈을 빼내는 동작을 다른 함수로 나눈다.
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        //돈이 마이너스가 되면 게임오버 -> 씬 리로드
        if (currentBalance < 0)
        {
            //Lose the game
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        goldLabel.text = "Gold : " + currentBalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }    
}
