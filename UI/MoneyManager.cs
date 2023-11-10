using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
    public static MoneyManager S;
    public Text moneyUI;
    private int money;
    public int startMoney;
    public GameObject GameOverUI;
     void Awake()
    {
        if(S==null)
        {
            S = this;
        }else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
    }
    public void GetMoney(int _num )
    {
        money += _num;
        moneyUI.text = money.ToString("n0");
        Archive.S.SumGetMoney(_num);
    }
    public void SpendMoney(int _num)
    {
        money -= _num;
        moneyUI.text =money.ToString("n0");
        Archive.S.SumSpendMoney(_num);
        print(_num);
        if(money<=-100000)
        {
            LocationManager.openUI = true;
            GameOverUI.SetActive(true);
            Pause.S.PauseGame();
        }
        
    }
    public int CurrentMoney()
    {
        return money;
    }
    public void Setmoney(int _num)
    {
        money = _num;
        moneyUI.text =money.ToString("n0");
    }
}
