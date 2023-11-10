using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveData
{

    // 저장시간

    public int realYear;
    public int realMonth;
    public int realDay;
    public int realMinute;
    public int realSecond;
    //게임난이도 저장
    public int gameDifficult;

    //슬라임 도감 저장
    public bool[] G_S = new bool[5];
    public bool[] B_S = new bool[5];
    public bool[] Y_S = new bool[5];
    public bool[] R_S = new bool[5];
    public bool[] N_S = new bool[2];

    public bool[] G_M = new bool[5];
    public bool[] B_M = new bool[5];
    public bool[] Y_M = new bool[5];
    public bool[] R_M = new bool[5];
    public bool[] N_M = new bool[1];
    //슬라임 농장 저장

    public List<string> trashName = new List<string>();
    public List<int> remainItemNum = new List<int>();
    public List<string> resultSlime =new List<string>();
    public List<float> remainTime = new List<float>();

    //공장 저장
        //생산라인
    public List<int> createItemStackNum = new List<int>();
    public List<float> moveItemStackTime = new List<float>();
    public List<int> createproductType = new List<int>();
    //포장라인
    public List<int> packageItemStackNum = new List<int>();
    public List<float> packageTime = new List<float>();
    public List<int> packageProductType = new List<int>();

    //직원 저장 
    public List<bool> StaffOn = new List<bool>();
    public List<string> StaffName = new List<string>();
    public List<int> loyalty = new List<int>();
    public List<int> salary = new List<int>();
    public List<int> hireYear = new List<int>();
    public List<float> hireTime = new List<float>();
    public List<int> companyValue = new List<int>();
    //상점 저장
    public float fame;
    public float newCustomerTime;
    public int pastMonthCustomer;
    public int shopStaffNum;
    //가판대 저장
    public List<int> consumer = new List<int>();
    public List<float> sellTime = new List<float>();
    public List<int> sellItemKind = new List<int>();
    

    //DayManager
    public int day;
    public int month;
    public int year;
    public float daytime;
    public int SlimeFarmMaintenanceCost;
    public int TrashStorageMaintenanceCost;

    public bool popUpEventOn;
    public int recoverNum;
    public bool RestFarm;
    public bool RestFactory;
    public bool RestShop;
    public int shopWorkStack;
    public int StaffFireStack;
    public int yearStaffFireStack;
    public int numOfStaff;

    // ProductManager
    public int drugs;
    public int ice;
    public int glass;
    public int fuel;
    public float ChangePriceNum;

    public List<string> SlimeName=new List<string>();
    public List<int> SlimeNum=new List<int>();

    public List<string> TrashName=new List<string>();
    public List<int> TrashNum=new List<int>();

    public int money;
    //FarmUpgrade
    public int OpenSlimeFarmCost;
    public int OpenSlimeFarmTier;
    public int OpenTrashStorageCost;
    public int OpenTrashStorageTier;
    public int TrashQualityUpCost;
    public int TrashQualityUpTier;
    public int TrashStorageCostCuttingCost;
    public int TrashStorageCostCuttingTier;
    public int SlimeQualityUpCost;
    public int SlimeQualityUpTier;
    public int TwinSlimeCost;
    public int TwinSlimeTier;
    public int SlimeFarmCostCuttingCost;
    public int SlimeFarmCostCuttingTier;
    public bool OnIllegalityBuyMaterial;
    public bool OnGeneManipulationInjection;
    //FactoryUpgrade
    public int OpenCreateLineCost;
    public int OpenCreateLineTier;
    public int CreateFasterCost;
    public int CreateFasterTier;
    public int MoreCreateCost;
    public int MoreCreateTier;
    public int LineCostCuttingCost;
    public int LineCostCuttingTier;
    public int ProductQualityUpCost;
    public int ProductQualityUpTier;
    public int MorePackageCost;
    public int MorePackageTier;
    public int PackageFasterCost;
    public int PackageFasterTier;
    public int PackageCostCuttingCost;
    public int PackageCostCuttingTier;
    //ShopUpgrade
    public int ProductAdvertisingCost;
    public int ProductAdvertisingTier;
    public int ShopAdvertisingCost;
    public int ShopAdvertisingTier;
    public int SellLineCostCuttingCost;
    public int SellLineCostCuttingTier;
    public int InteriorReformationCost;
    public int InteriorReformationTier;
    public int ControlDemandAndSupplyCost;
    public int ControlDemandAndSupplyTier;

    //기관불만
    public float governmentDI;
    public float consumerGroupDI;
    public float environmentalGroupDI;
    public float laborUnionDI;
    public float FDADI;
    public float AnimalProtectionGroupDI;


    //이벤트관련
    public int event7_Num;
    public bool event3_Active;
    public int event7_UpgradeNum;
    public int illegality_Stack;
    public int tier5Material;
    public int useGraySlime;
    public int useKingSlime;
    public int event6_Num;
    public int event8_Num;
    public int event9_Num;
    public int event12_Num;

    //인사

    public int HRDepartmentTier;
    public int HRDepartmentUpgradePrice;
    public bool onInterviewHire;
    public bool onCompanyWelfare;
    public bool onCompanyInsurance;
    public bool onPublicEmployment;
    public bool onPayBonus;
    public bool onRegularRetirement;
    public bool onHireDisabledPersons;
    public bool onListedCompany;
    public bool onPensionSystem;
    public bool onHugeCompany;
    public bool isPayHugeCompany;
    public int HugeCompanyStack;

    //마케팅
    public int markettingTier;
    public int MarketingUpgradePrice;
    public bool onGreenfoodBusiness;
    public bool onFreeGift;
    public bool onMascot;
    public bool onEco_FriendlyMaterials;
    public bool onCouponMarketing;
    public bool onMascotAD;
    public bool onUseLocalMaterialAD;
    public bool onDiscountDayEvent;
    public bool onCollaboration;
    public bool onGlobalCompany;
    public int globalCompanyStack;

    //경영
    public int ManagementTier;
    public int ManagementUpgradePrice;
    public bool onGovernmentAlliesPlan;
    public bool onScholarshipInvest;
    public bool onSubcontractorContract;
    public bool onBribeNationalAssemblyMemberb;
    public bool onReliefActivities;
    public bool onEstablishSubsidiaryCompany;
    public int EstablishSubsidiaryCompanyCost;
    public int onEstablishSubsidiaryCompanyYear;//활성화한 기간
    public int offEstablishSubsidiaryCompanyYear;//비활성화한 기간
    public bool onWithdrawalShares;
    public bool onEmployeeWelfare;
    public bool onCompanyExpand;
    public int CompanyExpandCost;
    public int offCompanyExpandYear;
    public bool onAnarchyCompany;

    //시나리오

    public int scenarioCurNum;//현재 시나리오 번호
    public int scenarioMaxNum;//진행중인 시나리오 번호
    public bool scenarioComplete;

    public int E_scenario8_createNum;
    public int E_scenario18_SellNum;

    public int scenario2_coal;
    public int scenario2_scrab;
    public int scenario2_compost;
    public int scenario4_createNum;
    public int scenario6_sellNum;

    public int N_scenario2_CreateNum;
    public int N_scenario3_SellNum;
    public int N_scenario6_CreateNum;
    public int N_scenario7_SellNum;

    public int H_scenario1_SellNum;
    public int H_scenario3_month;
    public int H_scenario9_Sellnum;
    public int H_scenario12_month;
    public int H_scenario15_month;
    public int H_scenario17_FireNum;
    public int H_scenario18_month;

    //기록소
    public int[] monthProfits;//달 이익
    public int[] monthSpendMoney; //달 소비
    public int[] monthGetMoney; //달 얻은돈
    public int[] haveMoney;//가지고있는돈
    public int[] earnMoney;
    public int MaxCurrentMoney;
    public int MinCurrentMoney;
    public int MaxGrowMoney;
    public int MinGrowMoney;

    public int[] Value;
    public int maxCompanyValue;

    public int[] material;
    public int[] materialTier1;
    public int[] materialTier2;
    public int[] materialTier3;
    public int[] materialTier4;
    public int[] materialTier5;
    public int[] materialTier6;

    public int[] Slime;
    public int[] graySlime;
    public int[] Slime1;
    public int[] Slime2;
    public int[] Slime3;
    public int[] Slime4;
    public int[] Slime5;
    public int[] Slime6;
    public int[] TwinSlime;

    public int[] Fame;

    public int[] Product;
    public int[] Drugs;
    public int[] Ice;
    public int[] Glass;
    public int[] Fuel;
}
public class SlimeBookData
{
    public bool[] G_S = new bool[5];
    public bool[] B_S = new bool[5];
    public bool[] Y_S = new bool[5];
    public bool[] R_S = new bool[5];
    public bool[] N_S = new bool[2];

