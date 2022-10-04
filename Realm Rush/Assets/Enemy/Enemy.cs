using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPanelty = 25;

    Bank bank;

    //몬스터는 죽거나 웨이브를 모두 넘어가면 플레이어가 가진 돈을 조작해야 하기 때문에, 재화 관련 스크립트를 알고있어야 한다.
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
