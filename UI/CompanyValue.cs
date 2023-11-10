using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompanyValue : MonoBehaviour
{
    public static CompanyValue S;

    private void Awake()
    {
        if (S==null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int allValue;
    public int moneyValue;
    public int slimeValue;
    public int materialValue;
    public int productValue;
    public int buildValue;
    public int fameValue;
    public int staffValue;
    public int timeValue;
    public Text T_CompanyValue;
    public void Start()
    {
        SetAllValue();
    }
    public void Update()
    {
        if (LocationManager.S.GetLocation()==LocationManager.Location.Company)
        {
            T_CompanyValue.gameObject.SetActive(true);
        }
        else
        {
            T_CompanyValue.gameObject.SetActive(false);
        }
    }

    public void SetAllValue()
    {
        allValue = moneyValue + slimeValue + materialValue + productValue + buildValue + fameValue+staffValue+ timeValue;
        T_CompanyValue.text = "회사가치 : " + allValue.ToString();
    }
    public void SetMoneyValue()
    {
        moneyValue = MoneyManager.S.CurrentMoney() / 100;
        SetAllValue();
    }
    public void SetItemValue(Item item,int _num,bool isUse=false)
    {
        int tierValue = 0;
        switch (item.itemType)
        {
            case Item.ItemType.Slime:
                tierValue = 8;
                for (int i = 1; i < item.Tier; i++)
                {
                    tierValue *= 2;
                }
                if (isUse) slimeValue -= tierValue * _num;
                else slimeValue += tierValue * _num;

                break;
            case Item.ItemType.Trash:
                tierValue = 10;
                for (int i = 1; i < item.Tier; i++)
                {
                    tierValue *= 2;
                }

                if (isUse) materialValue -= tierValue * _num;
                else materialValue += tierValue * _num;
                break;
            case Item.ItemType.ETC:
                break;
            default:
                break;
        }
        SetAllValue();
    }
    public void SetProductVaule(int _num = 1,bool _isUse=true )
    {
        int value = 2;
        for (int i = 0; i < FactoryUpgrade.S.ProductQualityUpTier; i++)
        {
            value *= 2;
        }
        value *= _num;
        if (_isUse)
        {
            productValue -= value;
        }
        else
        {
            productValue += value;
        }
        
        SetAllValue();
    }
    public void SetBuildValue(int _num)
    {
        buildValue += _num;
        SetAllValue();
    }

    public void SetTimeValue(int _year)
    {
        int value = 100 + (_year * 50);
        timeValue += value;
        SetAllValue();
    }
    public void SetStaffValue()
    {
        staffValue = 0;
        Staff[] allstaff = DayManager.S.allStaff;
        for (int i = 0; i < allstaff.Length; i++)
        {
            if (allstaff[i].GetStaffLoyalty()<=50)
            {
                staffValue += (int)((float)allstaff[i].companyValue*2.5f);

            }
            else
            {
                staffValue += allstaff[i].companyValue;
            }
        }
        SetAllValue();
    }
    public void SetFameValue()
    {
        SetAllValue();
    }

}
