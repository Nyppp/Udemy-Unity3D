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

    //�Ű������� ������ int�� ���� ��Ȯ�� ����� ���� ���밪���� ����ϰ�,
    //���� ������ ���۰� ���� ������ ������ �ٸ� �Լ��� ������.
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
