using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalnce = 150;
    [SerializeField ]int currentBalance;
    public int CurrnetBalance
    {
        get { return currentBalance; }
    }

    private void Awake()
    {
        currentBalance = startingBalnce;
    }

    //매개변수로 들어오는 int에 대해 정확한 계산을 위해 절대값으로 계산하고,
    //돈이 들어오는 동작과 돈을 빼내는 동작을 다른 함수로 나눈다.
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
