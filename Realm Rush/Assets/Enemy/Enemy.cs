using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPanelty = 25;

    Bank bank;

    //���ʹ� �װų� ���̺긦 ��� �Ѿ�� �÷��̾ ���� ���� �����ؾ� �ϱ� ������, ��ȭ ���� ��ũ��Ʈ�� �˰��־�� �Ѵ�.
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if(bank == null) { return; }
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(goldPanelty);
    }
}
