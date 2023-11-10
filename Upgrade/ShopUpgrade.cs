using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopUpgrade : MonoBehaviour
{
    public static ShopUpgrade S;
    public GameObject[] SellLines;
    public Staff[] staffs;

    public int ProductAdvertisingCost;
    public int ProductAdvertisingTier;
    public Text T_ProductAdvertisingCost;
    public Text T_ProductAdvertisingName;
    public GameObject B_ProductAdvertising;

    public int ShopAdvertisingCost;
    public int ShopAdvertisingTier;
    public Text T_ShopAdvertisingCost;
    public Text T_ShopAdvertisingName;
    public GameObject B_ShopAdvertising;

    public int SellLineCostCuttingCost;
    public int SellLineCostCuttingTier;
    public Text T_SellLineCostCuttingCost;
    public Text T_SellLineCostCuttingName;
    public GameObject B_SellLineCostCutting;

    public int InteriorReformationCost;
    public int InteriorReformationTier;
    public Text T_InteriorReformationCost;
    public Text T_InteriorReformationName;
    public GameObject B_InteriorReformation;

    public int ControlDemandAndSupplyCost;
    public int ControlDemandAndSupplyTier;
    public Text T_ControlDemandAndSupplyCost;
    public Text T_ControlDemandAndSupplyName;
    public GameObject B_ControlDemandAndSupply;



    private void Awake()
    {
        if(S==null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        ShopUpgradeSet();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ProductAdvertising()
    {
        if (MoneyManager.S.CurrentMoney() >= ProductAdvertisingCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            ProductAdvertisingTier += 1;
            MoneyManager.S.SpendMoney(ProductAdvertisingCost);
            ProductAdvertisingCost+= (ProductAdvertisingCost/10)*8;
            T_ProductAdvertisingCost.text = ProductAdvertisingCost.ToString() + "원";
            T_ProductAdvertisingName.text = "가게 단장(" + (ProductAdvertisingTier+1).ToString() + "/6)";
            if (ProductAdvertisingTier == 5)
            {
                T_ProductAdvertisingName.text = "가게 단장(max)";
                B_ProductAdvertising.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void ShopAdvertising()
    {
        if (MoneyManager.S.CurrentMoney() >= ShopAdvertisingCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            ShopAdvertisingTier += 1;
            MoneyManager.S.SpendMoney(ShopAdvertisingCost);
            ShopAdvertisingCost += 30000;
            T_ShopAdvertisingCost.text = ShopAdvertisingCost.ToString() + "원";
            T_ShopAdvertisingName.text = "직원 교육(" + (ShopAdvertisingTier + 1).ToString() + "/5)";
            if (ShopAdvertisingTier == 5)
            {
                T_ShopAdvertisingName.text = "직원 교육(max)";
                B_ShopAdvertising.SetActive(false);
            }
            ProductManager.S.ChangeAllPrice();
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void SellLineCostCutting()
    {
        if (MoneyManager.S.CurrentMoney() >= SellLineCostCuttingCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            SellLineCostCuttingTier += 1;
            MoneyManager.S.SpendMoney(SellLineCostCuttingCost);
            SellLineCostCuttingCost += SellLineCostCuttingCost/2;
            T_SellLineCostCuttingCost.text = SellLineCostCuttingCost.ToString() + "원";
            T_SellLineCostCuttingName.text = "재산 관리(" + (SellLineCostCuttingTier+1).ToString() + "/5)";
            if (SellLineCostCuttingTier == 5)
            {
                T_SellLineCostCuttingName.text = "재산 관리(max)";
                B_SellLineCostCutting.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void InteriorReformation()
    {
        if (MoneyManager.S.CurrentMoney() >= InteriorReformationCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            InteriorReformationTier += 1;
            MoneyManager.S.SpendMoney(InteriorReformationCost);
            InteriorReformationCost += 25000;
            T_InteriorReformationCost.text = InteriorReformationCost.ToString() + "원";
            T_InteriorReformationName.text = "우수한 서비스(" + (InteriorReformationTier+1).ToString() + "/6)";
            if (InteriorReformationTier == 6)
            {
                T_InteriorReformationName.text = "우수한 서비스(max)";
                B_InteriorReformation.SetActive(false);
            }
            ProductManager.S.ChangeAllPrice();
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void ControlDemandAndSupply()
    {
        if (MoneyManager.S.CurrentMoney() >= ControlDemandAndSupplyCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            ControlDemandAndSupplyTier += 1;
            MoneyManager.S.SpendMoney(ControlDemandAndSupplyCost);
            ControlDemandAndSupplyCost += ControlDemandAndSupplyCost/2;
            T_ControlDemandAndSupplyCost.text = ControlDemandAndSupplyCost.ToString() + "원";
            T_ControlDemandAndSupplyName.text = "직원 감시(" + (ControlDemandAndSupplyTier+1).ToString() + "/10)";
            for (int i = 0; i < DayManager.S.allStaff.Length; i++)
            {
                if (DayManager.S.allStaff[i].GetStaffOn())
                {
                    DayManager.S.allStaff[i].ChangeLoyalty(100);
                }

            }
            if (ControlDemandAndSupplyTier == 10)
            {
                T_ControlDemandAndSupplyName.text = "직원 감시(max)";
                B_ControlDemandAndSupply.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }


    public void ShopUpgradeSet()
    {
        ProductAdvertisingCost = 20000;
        for (int i = 0; i < ProductAdvertisingTier; i++)
        {
            ProductAdvertisingCost+= (ProductAdvertisingCost*8)/10;
        }
        T_ProductAdvertisingCost.text = ProductAdvertisingCost.ToString() + "원";
        T_ProductAdvertisingName.text = "가게 단장(" + (ProductAdvertisingTier+1).ToString() + "/5)";
        if (ProductAdvertisingTier == 5)
        {
            T_ProductAdvertisingName.text = "가게 단장(max)";
            B_ProductAdvertising.SetActive(false);

        }
        ShopAdvertisingCost = 30000;
        for (int i = 0; i < ShopAdvertisingTier; i++)
        {
            ShopAdvertisingCost += 30000;
        }
        T_ShopAdvertisingCost.text = ShopAdvertisingCost.ToString() + "원";
        T_ShopAdvertisingName.text = "직원 교육(" + (ShopAdvertisingTier + 1).ToString() + "/5)";
        if (ShopAdvertisingTier == 5)
        {
            T_ShopAdvertisingName.text = "직원 교육(max)";
            B_ShopAdvertising.SetActive(false);

        }
        SellLineCostCuttingCost = 4000;
        for (int i = 0; i < SellLineCostCuttingTier; i++)
        {
            SellLineCostCuttingCost += SellLineCostCuttingCost / 2;
        }
        T_SellLineCostCuttingCost.text = SellLineCostCuttingCost.ToString() + "원";
        T_SellLineCostCuttingName.text = "재산 관리(" + (SellLineCostCuttingTier+1).ToString() + "/5)";
        if (SellLineCostCuttingTier == 5)
        {
            T_SellLineCostCuttingName.text = "재산 관리(max)";
            B_SellLineCostCutting.SetActive(false);
        }
        InteriorReformationCost = 25000;
        for (int i = 0; i < InteriorReformationTier; i++)
        {
            InteriorReformationCost +=25000;
        }
        T_InteriorReformationCost.text = InteriorReformationCost.ToString() + "원";
        T_InteriorReformationName.text = "우수한 서비스(" + (InteriorReformationTier+1).ToString() + "/5)";
        if (InteriorReformationTier == 5)
        {
            T_InteriorReformationName.text = "우수한 서비스(max)";
            B_InteriorReformation.SetActive(false);
        }
        ControlDemandAndSupplyCost = 10000;
        for (int i = 0; i < ControlDemandAndSupplyTier; i++)
        {
            ControlDemandAndSupplyCost += ControlDemandAndSupplyCost/2;
        }
        T_ControlDemandAndSupplyCost.text = ControlDemandAndSupplyCost.ToString() + "원";
        T_ControlDemandAndSupplyName.text = "직원 감시(" + (ControlDemandAndSupplyTier + 1).ToString() + "/10)";
        if (ControlDemandAndSupplyTier == 10)
        {
            T_ControlDemandAndSupplyName.text = "직원 감시(max)";
            B_ControlDemandAndSupply.SetActive(false);
        }


    }
}

