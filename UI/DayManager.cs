using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour {
    public static DayManager S;

    public Scene_Changer scene_Changer;
    public Sprite[] seasonSprites;
    public Image seasonImage;
    public Text dayText;
    public float time;
    public int day;
    public int month;
    public int year;
    public int changeDay;
    public int changeMonth;
    public int changeYear;
    public Cell[] SlimeFarams;
    public Cell[] TrashStorage;
    public Staff[] allStaff;
    public InsertSlime[] createLines;
    public SellLine[] sellLines;

    public int SlimeFarmMaintenanceCost;
    public int TrashStorageMaintenanceCost;
    public int CreateLineMaintenanceCost;
    public int PackingLineMaintenanceCost;
    public int SellLineMaintenanceCost;



    public bool PopUpEventOn;
    public int recoverNum;
    public int allMaintenanceCost;
    public bool RestFarm;
    public bool RestFactory;
    public bool RestShop;
    public int shopWorkStack;
    public int StaffFireStack;
    public int yearStaffFireStack;
    public int numOfStaff;
    public enum Season
    {
        Spring,Summer,Fall,Winter
    }
     public Season season;
	void Awake () {
		if(S==null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}
    void Start()
    {
        changeDay = 5;
        changeMonth = 20;
        changeYear = 4;
        TrashStorageMaintenanceCost = 100;
        SlimeFarmMaintenanceCost=100;
        CreateLineMaintenanceCost = 150;
        PackingLineMaintenanceCost = 150;
        SellLineMaintenanceCost = 100;
        month = 1;
        DaySet();
        DifficultManager.S.SetDifficult();

    }


    void Update () {
       

        time += 1 * Time.deltaTime;
        if(time>=changeDay)//12초 지날시 날짜하루 지남
        {
            ChangeDay();
        }
        if(day>changeMonth)
        {
            ChangeMonth();
            
        }
       
       
    }

    public int GetSeason()
    {
        return (int)season;
    }
    public void ChangeMonth()
    {
        
        month += 1;
        if (month > changeYear)
        {
            ChangeYear();
        }
        day = 1;
        dayText.text = year.ToString() + "년 " + month.ToString() + "분기 " + day.ToString() + "일";
        MaintenanceCost();
        GetTrash();
         switch (month)
        {
            case 1:
                season = Season.Spring;
                seasonImage.sprite = seasonSprites[0];
                break;
            case 2:
                season = Season.Summer;
                seasonImage.sprite = seasonSprites[1];
                break;
            case 3:
                season = Season.Fall;
                seasonImage.sprite = seasonSprites[2];
                break;
            case 4:
                season = Season.Winter;
                seasonImage.sprite = seasonSprites[3];
                break;
        }
       
        ProductManager.S.ChangeAllPrice();
        Archive.S.ChangeMonth();
        GeneralMeeting.S.AnimalProtectionGroupDIVariation(Random.Range(-6, 6));
        Shop.S.MonthShopCheck();
        CheckFactoryStaffHire();
        RecoverDI();
        RestCheck();
        FireStackCheck();
        Marketing.S.MonthMarketting();
        Management.S.MonthManagement();
        HRDepartment.S.MonthHRDepartment();
        Archive.S.CurrentMoneyGraph();
        Archive.S.GrowMoneyGraph();
        Archive.S.DrawValueGraph();
        Archive.S.DrawFameGraph();
        GeneralMeeting.S.MonthEventCheak();
        for (int i = 0; i < allStaff.Length; i++)
        {
            if(allStaff[i].GetStaffLoyalty()<=40&& allStaff[i].GetStaffOn())
            {
                Shop.S.VariationFame(-40);
            }
        }
        if (DifficultManager.S.gameDifficult==DifficultManager.GameDifficult.hard)
        {
            if (Scenario.S.scenarioMaxNum==3)
            {
                Scenario.S.H_scenario3_month += 1;
            }
            else if(Scenario.S.scenarioMaxNum == 12)
            {
                Scenario.S.H_scenario12_month += 1;
            }
            if (Scenario.S.scenarioMaxNum == 15)
            {
                if (Marketing.S.onGlobalCompany && HRDepartment.S.onHugeCompany && Management.S.onCompanyExpand)
                {
                    Scenario.S.H_scenario15_month += 1;
                }
                else
                {
                    Scenario.S.H_scenario15_month = 0;
                }
            }
            


        }
    }
    public void ChangeDay()
    {
        day += 1;
        dayText.text = year.ToString() + "년 " + month.ToString() + "분기 " + day.ToString() + "일";
        time = 0;
        CompanyValue.S.SetMoneyValue();
        GeneralMeeting.S.DayEventCheck();
    }
    public void ChangeYear()
    {
        
        month = 1;
        year += 1;
        dayText.text = year.ToString() + "년 " + month.ToString() + "분기 " + day.ToString() + "일";

        if (year>1)
        {
            Shop.S.VariationFame(0);//평판매년무조건증가 25
        }
        yearStaffFireStack = 0;
        GeneralMeeting.S.event7_UpgradeNum = 0;
        switch (month)
        {
            case 1:
                season = Season.Spring;
                seasonImage.sprite = seasonSprites[0];
                break;
            case 2:
                season = Season.Summer;
                seasonImage.sprite = seasonSprites[1];
                break;
            case 3:
                season = Season.Fall;
                seasonImage.sprite = seasonSprites[2];
                break;
            case 4:
                season = Season.Winter;
                seasonImage.sprite = seasonSprites[3];
                break;
        }
        //상점 업그레이드 작동
        Management.S.YearManagement();
        GeneralMeeting.S.yearEventCheak();
    }
    public void DaySet()
    {

        dayText.text = year.ToString() + "년 " +month.ToString()+"분기 "+ day.ToString() + "일";
        switch (month)//계절변경 텍스트는 추후 이미지로변경
        {
            case 1:
                season = Season.Spring;
                seasonImage.sprite = seasonSprites[0];
                break;
            case 2:
                season = Season.Summer;
                seasonImage.sprite = seasonSprites[1];
                break;
            case 3:
                season = Season.Fall;
                seasonImage.sprite = seasonSprites[2];
                break;
            case 4:
                season = Season.Winter;
                seasonImage.sprite = seasonSprites[3];
                break;
        }
}

    public void MaintenanceCost()
    {
        for (int i = 0; i < TrashStorage.Length; i++)//원자재 저장소 유지비 처리
        {
            if (TrashStorage[i].gameObject.activeInHierarchy)
            {
                allMaintenanceCost+=250 - (TrashStorageMaintenanceCost / 10 * (FarmUpgrade.S.TrashStorageCostCuttingTier));
                
            }
        }
        Debug.Log("원자재 저장소:" + allMaintenanceCost);
        int slimefarmCost = allMaintenanceCost;
        for (int i = 0; i < SlimeFarams.Length; i++)//슬라임 농장 유지비 처리
        {
            if (SlimeFarams[i].gameObject.activeInHierarchy)
            {
               allMaintenanceCost += SlimeFarmMaintenanceCost - (SlimeFarmMaintenanceCost / 10 *FarmUpgrade.S.SlimeFarmCostCuttingTier);

            }
        }
        Debug.Log("슬라임 농장:" + (allMaintenanceCost - slimefarmCost));
        int shopCost = allMaintenanceCost;
        for (int i = 0; i < sellLines.Length; i++)//상점판매라인 유지비처리
        {
            if (sellLines[i].GetStaff().GetStaffOn())
            {
                allMaintenanceCost += SellLineMaintenanceCost-(SellLineMaintenanceCost / 10*ShopUpgrade.S.SellLineCostCuttingTier);
            }

        }
        Debug.Log("상점:" + (allMaintenanceCost - shopCost));
        int packingCost = allMaintenanceCost;
        int createCost = allMaintenanceCost;
        for (int i = 0; i < createLines.Length; i++)//공장라인 유지비처리
        {

            if (createLines[i].produceStaff.GetStaffOn())
            {
                allMaintenanceCost += CreateLineMaintenanceCost - (CreateLineMaintenanceCost / 10 * FactoryUpgrade.S.LineCostCuttingTier);
            }

        }
        Debug.Log("상점:" + (allMaintenanceCost - createCost));
        for (int i = 0; i < createLines.Length; i++)//공장라인 유지비처리
        { 
            if (createLines[i].packingStaff.GetStaffOn())
            {
                allMaintenanceCost += PackingLineMaintenanceCost - (PackingLineMaintenanceCost / 10 * FactoryUpgrade.S.PackageCostCuttingTier);
            }
        }
        Debug.Log("상점:" + (allMaintenanceCost - packingCost));
        for (int i = 0; i < allStaff.Length; i++)//직원 월급,충성도50이하직원 노동자조합불만증가
        {
            if(allStaff[i].GetStaffOn())
            {
                allMaintenanceCost += allStaff[i].GetStaffSalary();
                
                if (allStaff[i].GetStaffLoyalty() <= 50 && allStaff[i].GetStaffOn()) 
                {
                    GeneralMeeting.S.LaborUnionDIVariation(1);
                }
            }
        }
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                break;
            case DifficultManager.GameDifficult.normal:
                allMaintenanceCost += (allMaintenanceCost * 120) / 100;
                break;
            case DifficultManager.GameDifficult.hard:
                allMaintenanceCost += (allMaintenanceCost * 150) / 100;
                break;
            case DifficultManager.GameDifficult.endless:
                allMaintenanceCost += (allMaintenanceCost * 120) / 100;
                break;
            default:
                break;
        }

        MoneyManager.S.SpendMoney(allMaintenanceCost);
        print("유지비"+allMaintenanceCost);
        Message.S.AddMessage("유지비:" + allMaintenanceCost, Message.MessageType.company);
        allMaintenanceCost = 0;
    }

    public void GetTrash()
    {
        for (int i = 0; i < TrashStorage.Length; i++)//쓰레기 보충
        {
            if (TrashStorage[i].gameObject.activeInHierarchy)
            {
                TrashStorage[i].MakeTrash();
            }

        }
    }

    public void RecoverDI()
    {
        if(!PopUpEventOn)
        {
            recoverNum += 1;
            
            if(recoverNum>2)
            {
                if(recoverNum>5)
                {
                    recoverNum = 5;
                }
                GeneralMeeting.S.GovernmentDIVariation(-(recoverNum - 2));
                GeneralMeeting.S.ConsumerGroupDIVariation(-(recoverNum - 2));
                GeneralMeeting.S.EnvironmentalGroupDIVariation(-(recoverNum - 2));
                GeneralMeeting.S.LaborUnionDIVariation(-(recoverNum - 2));
                GeneralMeeting.S.FDADIVariation(-(recoverNum - 2));

            }

        }
        else
        {
            recoverNum = 1;
            PopUpEventOn = false;
        }
    }
    public void PopupEventCheck()
    {
        PopUpEventOn = true;
    }
    public void CheckFactoryStaffHire()
    {
        for (int i = 0; i < createLines.Length; i++)
        {
            if(createLines[i].produceStaff.GetStaffOn()&&createLines[i].gameObject.activeInHierarchy)
            {
                return;
            }
            if (createLines[i].packingStaff.GetStaffOn() && createLines[i].gameObject.activeInHierarchy)
            {
                return;
            }
        }
        GeneralMeeting.S.LaborUnionDIVariation(5);

    }
    public void RestCheck()
    {
        if (RestFarm)
        {
            RestFarm = false;
        }
        else
        {
            GeneralMeeting.S.GovernmentDIVariation(5);
        }

        if (RestFactory)
        {
            RestFactory = false;
        }
        else
        {
            GeneralMeeting.S.GovernmentDIVariation(5);
        }
        if (RestShop)
        {
            RestShop = false;
            shopWorkStack += 1;
            //Shop.S.VariationFame(6 * shopWorkStack);
        }
        else
        {
            GeneralMeeting.S.GovernmentDIVariation(5);
            GeneralMeeting.S.ConsumerGroupDIVariation(5);
            shopWorkStack = 0;
        }

    }
    public void FarmActive()
    {
        RestFarm = true;
    }
    public void FactoryActive()
    {
        RestFactory = true;
    }
    public void ShopActive()
    {
        RestShop = true;
    }
    public void FireStackCheck()
    {
        if(StaffFireStack>=3)
        {
            GeneralMeeting.S.LaborUnionDIVariation(5 * (StaffFireStack - 2));
        }
        StaffFireStack = 0;
    }
    public int NumOfStaff()
    {
        numOfStaff = 0;
        for (int i = 0; i < allStaff.Length; i++)
        {
            if(allStaff[i].GetStaffOn())
            {
                numOfStaff += 1;
            }
        }
        return numOfStaff;
    }
    public Staff[] AllStaff()
    {
        return allStaff;
    }
    public bool StaffLoyaltyUnderHalf()
    {
        for (int i = 0; i < allStaff.Length; i++)
        {
            if (allStaff[i].GetStaffOn()&&allStaff[i].GetStaffLoyalty()<50)
            {
                return true;
            }
        }
        return false;
    }




}
