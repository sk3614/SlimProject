using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour {
    public static Shop S;
    public float fame;//명성
    public float newCustomerTime;
    [SerializeField]
    public GameObject[] shopLines;
    public int customer;
    public int pastMonthCustomer;
    public int monthMaxCustomer;
    public int shopStaffNum;
    public int ShopOpenNum;
    public Text T_fame;
    // Use this for initialization
    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start () {
        Debug.Log("Fame 초기화");
        fame = 400;
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                fame = 400;
                break;
            case DifficultManager.GameDifficult.normal:
                fame = 300;
                break;
            case DifficultManager.GameDifficult.hard:
                fame = 200;
                break;
            case DifficultManager.GameDifficult.endless:
                fame = 300;
                break;
            default:
                break;
        }
        VariationFame(0);
        SellLinesProductImageChange();
    }
	// Update is called once per frame
	void Update () {
        if(LocationManager.S.GetLocation()==LocationManager.Location.Shop)
        {
            T_fame.gameObject.SetActive(true);
            T_fame.text = "평판:" + fame.ToString();
        }
        else
        {
            T_fame.gameObject.SetActive(false);
        }
        
        customer =shopLines[0].GetComponent<SellLine>().consumer+ shopLines[1].GetComponent<SellLine>().consumer + shopLines[2].GetComponent<SellLine>().consumer ;
        if (monthMaxCustomer<customer)
        {
            monthMaxCustomer = customer;
        }
        ShopOpenNum = shopLines[0].GetComponent<SellLine>().sellProductOn + shopLines[1].GetComponent<SellLine>().sellProductOn + shopLines[2].GetComponent<SellLine>().sellProductOn;
    }
    public void VariationFame(int _num=0)
    {
        fame += _num;
        fame=Mathf.Clamp(fame, 0, 1000);

        print("평판증감:"+_num.ToString());
        ProductManager.S.ChangeAllPrice();
    }
    public bool IsShopLineOpen()
    {
        for (int i = 0; i < shopLines.Length; i++)
        {
            if(shopLines[i].GetComponent<SellLine>().ShopOpen())
            {
                return true;
            }
        }
        return false;
    }

    public void MonthShopCheck()
    {
        if(pastMonthCustomer>0)//이전분기 대기손님처리
        {
            GeneralMeeting.S.ConsumerGroupDIVariation(pastMonthCustomer);
            Shop.S.VariationFame(0);//-500
        }
        pastMonthCustomer = customer;
            if (!shopLines[0].GetComponent<SellLine>().GetStaff().GetStaffOn()&& !shopLines[1].GetComponent<SellLine>().GetStaff().GetStaffOn()&&!shopLines[2].GetComponent<SellLine>().GetStaff().GetStaffOn())
            {
            GeneralMeeting.S.LaborUnionDIVariation(5);
            }
        if(monthMaxCustomer<=10&&shopStaffNum>0)//분기 최대대기손님10명이하
        {
            monthMaxCustomer = 0;
        }
        else
        {
            monthMaxCustomer = 0;
        }
        FameUp();
    }
    public void AllShopStaffFire()
    {
        customer = 0;
        pastMonthCustomer = 0;
        GeneralMeeting.S.ConsumerGroupDIVariation(8);
        GeneralMeeting.S.LaborUnionDIVariation(8);
        //Shop.S.VariationFame(-250);
        Shop.S.VariationFame(0);
        DayManager.S.shopWorkStack = 0;
    }
    public void SellLinesProductImageChange()
    {
        shopLines[0].GetComponent<SellLine>().ProductImageChange();
        shopLines[1].GetComponent<SellLine>().ProductImageChange();
        shopLines[2].GetComponent<SellLine>().ProductImageChange();
    }
    public void SetNewCustomerTime()
    {
        if (fame > 50 - 5 * ShopUpgrade.S.ProductAdvertisingTier)
        {
            int value = (int)fame / (100-10*ShopUpgrade.S.ProductAdvertisingTier);
            newCustomerTime = (5.0f / value) * ShopOpenNum;
        }
        else
        {
            newCustomerTime = 1000f;
        }
    }
    public void FameUp()
    {
        if(fame<=200)
        {
            fame += 25;
        }
    }
}
