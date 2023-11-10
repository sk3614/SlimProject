using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUpgrade : MonoBehaviour
{
    public static FactoryUpgrade S;

    public GameObject[] createLines;
    public GameObject[] Staffs;

    public int CreateFasterCost;
    public int CreateFasterTier;
    public Text T_CreateFasterCost;
    public Text T_CreateFasterName;
    public GameObject B_CreateFaster;

    public int MoreCreateCost;
    public int MoreCreateTier;
    public Text T_MoreCreateCost;
    public Text T_MoreCreateName;
    public GameObject B_MoreCreate;

    public int LineCostCuttingCost;
    public int LineCostCuttingTier;
    public Text T_LineCostCuttingCost;
    public Text T_LineCostCuttingName;
    public GameObject B_LineCostCutting;

    public int ProductQualityUpCost;
    public int ProductQualityUpTier;
    public Text T_ProductQualityUpCost;
    public Text T_ProductQualityUpName;
    public GameObject B_ProductQualityUp;

    public int MorePackageCost;
    public int MorePackageTier;
    public Text T_MorePackageCost;
    public Text T_MorePackageName;
    public GameObject B_MorePackage;

    public int PackageFasterCost;
    public int PackageFasterTier;
    public Text T_PackageFasterCost;
    public Text T_PackageFasterName;
    public GameObject B_PackageFaster;

    public int PackageCostCuttingCost;
    public int PackageCostCuttingTier;
    public Text T_PackageCostCuttingCost;
    public Text T_PackageCostCuttingName;
    public GameObject B_PackageCostCutting;

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
    // Start is called before the first frame update
    void Start()
    {
        FactoryUpgradeSet();
    }
    
    public void CreateFaster()
    {
        if (MoneyManager.S.CurrentMoney() >= CreateFasterCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            CreateFasterTier += 1;
            MoneyManager.S.SpendMoney(CreateFasterCost);
            CreateFasterCost += 35000;
            T_CreateFasterCost.text = CreateFasterCost.ToString() + "원";
            T_CreateFasterName.text = "생산 레일 자동화(" + (CreateFasterTier+1).ToString() + "/5)";
            if (CreateFasterTier == 5)
            {
                T_CreateFasterName.text = "생산 레일 자동화(max)";
                B_CreateFaster.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void MoreCreate()
    {
        if (MoneyManager.S.CurrentMoney() >= MoreCreateCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            MoreCreateTier += 1;
            MoneyManager.S.SpendMoney(MoreCreateCost);
            MoreCreateCost += 20000;
            T_MoreCreateCost.text = MoreCreateCost.ToString() + "원";
            T_MoreCreateName.text = "생산 레일 확장(" + (MoreCreateTier+1).ToString() + "/5)";
            if (MoreCreateTier == 5)
            {
                T_MoreCreateName.text = "생산 레일 확장(max)";
                B_MoreCreate.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void LineCostCutting()
    {
        if (MoneyManager.S.CurrentMoney() >= LineCostCuttingCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            LineCostCuttingTier += 1;
            MoneyManager.S.SpendMoney(LineCostCuttingCost);
            LineCostCuttingCost += LineCostCuttingCost / 2;
            T_LineCostCuttingCost.text = LineCostCuttingCost.ToString() + "원";
            T_LineCostCuttingName.text = "생산 레일 재설계(" + (LineCostCuttingTier+1).ToString() + "/5)";
            if (LineCostCuttingTier == 5)
            {
                T_LineCostCuttingName.text = "생산 레일 재설계(max)";
                B_LineCostCutting.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void ProductQualityUp()
    {
        if (MoneyManager.S.CurrentMoney() >= ProductQualityUpCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            ProductQualityUpTier += 1;
            MoneyManager.S.SpendMoney(ProductQualityUpCost);
            ProductQualityUpCost += 50000;
            T_ProductQualityUpCost.text = ProductQualityUpCost.ToString() + "원";
            T_ProductQualityUpName.text = "고가치 물품 생산(" + (ProductQualityUpTier+1).ToString() + "/4)";
            DayManager.S.SellLineMaintenanceCost *= 2;
            DayManager.S.CreateLineMaintenanceCost *= 2;
            DayManager.S.PackingLineMaintenanceCost *= 2;
            ProductManager.S.UpgradePenalty();
            ProductManager.S.UpgradeProductSet();
            if (ProductQualityUpTier == 4)
            {
                T_ProductQualityUpName.text = "고가치 물품 생산(max)";
                B_ProductQualityUp.SetActive(false);
            }

            Shop.S.SellLinesProductImageChange();
            createLines[0].GetComponent<InsertSlime>().ProductImageChange();
            createLines[1].GetComponent<InsertSlime>().ProductImageChange();
            createLines[2].GetComponent<InsertSlime>().ProductImageChange();
            createLines[0].GetComponent<InsertSlime>().UpgradePenalty();
            createLines[1].GetComponent<InsertSlime>().UpgradePenalty();
            createLines[2].GetComponent<InsertSlime>().UpgradePenalty();
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }
    public void MorePackage()
    {
        if (MoneyManager.S.CurrentMoney() >= MorePackageCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            MorePackageTier += 1;
            MoneyManager.S.SpendMoney(MorePackageCost);
            T_MorePackageCost.text = MorePackageCost.ToString() + "원";
            T_MorePackageName.text = "포장 레일 확장(" + (MorePackageTier + 1).ToString() + "/5)";
            if (MorePackageTier == 5)
            {
                T_MorePackageName.text = "포장 레일 확장(max)";
                B_MorePackage.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }

    public void PackageFaster()
    {
        if (MoneyManager.S.CurrentMoney() >= PackageFasterCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            PackageFasterTier += 1;
            MoneyManager.S.SpendMoney(PackageFasterCost);
            T_PackageFasterCost.text = PackageFasterCost.ToString() + "원";
            T_PackageFasterName.text = "포장 레일 자동화(" + (PackageFasterTier + 1).ToString() + "/5)";
            if (PackageFasterTier == 5)
            {
                T_PackageFasterName.text = "포장 레일 자동화(max)";
                B_PackageFaster.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }

    public void PackageCostCutting()
    {
        if (MoneyManager.S.CurrentMoney() >= PackageCostCuttingCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            PackageCostCuttingTier += 1;
            MoneyManager.S.SpendMoney(PackageCostCuttingCost);
            PackageCostCuttingCost += PackageCostCuttingCost/2;
            T_PackageCostCuttingCost.text = PackageCostCuttingCost.ToString() + "원";
            T_PackageCostCuttingName.text = "포장 레일 재설계(" + (PackageCostCuttingTier + 1).ToString() + "/5)";
            if (PackageCostCuttingTier == 5)
            {
                T_PackageCostCuttingName.text = "포장 레일 재설계(max)";
                B_PackageCostCutting.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }

    }

    public void FactoryUpgradeSet()
    {
        CreateFasterCost = 35000 + 35000 * CreateFasterTier;
        T_CreateFasterCost.text = CreateFasterCost.ToString() + "원";
        T_CreateFasterName.text = "생산 레일 자동화(" + (CreateFasterTier+1).ToString() + "/5)";
        if (CreateFasterTier == 5)
        {
            T_CreateFasterName.text = "생산 레일 자동화(max)";
            B_CreateFaster.SetActive(false);
        }
        MoreCreateCost = 20000 + 20000 * MoreCreateTier;
        T_MoreCreateCost.text = MoreCreateCost.ToString() + "원";
        T_MoreCreateName.text = "생산 레일 확장(" + (MoreCreateTier+1).ToString() + "/5)";
        if (MoreCreateTier == 5)
        {
            T_MoreCreateName.text = "생산 레일 확장(max)";
            B_MoreCreate.SetActive(false);
        }
        LineCostCuttingCost = 4000;
        for (int i = 0; i < LineCostCuttingTier; i++)
        {
            LineCostCuttingCost += LineCostCuttingCost/2;
        }
        T_LineCostCuttingCost.text = LineCostCuttingCost.ToString() + "원";
        T_LineCostCuttingName.text = "생산 레일 재설계(" +(LineCostCuttingTier+1).ToString() + "/5)";
        if (LineCostCuttingTier == 5)
        {
            T_LineCostCuttingName.text = "생산 레일 재설계(max)";
            B_LineCostCutting.SetActive(false);
        }
        ProductQualityUpCost = 50000+50000*ProductQualityUpTier;
        T_ProductQualityUpCost.text = ProductQualityUpCost.ToString() + "원";
        T_ProductQualityUpName.text = "고가치 물품 생산(" + (ProductQualityUpTier+1).ToString() + "/4)";
        for (int i = 0; i < ProductQualityUpTier; i++)
        {
            DayManager.S.SellLineMaintenanceCost *= 2;
            DayManager.S.CreateLineMaintenanceCost *= 2;
            DayManager.S.PackingLineMaintenanceCost *= 2;
        }
        if (ProductQualityUpTier == 4)
        {
            T_ProductQualityUpName.text = "고가치 물품 생산(max)";
            B_ProductQualityUp.SetActive(false);
        }
        
        Shop.S.SellLinesProductImageChange();
        createLines[0].GetComponent<InsertSlime>().ProductImageChange();
        createLines[1].GetComponent<InsertSlime>().ProductImageChange();
        createLines[2].GetComponent<InsertSlime>().ProductImageChange();
        ProductManager.S.UpgradeProductSet();
        MorePackageCost = 20000;
        T_MorePackageCost.text = MorePackageCost.ToString() + "원";
        T_MorePackageName.text = "포장 레일 확장(" + (MorePackageTier + 1).ToString() + "/5)";
        if (MorePackageTier == 5)
        {
            T_MorePackageName.text = "포장 레일 확장(max)";
            B_MorePackage.SetActive(false);
        }
        PackageFasterCost = 35000;
        T_PackageFasterCost.text = PackageFasterCost.ToString() + "원";
        T_PackageFasterName.text = "포장 레일 자동화(" + (PackageFasterTier + 1).ToString() + "/5)";
        if (PackageFasterTier == 5)
        {
            T_PackageFasterName.text = "포장 레일 자동화(max)";
            B_PackageFaster.SetActive(false);
        }
        PackageCostCuttingCost =4000;
        for (int i = 0; i < PackageCostCuttingTier; i++)
        {
            PackageCostCuttingCost += PackageCostCuttingCost / 2;
        }
        T_PackageCostCuttingCost.text = PackageCostCuttingCost.ToString() + "원";
        T_PackageCostCuttingName.text = "포장 레일 재설계(" + (PackageCostCuttingTier + 1).ToString() + "/5)";
        
        if (PackageCostCuttingTier == 5)
        {
            T_PackageCostCuttingName.text = "포장 레일 재설계(max)";
            B_PackageCostCutting.SetActive(false);
        }
    }
}