    public bool[] G_M = new bool[5];
    public bool[] B_M = new bool[5];
    public bool[] Y_M = new bool[5];
    public bool[] R_M = new bool[5];
    public bool[] N_M = new bool[1];
}
public class SaveNLoad : MonoBehaviour
{
    private SaveData saveData = new SaveData();
    private SlimeBookData slimeBook = new SlimeBookData();
    private string SAVE_DATA_DIRECTORY;
    private string SAVE_FILENAME = "SaveFile.txt";
    private string SAVEBOOK_FILENAME = "SlimeBook.txt";
    public Inventory inven;
    public static bool IsLoad;
    public static int LoadNum;
    public static int SaveNum;

    // Start is called before the f1irst frame update
    void Start()
    {
       
        SAVE_DATA_DIRECTORY = Application.persistentDataPath + "/Saves/";
        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }
        if(IsLoad)
        {
            LoadData(LoadNum);
            IsLoad = false;
        }
    }
    
    public void SaveData(int _num=1)
    {

        //저장시간 저장
        saveData.realYear = System.DateTime.Now.Year;
        saveData.realMonth = System.DateTime.Now.Month;
        saveData.realDay = System.DateTime.Now.Day;
        saveData.realMinute = System.DateTime.Now.Minute;
        saveData.realSecond = System.DateTime.Now.Second;

        //게임난이도 저장
        
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                saveData.gameDifficult = 0;
                break;
            case DifficultManager.GameDifficult.normal:
                saveData.gameDifficult = 1;
                break;
            case DifficultManager.GameDifficult.hard:
                saveData.gameDifficult = 2;
                break;
            case DifficultManager.GameDifficult.endless:
                saveData.gameDifficult = 3;
                break;
            default:
                break;
        }

        //슬라임 도감 저장
        saveData.G_S = SlimeBook.S.slime.G;
        saveData.B_S = SlimeBook.S.slime.B;
        saveData.Y_S = SlimeBook.S.slime.Y;
        saveData.R_S = SlimeBook.S.slime.R;
        saveData.N_S = SlimeBook.S.slime.N;

        saveData.G_M = SlimeBook.S.material.G;
        saveData.B_M = SlimeBook.S.material.B;
        saveData.Y_M = SlimeBook.S.material.Y;
        saveData.R_M = SlimeBook.S.material.R;
        saveData.N_M = SlimeBook.S.material.N;
        SaveTitleSlimeBook();

        //농장 저장
        saveData.trashName.Clear();
        saveData.remainItemNum.Clear();
        saveData.resultSlime.Clear();
        saveData.remainTime.Clear();
        for (int i = 0; i < DayManager.S.SlimeFarams.Length; i++)
        {
            if(DayManager.S.SlimeFarams[i].item!=null)
            {
                saveData.trashName.Add(DayManager.S.SlimeFarams[i].item.itemName);
            }
            else
            {
                saveData.trashName.Add(null);
            }
            saveData.remainItemNum.Add(DayManager.S.SlimeFarams[i].remainItemNum);
            if(DayManager.S.SlimeFarams[i].resultSlime!=null)
            {
                saveData.resultSlime.Add(DayManager.S.SlimeFarams[i].resultSlime.itemName);
            }
            else
            {
                saveData.resultSlime.Add(null);
            }
            
            saveData.remainTime.Add(DayManager.S.SlimeFarams[i].remainTime);
        }

        //공장 저장
        saveData.createItemStackNum.Clear();
        saveData.moveItemStackTime.Clear();
        saveData.createproductType.Clear();
        saveData.packageItemStackNum.Clear();
        saveData.packageTime.Clear();
        saveData.packageProductType.Clear();
        for (int i = 0; i < DayManager.S.createLines.Length; i++)
        {
            saveData.createItemStackNum.Add(DayManager.S.createLines[i].itemStack);
            saveData.moveItemStackTime.Add(DayManager.S.createLines[i].moveItemStackTime);
            saveData.createproductType.Add(DayManager.S.createLines[i].GetCreateProductType());
            saveData.packageItemStackNum.Add(DayManager.S.createLines[i].packageItemStack);
            saveData.packageTime.Add(DayManager.S.createLines[i].packageTime);
            saveData.packageProductType.Add(DayManager.S.createLines[i].GetPackageProductType());
        }

        //상정 저장
        saveData.fame = Shop.S.fame;
        saveData.newCustomerTime = Shop.S.newCustomerTime;
        saveData.pastMonthCustomer = Shop.S.pastMonthCustomer;
        saveData.shopStaffNum = Shop.S.shopStaffNum;

        //직원저장
        saveData.StaffOn.Clear();
        saveData.StaffName.Clear();
        saveData.loyalty.Clear();
        saveData.hireYear.Clear();
        saveData.hireTime.Clear();
        saveData.salary.Clear();
        saveData.companyValue.Clear();
        for (int i = 0; i < DayManager.S.allStaff.Length; i++)
        {
            saveData.StaffOn.Add(DayManager.S.allStaff[i].GetStaffOn());
            saveData.StaffName.Add(DayManager.S.allStaff[i].GetStaffName());
            saveData.loyalty.Add(DayManager.S.allStaff[i].GetStaffLoyalty());
            saveData.hireYear.Add(DayManager.S.allStaff[i].hireYear);
            saveData.hireTime.Add(DayManager.S.allStaff[i].hireTime);
            saveData.salary.Add(DayManager.S.allStaff[i].GetStaffSalary());
            saveData.companyValue.Add(DayManager.S.allStaff[i].companyValue);
        }

        //가판대 저장
        saveData.consumer.Clear();
        saveData.sellTime.Clear();
        saveData.sellItemKind.Clear();
        for (int i = 0; i < DayManager.S.sellLines.Length; i++)
        {
            saveData.consumer.Add(DayManager.S.sellLines[i].consumer);
            saveData.sellTime.Add(DayManager.S.sellLines[i].sellTime);
            saveData.sellItemKind.Add(DayManager.S.sellLines[i].GetSellItemKind());
        }
        
        saveData.day = DayManager.S.day;
        saveData.month = DayManager.S.month;
        saveData.year = DayManager.S.year;
        saveData.daytime = DayManager.S.time;
        saveData.SlimeFarmMaintenanceCost = DayManager.S.SlimeFarmMaintenanceCost;
        saveData.TrashStorageMaintenanceCost = DayManager.S.TrashStorageMaintenanceCost;

        saveData.popUpEventOn = DayManager.S.PopUpEventOn;
        saveData.recoverNum = DayManager.S.recoverNum;
        saveData.RestFarm = DayManager.S.RestFarm;
        saveData.RestFactory = DayManager.S.RestFactory;
        saveData.RestShop = DayManager.S.RestShop;
        saveData.shopWorkStack = DayManager.S.shopWorkStack;
        saveData.StaffFireStack = DayManager.S.StaffFireStack;
        saveData.yearStaffFireStack = DayManager.S.yearStaffFireStack;
        saveData.numOfStaff = DayManager.S.numOfStaff;

        saveData.drugs = ProductManager.S.DrugNum();
        saveData.ice = ProductManager.S.IceNum();
        saveData.glass = ProductManager.S.GlassNum();
        saveData.fuel = ProductManager.S.FuelNum();
        saveData.ChangePriceNum = ProductManager.S.ChangePriceNum;

        saveData.money = MoneyManager.S.CurrentMoney();

        saveData.OpenSlimeFarmTier = FarmUpgrade.S.OpenSlimeFarmTier;
        saveData.OpenSlimeFarmCost = FarmUpgrade.S.OpenSlimeFarmCost;
        saveData.OpenTrashStorageCost = FarmUpgrade.S.OpenTrashStorageCost;
        saveData.OpenTrashStorageTier = FarmUpgrade.S.OpenTrashStorageTier;
        saveData.TrashQualityUpCost = FarmUpgrade.S.TrashQualityUpCost;
        saveData.TrashQualityUpTier = FarmUpgrade.S.TrashQualityUpTier;
        saveData.TrashStorageCostCuttingCost = FarmUpgrade.S.TrashStorageCostCuttingCost;
        saveData.TrashStorageCostCuttingTier = FarmUpgrade.S.TrashStorageCostCuttingTier;
        saveData.TwinSlimeCost = FarmUpgrade.S.TwinSlimeCost;
        saveData.TwinSlimeTier = FarmUpgrade.S.TwinSlimeTier;
        saveData.SlimeFarmCostCuttingCost = FarmUpgrade.S.SlimeFarmCostCuttingCost;
        saveData.SlimeFarmCostCuttingTier = FarmUpgrade.S.SlimeFarmCostCuttingTier;


        saveData.CreateFasterTier = FactoryUpgrade.S.CreateFasterTier;
        saveData.CreateFasterCost = FactoryUpgrade.S.CreateFasterCost;
        saveData.MoreCreateTier = FactoryUpgrade.S.MoreCreateTier;
        saveData.MoreCreateCost = FactoryUpgrade.S.MoreCreateCost;
        saveData.LineCostCuttingTier = FactoryUpgrade.S.LineCostCuttingTier;
        saveData.LineCostCuttingCost = FactoryUpgrade.S.LineCostCuttingCost;
        saveData.ProductQualityUpTier = FactoryUpgrade.S.ProductQualityUpTier;
        saveData.ProductQualityUpCost = FactoryUpgrade.S.ProductQualityUpCost;
        saveData.MorePackageCost = FactoryUpgrade.S.MorePackageCost;
        saveData.MorePackageTier = FactoryUpgrade.S.MorePackageTier;
        saveData.PackageFasterCost = FactoryUpgrade.S.PackageFasterCost;
        saveData.PackageFasterTier = FactoryUpgrade.S.PackageFasterTier;
        saveData.PackageCostCuttingCost = FactoryUpgrade.S.PackageCostCuttingCost;
        saveData.PackageCostCuttingTier = FactoryUpgrade.S.PackageCostCuttingTier;



        saveData.ProductAdvertisingCost = ShopUpgrade.S.ProductAdvertisingCost;
        saveData.ProductAdvertisingTier = ShopUpgrade.S.ProductAdvertisingTier;
        saveData.ShopAdvertisingCost = ShopUpgrade.S.ShopAdvertisingCost;
        saveData.ShopAdvertisingTier = ShopUpgrade.S.ShopAdvertisingTier;
        saveData.SellLineCostCuttingCost = ShopUpgrade.S.SellLineCostCuttingCost;
        saveData.SellLineCostCuttingTier = ShopUpgrade.S.SellLineCostCuttingTier;
        saveData.InteriorReformationCost = ShopUpgrade.S.InteriorReformationCost;
        saveData.InteriorReformationTier = ShopUpgrade.S.InteriorReformationTier;
        saveData.ControlDemandAndSupplyCost = ShopUpgrade.S.ControlDemandAndSupplyCost;
        saveData.ControlDemandAndSupplyTier = ShopUpgrade.S.ControlDemandAndSupplyTier;


        saveData.governmentDI = GeneralMeeting.S.governmentDI;
        saveData.consumerGroupDI = GeneralMeeting.S.consumerGroupDI;
        saveData.environmentalGroupDI = GeneralMeeting.S.environmentalGroupDI;
        saveData.laborUnionDI = GeneralMeeting.S.laborUnionDI;
        saveData.FDADI = GeneralMeeting.S.FDADI;
        saveData.AnimalProtectionGroupDI = GeneralMeeting.S.AnimalProtectionGroupDI;


        saveData.event7_Num = GeneralMeeting.S.event7_Num;
        saveData.event3_Active = GeneralMeeting.S.event3_Active;

        saveData.illegality_Stack = GeneralMeeting.S.illegality_Stack;
        saveData.event7_UpgradeNum = GeneralMeeting.S.event7_UpgradeNum;
        saveData.tier5Material = GeneralMeeting.S.tier5Material;
        saveData.useGraySlime = GeneralMeeting.S.useGraySlime;
        saveData.useKingSlime = GeneralMeeting.S.useKingSlime;
        saveData.event6_Num = GeneralMeeting.S.event6_Num;
        saveData.event8_Num = GeneralMeeting.S.event8_Num;
        saveData.event9_Num = GeneralMeeting.S.event9_Num;
        saveData.event12_Num = GeneralMeeting.S.event12_Num;

        saveData.scenarioCurNum = Scenario.S.scenarioCurNum;
        saveData.scenarioMaxNum = Scenario.S.scenarioMaxNum;
        saveData.scenario2_coal = Scenario.S.scenario2_coal;
        saveData.scenario2_scrab = Scenario.S.scenario2_scrab;
        saveData.scenario2_compost = Scenario.S.scenario2_compost;
        saveData.scenario4_createNum = Scenario.S.scenario4_createNum;
        saveData.scenario6_sellNum = Scenario.S.scenario6_sellNum;

        saveData.N_scenario2_CreateNum = Scenario.S.N_scenario2_CreateNum;
        saveData.N_scenario3_SellNum = Scenario.S.N_scenario3_SellNum;
        saveData.N_scenario6_CreateNum = Scenario.S.N_scenario6_CreateNum;
        saveData.N_scenario7_SellNum = Scenario.S.N_scenario7_SellNum;

        saveData.E_scenario18_SellNum = Scenario.S.E_scenario18_SellNum;
        saveData.E_scenario8_createNum = Scenario.S.E_scenario8_createNum;

        saveData.H_scenario1_SellNum = Scenario.S.H_scenario1_SellNum;
        saveData.H_scenario3_month = Scenario.S.H_scenario3_month;
        saveData.H_scenario9_Sellnum = Scenario.S.H_scenario9_Sellnum;
        saveData.H_scenario12_month = Scenario.S.H_scenario12_month;
        saveData.H_scenario15_month = Scenario.S.H_scenario15_month;
        saveData.H_scenario17_FireNum = Scenario.S.H_scenario17_FireNum;
        saveData.H_scenario18_month = Scenario.S.H_scenario18_month;


        saveData.HRDepartmentTier = HRDepartment.S.HRDepartmentTier;
        saveData.HRDepartmentUpgradePrice = HRDepartment.S.UpgradePrice;
        saveData.onInterviewHire = HRDepartment.S.onInterviewHire;
        saveData.onCompanyWelfare = HRDepartment.S.onCompanyWelfare;
        saveData.onCompanyInsurance = HRDepartment.S.onCompanyInsurance;
        saveData.onPublicEmployment = HRDepartment.S.onPublicEmployment;
        saveData.onPayBonus = HRDepartment.S.onPayBonus;
        saveData.onRegularRetirement = HRDepartment.S.onRegularRetirement;
        saveData.onListedCompany = HRDepartment.S.onListedCompany;
        saveData.onPensionSystem = HRDepartment.S.onPensionSystem;
        saveData.onHugeCompany = HRDepartment.S.onHugeCompany;
        saveData.HugeCompanyStack = HRDepartment.S.HugeCompanyStack;

        saveData.markettingTier = Marketing.S.markettingTier;
        saveData.MarketingUpgradePrice = Marketing.S.UpgradePrice;
        saveData.onGreenfoodBusiness = Marketing.S.onGreenfoodBusiness;
        saveData.onFreeGift = Marketing.S.onFreeGift;
        saveData.onMascot = Marketing.S.onMascot;
        saveData.onEco_FriendlyMaterials = Marketing.S.onEco_FriendlyMaterials;
        saveData.onCouponMarketing = Marketing.S.onCouponMarketing;
        saveData.onMascotAD = Marketing.S.onMascotAD;
        saveData.onUseLocalMaterialAD = Marketing.S.onUseLocalMaterialAD;
        saveData.onDiscountDayEvent = Marketing.S.onDiscountDayEvent;
        saveData.onCollaboration = Marketing.S.onCollaboration;
        saveData.onGlobalCompany = Marketing.S.onGlobalCompany;
        saveData.globalCompanyStack = Marketing.S.globalCompanyStack;

        saveData.ManagementTier = Management.S.ManagementTier;
        saveData.ManagementUpgradePrice = Management.S.UpgradePrice;
        saveData.onGovernmentAlliesPlan = Management.S.onGovernmentAlliesPlan;
        saveData.onScholarshipInvest = Management.S.onScholarshipInvest;
        saveData.onSubcontractorContract = Management.S.onSubcontractorContract;
        saveData.onBribeNationalAssemblyMemberb = Management.S.onBribeNationalAssemblyMemberb;
        saveData.onReliefActivities = Management.S.onReliefActivities;
        saveData.onEstablishSubsidiaryCompany = Management.S.onEstablishSubsidiaryCompany;
        saveData.onWithdrawalShares = Management.S.onWithdrawalShares;
        saveData.onEmployeeWelfare = Management.S.onEmployeeWelfare;
        saveData.onCompanyExpand = Management.S.onCompanyExpand;
        saveData.onAnarchyCompany = Management.S.onAnarchyCompany;

        saveData.monthProfits = Archive.S.monthProfits;
        saveData.monthSpendMoney = Archive.S.monthSpendMoney;
        saveData.monthGetMoney = Archive.S.monthGetMoney;
        saveData.haveMoney = Archive.S.haveMoney;
        saveData.earnMoney = Archive.S.earnMoney;
        saveData.MaxCurrentMoney = Archive.S.MaxCurrentMoney;
        saveData.MinCurrentMoney = Archive.S.MinCurrentMoney;
        saveData.MaxGrowMoney = Archive.S.MaxGrowMoney;
        saveData.MinGrowMoney = Archive.S.MinGrowMoney;

        saveData.material = Archive.S.material;
        saveData.materialTier1 = Archive.S.materialTier1;
        saveData.materialTier2 = Archive.S.materialTier2;
        saveData.materialTier3 = Archive.S.materialTier3;
        saveData.materialTier4 = Archive.S.materialTier4;
        saveData.materialTier5 = Archive.S.materialTier5;
        saveData.materialTier6 = Archive.S.materialTier6;

        saveData.Slime = Archive.S.Slime;
        saveData.graySlime = Archive.S.graySlime;
        saveData.Slime1 = Archive.S.Slime1;
        saveData.Slime2 = Archive.S.Slime2;
        saveData.Slime3 = Archive.S.Slime3;
        saveData.Slime4 = Archive.S.Slime4;
        saveData.Slime5 = Archive.S.Slime5;
        saveData.Slime6 = Archive.S.Slime6;
        saveData.TwinSlime = Archive.S.TwinSlime;

        saveData.Fame = Archive.S.Fame;
        saveData.Product = Archive.S.Product;
        saveData.Drugs = Archive.S.Drugs;
        saveData.Ice = Archive.S.Ice;
        saveData.Glass = Archive.S.Glass;
        saveData.Fuel = Archive.S.Fuel;

        saveData.Value = Archive.S.Value;
        saveData.maxCompanyValue = Archive.S.maxCompanyValue;




    saveData.SlimeName.Clear();
        saveData.SlimeNum.Clear();
        Slot[] slimeSlots = inven.GetSlimeSlot();
        for (int i = 0; i < slimeSlots.Length; i++)
        {
            if(slimeSlots[i].item!=null)
            {
                print(slimeSlots[i].itemName);
                print(slimeSlots[i].itemCount);
                saveData.SlimeName.Add(slimeSlots[i].itemName);
                saveData.SlimeNum.Add(slimeSlots[i].itemCount);
            }
            
        }
        saveData.TrashName.Clear();
        saveData.TrashNum.Clear();
       Slot[] trashSlots = inven.GetTrashSlot();
        for (int i = 0; i < trashSlots.Length; i++)
        {
            if(trashSlots[i].item!=null)
            {
                saveData.TrashName.Add(trashSlots[i].itemName);
                saveData.TrashNum.Add(trashSlots[i].itemCount);
                
                
            }
            
        }

        string json = JsonUtility.ToJson(saveData,true);
        
        File.WriteAllText(SAVE_DATA_DIRECTORY + _num.ToString()+ SAVE_FILENAME, json);

        
    }
    public void LoadData(int _num=1)
    {
        
        if (File.Exists(SAVE_DATA_DIRECTORY + _num.ToString() + SAVE_FILENAME))
        {
            SaveNum = _num;
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + _num.ToString() + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            DifficultManager.S.SetDifficultValue(saveData.gameDifficult);



            DayManager.S.day = saveData.day;
            DayManager.S.month = saveData.month;
            DayManager.S.year = saveData.year;
            DayManager.S.time = saveData.daytime;
            DayManager.S.SlimeFarmMaintenanceCost=saveData.SlimeFarmMaintenanceCost;
            DayManager.S.TrashStorageMaintenanceCost=saveData.TrashStorageMaintenanceCost ;
            DayManager.S.DaySet();

            DayManager.S.PopUpEventOn=saveData.popUpEventOn;
            DayManager.S.recoverNum=saveData.recoverNum;
            DayManager.S.RestFarm=saveData.RestFarm;
            DayManager.S.RestFactory=saveData.RestFactory;
            DayManager.S.RestShop=saveData.RestShop;
            DayManager.S.shopWorkStack=saveData.shopWorkStack;
            DayManager.S.StaffFireStack=saveData.StaffFireStack;
            DayManager.S.yearStaffFireStack=saveData.yearStaffFireStack;
            DayManager.S.numOfStaff=saveData.numOfStaff ;

            FarmUpgrade.S.OpenSlimeFarmTier=saveData.OpenSlimeFarmTier;
            FarmUpgrade.S.OpenSlimeFarmCost=saveData.OpenSlimeFarmCost ;
            FarmUpgrade.S.OpenTrashStorageCost=saveData.OpenTrashStorageCost;
            FarmUpgrade.S.OpenTrashStorageTier=saveData.OpenTrashStorageTier;
            FarmUpgrade.S.TrashQualityUpCost=saveData.TrashQualityUpCost;
            FarmUpgrade.S.TrashQualityUpTier=saveData.TrashQualityUpTier;
            FarmUpgrade.S.TrashStorageCostCuttingCost=saveData.TrashStorageCostCuttingCost;
            FarmUpgrade.S.TrashStorageCostCuttingTier=saveData.TrashStorageCostCuttingTier;
            FarmUpgrade.S.TwinSlimeCost=saveData.TwinSlimeCost;
            FarmUpgrade.S.TwinSlimeTier=saveData.TwinSlimeTier;
            FarmUpgrade.S.SlimeFarmCostCuttingCost=saveData.SlimeFarmCostCuttingCost;
            FarmUpgrade.S.SlimeFarmCostCuttingTier=saveData.SlimeFarmCostCuttingTier;
            FarmUpgrade.S.FarmUpgradeSet();

            SlimeBook.S.slime.G = saveData.G_S;
            SlimeBook.S.slime.B=saveData.B_S ;
            SlimeBook.S.slime.Y=saveData.Y_S ;
            SlimeBook.S.slime.R=saveData.R_S ;
            SlimeBook.S.slime.N=saveData.N_S ;

            SlimeBook.S.material.G=saveData.G_M ;
            SlimeBook.S.material.B=saveData.B_M ;
            SlimeBook.S.material.Y=saveData.Y_M ;
            SlimeBook.S.material.R=saveData.R_M ;
            SlimeBook.S.material.N=saveData.N_M ;

            FactoryUpgrade.S.CreateFasterTier=saveData.CreateFasterTier;
            FactoryUpgrade.S.CreateFasterCost=saveData.CreateFasterCost;
            FactoryUpgrade.S.MoreCreateTier=saveData.MoreCreateTier;
            FactoryUpgrade.S.MoreCreateCost=saveData.MoreCreateCost ;
            FactoryUpgrade.S.LineCostCuttingTier=saveData.LineCostCuttingTier;
            FactoryUpgrade.S.LineCostCuttingCost=saveData.LineCostCuttingCost;
            FactoryUpgrade.S.ProductQualityUpTier=saveData.ProductQualityUpTier;
            FactoryUpgrade.S.ProductQualityUpCost = saveData.ProductQualityUpCost;
            FactoryUpgrade.S.MorePackageCost=saveData.MorePackageCost ;
            FactoryUpgrade.S.MorePackageTier=saveData.MorePackageTier ;
            FactoryUpgrade.S.PackageFasterCost=saveData.PackageFasterCost;
            FactoryUpgrade.S.PackageFasterTier=saveData.PackageFasterTier ;
            FactoryUpgrade.S.PackageCostCuttingCost=saveData.PackageCostCuttingCost ;
            FactoryUpgrade.S.PackageCostCuttingTier=saveData.PackageCostCuttingTier;
            FactoryUpgrade.S.FactoryUpgradeSet();

            ShopUpgrade.S.SellLineCostCuttingCost=saveData.SellLineCostCuttingCost;
            ShopUpgrade.S.SellLineCostCuttingTier=saveData.SellLineCostCuttingTier;
            ShopUpgrade.S.ProductAdvertisingCost=saveData.ProductAdvertisingCost ;
            ShopUpgrade.S.ProductAdvertisingTier=saveData.ProductAdvertisingTier ;
            ShopUpgrade.S.ShopAdvertisingCost=saveData.ShopAdvertisingCost ;
            ShopUpgrade.S.ShopAdvertisingTier=saveData.ShopAdvertisingTier;
            ShopUpgrade.S.InteriorReformationCost=saveData.InteriorReformationCost;
            ShopUpgrade.S.InteriorReformationTier=saveData.InteriorReformationTier;
            ShopUpgrade.S.ControlDemandAndSupplyCost=saveData.ControlDemandAndSupplyCost ;
            ShopUpgrade.S.ControlDemandAndSupplyTier=saveData.ControlDemandAndSupplyTier ;
            ShopUpgrade.S.ShopUpgradeSet();

            GeneralMeeting.S.governmentDI=saveData.governmentDI;
            GeneralMeeting.S.consumerGroupDI=saveData.consumerGroupDI;
            GeneralMeeting.S.environmentalGroupDI=saveData.environmentalGroupDI ;
            GeneralMeeting.S.laborUnionDI=saveData.laborUnionDI;
            GeneralMeeting.S.FDADI=saveData.FDADI;
            GeneralMeeting.S.AnimalProtectionGroupDI=saveData.AnimalProtectionGroupDI;
            GeneralMeeting.S.DIImageUpdate();

            GeneralMeeting.S.event7_Num = saveData.event7_Num;
            GeneralMeeting.S.event3_Active= saveData.event3_Active;
            GeneralMeeting.S.illegality_Stack = saveData.illegality_Stack;
            GeneralMeeting.S.event7_UpgradeNum=saveData.event7_UpgradeNum ;
            GeneralMeeting.S.tier5Material=saveData.tier5Material;
            GeneralMeeting.S.useGraySlime=saveData.useGraySlime ;
            GeneralMeeting.S.useKingSlime=saveData.useKingSlime ;
            GeneralMeeting.S.event6_Num=saveData.event6_Num ;
            GeneralMeeting.S.event8_Num=saveData.event8_Num ;
            GeneralMeeting.S.event9_Num=saveData.event9_Num ;
            GeneralMeeting.S.event12_Num=saveData.event12_Num;



            HRDepartment.S.HRDepartmentTier=saveData.HRDepartmentTier;
            HRDepartment.S.UpgradePrice=saveData.HRDepartmentUpgradePrice;
            HRDepartment.S.onInterviewHire=saveData.onInterviewHire ;
            HRDepartment.S.onCompanyWelfare=saveData.onCompanyWelfare;
            HRDepartment.S.onCompanyInsurance=saveData.onCompanyInsurance ;
            HRDepartment.S.onPublicEmployment=saveData.onPublicEmployment;
            HRDepartment.S.onPayBonus=saveData.onPayBonus ;
            HRDepartment.S.onRegularRetirement=saveData.onRegularRetirement ;
            HRDepartment.S.onListedCompany=saveData.onListedCompany;
            HRDepartment.S.onPensionSystem=saveData.onPensionSystem ;
            HRDepartment.S.onHugeCompany=saveData.onHugeCompany;
            HRDepartment.S.HugeCompanyStack = saveData.HugeCompanyStack;
            HRDepartment.S.SetHRDepartment();

            Marketing.S.markettingTier = saveData.markettingTier;
            Marketing.S.UpgradePrice=saveData.MarketingUpgradePrice;
            Marketing.S.onGreenfoodBusiness=saveData.onGreenfoodBusiness;
            Marketing.S.onFreeGift=saveData.onFreeGift;
            Marketing.S.onMascot=saveData.onMascot ;
            Marketing.S.onEco_FriendlyMaterials=saveData.onEco_FriendlyMaterials ;
            Marketing.S.onCouponMarketing=saveData.onCouponMarketing ;
            Marketing.S.onMascotAD=saveData.onMascotAD ;
            Marketing.S.onUseLocalMaterialAD=saveData.onUseLocalMaterialAD ;
            Marketing.S.onDiscountDayEvent=saveData.onDiscountDayEvent ;
            Marketing.S.onCollaboration=saveData.onCollaboration;
            Marketing.S.onGlobalCompany=saveData.onGlobalCompany;
            Marketing.S.globalCompanyStack = saveData.globalCompanyStack;
            Marketing.S.SetMarketing();

            Management.S.ManagementTier=saveData.ManagementTier ;
            Management.S.UpgradePrice=saveData.ManagementUpgradePrice ;
            Management.S.onGovernmentAlliesPlan=saveData.onGovernmentAlliesPlan;
            Management.S.onScholarshipInvest=saveData.onScholarshipInvest;
            Management.S.onSubcontractorContract=saveData.onSubcontractorContract ;
            Management.S.onBribeNationalAssemblyMemberb=saveData.onBribeNationalAssemblyMemberb;
            Management.S.onReliefActivities=saveData.onReliefActivities;
            Management.S.onEstablishSubsidiaryCompany=saveData.onEstablishSubsidiaryCompany;
            Management.S.onWithdrawalShares=saveData.onWithdrawalShares ;
            Management.S.onEmployeeWelfare=saveData.onEmployeeWelfare;
            Management.S.onCompanyExpand=saveData.onCompanyExpand ;
            Management.S.onAnarchyCompany=saveData.onAnarchyCompany ;
            Management.S.SetManagement();

            Shop.S.fame=saveData.fame;
            Shop.S.newCustomerTime=saveData.newCustomerTime ;
            Shop.S.pastMonthCustomer=saveData.pastMonthCustomer ;
            Shop.S.shopStaffNum=saveData.shopStaffNum ;

            Scenario.S.scenarioCurNum=saveData.scenarioCurNum ;
            Scenario.S.scenarioMaxNum=saveData.scenarioMaxNum ;
            Scenario.S.scenario2_coal=saveData.scenario2_coal ;
            Scenario.S.scenario2_scrab=saveData.scenario2_scrab ;
            Scenario.S.scenario2_compost=saveData.scenario2_compost ;
            Scenario.S.scenario4_createNum=saveData.scenario4_createNum ;
            Scenario.S.scenario6_sellNum=saveData.scenario6_sellNum ;
            Scenario.S.N_scenario2_CreateNum=saveData.N_scenario2_CreateNum ;
            Scenario.S.N_scenario3_SellNum=saveData.N_scenario3_SellNum ;
            Scenario.S.N_scenario6_CreateNum=saveData.N_scenario6_CreateNum ;
            Scenario.S.N_scenario7_SellNum=saveData.N_scenario7_SellNum ;
            Scenario.S.E_scenario18_SellNum=saveData.E_scenario18_SellNum;
            Scenario.S.E_scenario8_createNum=saveData.E_scenario8_createNum ;
            Scenario.S.H_scenario1_SellNum = saveData.H_scenario1_SellNum;
            Scenario.S.H_scenario3_month=saveData.H_scenario3_month ;
            Scenario.S.H_scenario9_Sellnum=saveData.H_scenario9_Sellnum ;
            Scenario.S.H_scenario12_month=saveData.H_scenario12_month ;
            Scenario.S.H_scenario15_month=saveData.H_scenario15_month ;
            Scenario.S.H_scenario17_FireNum=saveData.H_scenario17_FireNum;
            Scenario.S.H_scenario18_month=saveData.H_scenario18_month;

            Archive.S.monthProfits=saveData.monthProfits ;
            Archive.S.monthSpendMoney=saveData.monthSpendMoney ;
            Archive.S.monthGetMoney=saveData.monthGetMoney ;
            Archive.S.haveMoney=saveData.haveMoney ;
            Archive.S.earnMoney=saveData.earnMoney;
            Archive.S.MaxCurrentMoney=saveData.MaxCurrentMoney ;
            Archive.S.MinCurrentMoney=saveData.MinCurrentMoney ;
            Archive.S.MaxGrowMoney=saveData.MaxGrowMoney ;
            Archive.S.MinGrowMoney=saveData.MinGrowMoney;
            Archive.S.material=saveData.material ;
            Archive.S.materialTier1 = saveData.materialTier1;
            Archive.S.materialTier2 = saveData.materialTier2;
            Archive.S.materialTier3 = saveData.materialTier3;
            Archive.S.materialTier4 = saveData.materialTier4;
            Archive.S.materialTier5=saveData.materialTier5;
            Archive.S.materialTier6=saveData.materialTier6;

            Archive.S.Slime=saveData.Slime ;
            Archive.S.graySlime=saveData.graySlime ;
            Archive.S.Slime1=saveData.Slime1 ;
            Archive.S.Slime2=saveData.Slime2;
            Archive.S.Slime3=saveData.Slime3;
            Archive.S.Slime4=saveData.Slime4 ;
            Archive.S.Slime5=saveData.Slime5 ;
            Archive.S.Slime6=saveData.Slime6 ;
            Archive.S.TwinSlime=saveData.TwinSlime ;

            Archive.S.Value=saveData.Value;
            Archive.S.maxCompanyValue=saveData.maxCompanyValue ;

            Archive.S.Fame=saveData.Fame ;
            Archive.S.Product=saveData.Product ;
            Archive.S.Drugs=saveData.Drugs ;
            Archive.S.Ice=saveData.Ice ;
            Archive.S.Glass=saveData.Glass ;
            Archive.S.Fuel=saveData.Fuel ;
            Archive.S.SetText();
            Archive.S.DrawFameGraph();
            Archive.S.CurrentMoneyGraph();
            Archive.S.GrowMoneyGraph();
            Archive.S.DrawValueGraph();


            //인벤로드
            inven.ClearSlot();
            for (int i = 0; i < saveData.SlimeNum.Count; i++)
            {
                AddItem.S.SearchItem(saveData.SlimeName[i],saveData.SlimeNum[i]);
            }
            for (int i = 0; i < saveData.TrashNum.Count; i++)
            {
                AddItem.S.SearchItem(saveData.TrashName[i],saveData.TrashNum[i]);
            }


            ProductManager.S.SetProductNum(saveData.drugs, saveData.ice, saveData.glass, saveData.fuel);
            ProductManager.S.ChangePriceNum = saveData.ChangePriceNum;
            ProductManager.S.ChangeAllPrice(0);

            MoneyManager.S.Setmoney(saveData.money);
            //농장 로드
            for (int i = 0; i < DayManager.S.SlimeFarams.Length; i++)
            {
                if (DayManager.S.SlimeFarams[i].gameObject.activeInHierarchy)
                {
                    DayManager.S.SlimeFarams[i].SlimeFarmLoad(saveData.trashName[i], saveData.remainItemNum[i], saveData.resultSlime[i], saveData.remainTime[i]);
                }

            }
            //공장 로드
            for (int i = 0; i < DayManager.S.createLines.Length; i++)
            {
                DayManager.S.createLines[i].LoadCreateLine(saveData.createItemStackNum[i], saveData.moveItemStackTime[i], saveData.createproductType[i],
                                                            saveData.packageItemStackNum[i], saveData.packageTime[i], saveData.packageProductType[i]);
            }
            //직원 로드
            for (int i = 0; i < DayManager.S.allStaff.Length; i++)
            {
                DayManager.S.allStaff[i].LoadStaff(saveData.StaffOn[i], saveData.StaffName[i], saveData.loyalty[i], saveData.hireYear[i], saveData.hireTime[i], saveData.salary[i],saveData.companyValue[i]);
            }
            //가판대 로드
            for (int i = 0; i < DayManager.S.sellLines.Length; i++)
            {
                DayManager.S.sellLines[i].LoadSellLine(saveData.consumer[i], saveData.sellTime[i], saveData.sellItemKind[i]);
            }
        }
        
    }
    public SaveData LoadDataInTitle(int _num)
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + _num.ToString() + SAVE_FILENAME))
        {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + _num.ToString() + SAVE_FILENAME);
            SaveData saveData = JsonUtility.FromJson<SaveData>(loadJson);
            return saveData;
        }
        else
        {
            return null;
        }
    }

    public void SaveTitleSlimeBook()
    {
        slimeBook = LoadSlimeBookData();
        Debug.Log(SlimeBook.S.material.R.Length);
        for (int i = 0; i < slimeBook.G_S.Length; i++)
        {
            if (slimeBook.G_S[i]==false)
            {
                slimeBook.G_S[i] = SlimeBook.S.slime.G[i];
            } 
        }
        for (int i = 0; i < slimeBook.B_S.Length; i++)
        {
            if (slimeBook.B_S[i] == false)
            {
                slimeBook.B_S[i] = SlimeBook.S.slime.B[i];
            }
        }
        for (int i = 0; i < slimeBook.Y_S.Length; i++)
        {
            if (slimeBook.Y_S[i] == false)
            {
                slimeBook.Y_S[i] = SlimeBook.S.slime.Y[i];
            }
        }
        for (int i = 0; i < slimeBook.R_S.Length; i++)
        {
            if (slimeBook.R_S[i] == false)
            {
                slimeBook.R_S[i] = SlimeBook.S.slime.R[i];
            }
        }
        for (int i = 0; i < slimeBook.N_S.Length; i++)
        {
            if (slimeBook.N_S[i] == false)
            {
                slimeBook.N_S[i] = SlimeBook.S.slime.N[i];
            }
        }

        for (int i = 0; i < slimeBook.G_M.Length; i++)
        {
            if (slimeBook.G_M[i] == false)
            {
                slimeBook.G_M[i] = SlimeBook.S.material.G[i];
            }
        }
        for (int i = 0; i < slimeBook.B_M.Length; i++)
        {
            if (slimeBook.B_M[i] == false)
            {
                slimeBook.B_M[i] = SlimeBook.S.material.B[i];
            }
        }
        for (int i = 0; i < slimeBook.Y_M.Length; i++)
        {
            if (slimeBook.Y_M[i] == false)
            {
                slimeBook.Y_M[i] = SlimeBook.S.material.Y[i];
            }
        }
        for (int i = 0; i < slimeBook.R_M.Length; i++)
        {
            if (slimeBook.R_M[i] == false)
            {
                slimeBook.R_M[i] = SlimeBook.S.material.R[i];
            }
        }
        for (int i = 0; i < slimeBook.N_M.Length; i++)
        {
            if (slimeBook.N_M[i] == false)
            {
                slimeBook.N_M[i] = SlimeBook.S.material.N[i];
            }
        }





        string json = JsonUtility.ToJson(slimeBook, true);

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVEBOOK_FILENAME, json);
        Debug.Log(SAVE_DATA_DIRECTORY + SAVEBOOK_FILENAME);
    }

    public SlimeBookData LoadSlimeBookData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVEBOOK_FILENAME))
        {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVEBOOK_FILENAME);
            SlimeBookData _slimebookData=JsonUtility.FromJson<SlimeBookData>(loadJson);
            return _slimebookData;
        }
        else
        {

            string json = JsonUtility.ToJson(slimeBook, true);

            File.WriteAllText(SAVE_DATA_DIRECTORY + SAVEBOOK_FILENAME, json);
            LoadSlimeBookData();

            return slimeBook;
        }
    }
    public void LoadTime()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            saveData.realYear = System.DateTime.Now.Year;
            saveData.realMonth = System.DateTime.Now.Month;
            saveData.realDay = System.DateTime.Now.Day;
            saveData.realMinute = System.DateTime.Now.Minute;
            saveData.realSecond = System.DateTime.Now.Second;
        }

    }
    public void DeleteData(int _num)
    {
        File.Delete(SAVE_DATA_DIRECTORY + _num.ToString() +  SAVE_FILENAME);
    }
}
