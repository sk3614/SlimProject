using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultManager : MonoBehaviour
{
    public static DifficultManager S;

    public GameDifficult gameDifficult;
    public enum GameDifficult
    {
        none,
        easy,
        normal,
        hard,
        endless
    }
    public float difficultValue;

    private void Awake()
    {
        if (S==null)
        {
            S = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficultValue(int _num)
    {
        switch (_num)
        {
            case 0:
                gameDifficult = GameDifficult.easy;
                break;
            case 1:
                gameDifficult = GameDifficult.normal;
                break;
            case 2:
                gameDifficult = GameDifficult.hard;
                break;
            case 3:
                gameDifficult = GameDifficult.endless;
                break;
            default:
                break;
        }
        switch (gameDifficult)
        {
            case GameDifficult.none:
                difficultValue = 1.0f;
                break;
            case GameDifficult.easy:
                difficultValue = 1.0f;
                break;
            case GameDifficult.normal:
                difficultValue = 1.0f;
                break;
            case GameDifficult.hard:
                difficultValue = 1.0f;
                break;
            case GameDifficult.endless:
                difficultValue = 1.0f;
                break;
            default:
                break;
        }
    }


    public void SetDifficult()
    {
        //MoneySet
        switch (gameDifficult)
        {
            case GameDifficult.none:
                break;
            case GameDifficult.easy:
                MoneyManager.S.startMoney = 100000;
                AddItem.S.SearchItem("퇴비 자루", 20);
                AddItem.S.SearchItem("석탄 자루", 20);
                AddItem.S.SearchItem("고철 자루", 20);
                AddItem.S.SearchItem("그린 슬라임", 10);
                AddItem.S.SearchItem("블루 슬라임", 10);
                AddItem.S.SearchItem("옐로우 슬라임", 10);
                AddItem.S.SearchItem("레드 슬라임", 10);
                ProductManager.S.GetDrugs(50);
                ProductManager.S.GetIce(50);
                ProductManager.S.GetGlass(50);
                ProductManager.S.GetFuel(50);
                FarmUpgrade.S.OpenSlimeFarmTier = 1;
                FarmUpgrade.S.OpenTrashStorageTier = 1;
                FarmUpgrade.S.FarmUpgradeSet();
                break;
            case GameDifficult.normal:
                MoneyManager.S.startMoney = 60000;
                AddItem.S.SearchItem("퇴비 자루", 20);
                AddItem.S.SearchItem("석탄 자루", 20);
                AddItem.S.SearchItem("고철 자루", 20);
                AddItem.S.SearchItem("그린 슬라임", 10);
                AddItem.S.SearchItem("블루 슬라임", 10);
                AddItem.S.SearchItem("옐로우 슬라임", 10);
                AddItem.S.SearchItem("레드 슬라임", 10);

                break;
            case GameDifficult.hard:
                MoneyManager.S.startMoney = 25000;
                AddItem.S.SearchItem("퇴비 자루", 10);
                AddItem.S.SearchItem("석탄 자루", 10);
                AddItem.S.SearchItem("고철 자루", 10);
                AddItem.S.SearchItem("그린 슬라임", 5);
                AddItem.S.SearchItem("블루 슬라임", 5);
                AddItem.S.SearchItem("옐로우 슬라임", 5);
                AddItem.S.SearchItem("레드 슬라임", 5);
                break;
            case GameDifficult.endless:
                MoneyManager.S.startMoney = 60000;
                AddItem.S.SearchItem("퇴비 자루", 20);
                AddItem.S.SearchItem("석탄 자루", 20);
                AddItem.S.SearchItem("고철 자루", 20);
                AddItem.S.SearchItem("그린 슬라임", 10);
                AddItem.S.SearchItem("블루 슬라임", 10);
                AddItem.S.SearchItem("옐로우 슬라임", 10);
                AddItem.S.SearchItem("레드 슬라임", 10);
                break;
            default:
                break;
        }
        MoneyManager.S.Setmoney(MoneyManager.S.startMoney);


    }
}
