using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FarmUpgrade : MonoBehaviour
{
    public static FarmUpgrade S;

    public Cell[] SlimeFarms;
    public Cell[] TrashStorages;

    public int OpenSlimeFarmCost;
    public int OpenSlimeFarmTier;
    public Text T_OpenSlimeFarmCost;
    public Text T_OpenSlimeFarmName;
    public GameObject B_OpenSlimeFarm;

    public int OpenTrashStorageCost;
    public int OpenTrashStorageTier ;
    public Text T_OpenTrashStorageCost;
    public Text T_OpenTrashStorageName;
    public GameObject B_OpenTrashStorage;

    public int TrashQualityUpCost;
    public int TrashQualityUpTier;
    public Text T_TrashQualityUpCost;
    public Text T_TrashQualityUpName;
    public GameObject B_TrashQualityUp;

    public int TrashStorageCostCuttingCost;
    public int TrashStorageCostCuttingTier;
    public Text T_TrashStorageCostCuttingCost;
    public Text T_TrashStorageCostCuttingName;
    public GameObject B_TrashStorageCostCutting;


    public int TwinSlimeCost;
    public int TwinSlimeTier;
    public Text T_TwinSlimeCost;
    public Text T_TwinSlimeName;
    public GameObject B_TwinSlimeFaster;

    public int SlimeFarmCostCuttingCost;
    public int SlimeFarmCostCuttingTier;
    public Text T_SlimeFarmCostCuttingCost;
    public Text T_SlimeFarmCostCuttingName;
    public GameObject B_SlimeFarmCostCutting;

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
        
        FarmUpgradeSet();
        
    }

    public void OpenSlimeFarm()
    {
        if (MoneyManager.S.CurrentMoney() >= OpenSlimeFarmCost&&OpenSlimeFarmTier<10)
        {
            SoundManager.S.PlaySE("업그레이드");
            for (int i = 0; i < SlimeFarms.Length; i++)
            {
                if (!SlimeFarms[i].gameObject.activeInHierarchy)
                {
                    SlimeFarms[i].gameObject.SetActive(true);
                    break;
                }
            }
            OpenSlimeFarmTier += 1;
            CompanyValue.S.SetBuildValue(80);
            GeneralMeeting.S.PlusUpgradeNum();
            MoneyManager.S.SpendMoney(OpenSlimeFarmCost);
            
            T_OpenSlimeFarmCost.text = OpenSlimeFarmCost.ToString()+ "원";
            T_OpenSlimeFarmName.text = "슬라임 농장 건설(" + (OpenSlimeFarmTier+1).ToString() + "/9)";
            if (OpenSlimeFarmTier==9)
            {
                T_OpenSlimeFarmName.text = "슬라임 농장 건설(max)";
                B_OpenSlimeFarm.SetActive(false);
            }
            

        }
        
    }
    public void OpenTrashStorage()
    {
        if(MoneyManager.S.CurrentMoney()>= OpenTrashStorageCost)
            {
            SoundManager.S.PlaySE("업그레이드");
            for (int i = 0; i < TrashStorages.Length; i++)
            {
                if (!TrashStorages[i].gameObject.activeInHierarchy)
                {
                    TrashStorages[i].gameObject.SetActive(true);
                    break;
                }
            }
            
            MoneyManager.S.SpendMoney(OpenTrashStorageCost);
            GeneralMeeting.S.PlusUpgradeNum();
            CompanyValue.S.SetBuildValue(60);
            OpenTrashStorageTier += 1;
            T_OpenTrashStorageCost.text = OpenTrashStorageCost.ToString() + "원";
            T_OpenTrashStorageName.text = "원자재 저장고 건설(" + (OpenTrashStorageTier+1).ToString() + "/9)";
            if (OpenTrashStorageTier == 9)
            {
                T_OpenTrashStorageName.text = "원자재 저장고 건설(max)";
                B_OpenTrashStorage.SetActive(false);
            }

        }
        
    }
    public void TrashQualityUp()
    {
        if (MoneyManager.S.CurrentMoney() >= TrashQualityUpCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            MoneyManager.S.SpendMoney(TrashQualityUpCost);
            TrashQualityUpTier += 1;
            TrashQualityUpCost += 50000;
            DayManager.S.SlimeFarmMaintenanceCost *= 2;
            DayManager.S.TrashStorageMaintenanceCost *= 2;
            T_TrashQualityUpCost.text = TrashQualityUpCost.ToString() + "원";
            T_TrashQualityUpName.text = "원자재 품질 증가(" + (TrashQualityUpTier+1).ToString() + "/5)";
            if (TrashQualityUpTier == 5)
            {
                T_TrashQualityUpName.text = "원자재 품질 증가(max)";
                B_TrashQualityUp.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }
    }
    public void TrashStorageCostCutting()
    {
        if (MoneyManager.S.CurrentMoney() >= TrashStorageCostCuttingCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            MoneyManager.S.SpendMoney(TrashStorageCostCuttingCost);
            TrashStorageCostCuttingTier += 1;
            TrashStorageCostCuttingCost += TrashStorageCostCuttingCost / 2;
            T_TrashStorageCostCuttingCost.text = TrashStorageCostCuttingCost.ToString() + "원";
            T_TrashStorageCostCuttingName.text = "원자재 저장고 증축(" + (TrashStorageCostCuttingTier+1).ToString() + "/5)";
            if (TrashStorageCostCuttingTier == 5)
            {
                T_TrashStorageCostCuttingName.text = "원자재 저장고 증축(max)";
                B_TrashStorageCostCutting.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }
    }
    public void TwinSlime()
    {
        if (MoneyManager.S.CurrentMoney() >= TwinSlimeCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            MoneyManager.S.SpendMoney(TwinSlimeCost);
            TwinSlimeTier += 1;
            TwinSlimeCost += 25000;
            T_TwinSlimeCost.text = TwinSlimeCost.ToString() + "원";
            T_TwinSlimeName.text = "쌍둥이 슬라임(" + (TwinSlimeTier + 1).ToString() + "/6)";
            
            if (TwinSlimeTier == 6)
            {
                T_TwinSlimeName.text = "쌍둥이 슬라임(max)";
                B_TwinSlimeFaster.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }
    }
    public void  SlimeFarmCostCutting()
    {
        if (MoneyManager.S.CurrentMoney() >= SlimeFarmCostCuttingCost)
        {
            SoundManager.S.PlaySE("업그레이드");
            MoneyManager.S.SpendMoney(SlimeFarmCostCuttingCost);
            SlimeFarmCostCuttingTier += 1;
            SlimeFarmCostCuttingCost += SlimeFarmCostCuttingCost/2;
            T_SlimeFarmCostCuttingCost.text = SlimeFarmCostCuttingCost.ToString() + "원";
            T_SlimeFarmCostCuttingName.text = "슬라임 농장 비용절감(" + (SlimeFarmCostCuttingTier+1).ToString() + "/5)";
            if (SlimeFarmCostCuttingTier == 5)
            {
                T_SlimeFarmCostCuttingName.text = "슬라임 농장 비용절감(max)";
                B_SlimeFarmCostCutting.SetActive(false);
            }
            GeneralMeeting.S.PlusUpgradeNum();
        }
    }
    public void FarmUpgradeSet()
    {
        for (int i = 0; i < SlimeFarms.Length; i++)
        {
            SlimeFarms[i].gameObject.SetActive(false);
        }
        for (int i = 0; i <= OpenSlimeFarmTier; i++)
        {
            SlimeFarms[i].gameObject.SetActive(true);
        }
        OpenSlimeFarmCost = 8000;
        T_OpenSlimeFarmCost.text = OpenSlimeFarmCost.ToString() + "원";
        T_OpenSlimeFarmName.text = "슬라임 농장 건설(" + (OpenSlimeFarmTier+1).ToString() + "/9)";
        if (OpenSlimeFarmTier == 9)
        {
            T_OpenSlimeFarmName.text = "슬라임 농장 건설(max)";
            B_OpenSlimeFarm.SetActive(false);
        }
        for (int i = 0; i < TrashStorages.Length; i++)
        {
            TrashStorages[i].gameObject.SetActive(false);
        }
        for (int i = 0; i <= OpenTrashStorageTier; i++)
        {
            TrashStorages[i].gameObject.SetActive(true);
        }
        OpenTrashStorageCost = 10000;
        T_OpenTrashStorageCost.text = OpenTrashStorageCost.ToString() + "원";
        T_OpenTrashStorageName.text = "원자재 저장고 건설(" + (OpenTrashStorageTier+1).ToString() + "/9)";
        if (OpenTrashStorageTier == 9)
        {
            T_OpenTrashStorageName.text = "원자재 저장고 건설(max)";
            B_OpenTrashStorage.SetActive(false);
        }
        TrashQualityUpCost = 50000 * (TrashQualityUpTier + 1);
        T_TrashQualityUpCost.text = TrashQualityUpCost.ToString() + "원";
        T_TrashQualityUpName.text = "원자재 품질 증가(" + (TrashQualityUpTier+1).ToString() + "/5)";
        
        if (TrashQualityUpTier == 5)
        {
            T_TrashQualityUpName.text = "원자재 품질 증가(max)";
            B_TrashQualityUp.SetActive(false);
        }
        TrashStorageCostCuttingCost =4000;
        for (int i = 0; i < TrashStorageCostCuttingTier; i++)
        {
            TrashStorageCostCuttingCost += TrashStorageCostCuttingCost/2;
        }
        T_TrashStorageCostCuttingCost.text = TrashStorageCostCuttingCost.ToString() + "원";
        T_TrashStorageCostCuttingName.text = "원자재 저장고 증축(" + (TrashStorageCostCuttingTier+1).ToString() + "/5)";
        if (TrashStorageCostCuttingTier == 5)
        {
            T_TrashStorageCostCuttingName.text = "원자재 저장고 증축(max)";
            B_TrashStorageCostCutting.SetActive(false);
        }
        TwinSlimeCost = 25000 * (TwinSlimeTier + 1);
        T_TwinSlimeCost.text = TwinSlimeCost.ToString() + "원";
        T_TwinSlimeName.text = "쌍둥이 슬라임(" + (TwinSlimeTier+1).ToString()+ "/6)";
        if (TwinSlimeTier == 6)
        {
            T_TwinSlimeName.text = "쌍둥이 슬라임(max)";
            B_TwinSlimeFaster.SetActive(false);
        }
        SlimeFarmCostCuttingCost = 4000;
        for (int i = 0; i < SlimeFarmCostCuttingTier; i++)
        {
            SlimeFarmCostCuttingCost += SlimeFarmCostCuttingCost / 2;
        }
        T_SlimeFarmCostCuttingCost.text = SlimeFarmCostCuttingCost.ToString() + "원";
        T_SlimeFarmCostCuttingName.text = "슬라임 농장 비용절감(" + (SlimeFarmCostCuttingTier+1).ToString() + "/5)";
        if (SlimeFarmCostCuttingTier == 5)
        {
            T_SlimeFarmCostCuttingName.text = "슬라임 농장 비용절감(max)";
            B_SlimeFarmCostCutting.SetActive(false);
        }
    }

}
