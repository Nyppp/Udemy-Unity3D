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

    //�Ű������� ������ int�� ���� ��Ȯ�� ����� ���� ���밪���� ����ϰ�,
    //���� ������ ���۰� ���� ������ ������ �ٸ� �Լ��� ������.
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        //���� ���̳ʽ��� �Ǹ� ���ӿ��� -> �� ���ε�
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
