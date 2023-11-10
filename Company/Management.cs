using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Management : MonoBehaviour
{
    public static Management S;
    public int activeNum;

    public GameObject ManagementUI;
    public Staff[] allStaffs;
    
    public int ManagementTier;
    public GameObject B_ManagementTier;
    public Text T_UpgradePrice;
    public int UpgradePrice;
    
    public bool onGovernmentAlliesPlan;
    public GameObject B_GovernmentAlliesPlan;
    public Text T_GovernmentAlliesPlan;

    public bool onScholarshipInvest;
    public GameObject B_ScholarshipInvest;
    public Text T_ScholarshipInvest;
    
    public bool onSubcontractorContract;
    public GameObject B_SubcontractorContract;
    public Text T_SubcontractorContract;
    
    public bool onBribeNationalAssemblyMemberb;
    public GameObject B_BribeNationalAssemblyMember;
    public Text T_BribeNationalAssemblyMember;
    
    public bool onReliefActivities;
    public GameObject B_ReliefActivities;
    public Text T_ReliefActivities;
    
    public bool onEstablishSubsidiaryCompany;
    public GameObject B_EstablishSubsidiaryCompany;
    public Text T_EstablishSubsidiaryCompany;


    public bool onWithdrawalShares;
    public GameObject B_WithdrawalShares;
    public Text T_WithdrawalShares;
    
    public bool onEmployeeWelfare;
    public GameObject B_EmployeeWelfare;
    public Text T_EmployeeWelfare;

    public bool onCompanyExpand;
    public GameObject B_CompanyExpand;
    public Text T_CompanyExpand;




    public bool onAnarchyCompany;
    public GameObject B_AnarchyCompany;
    public Text T_AnarchyCompany;
    // Start is called before the first frame update

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
    void Start()
    {
        allStaffs = DayManager.S.AllStaff();
        switch (ManagementTier)
        {
            case 0:
                UpgradePrice = 25000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                break;
            case 1:
                UpgradePrice = 50000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                break;
            case 2:
                UpgradePrice = 100000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (ManagementUI.activeInHierarchy && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&LocationManager.openUI==false)
        {
            SoundManager.S.PlaySE("시나리오");
            ManagementUI.SetActive(true);
            LocationManager.openUI = true;
        }
    }
    public void SetManagement()
    {
        switch (ManagementTier)
        {
            case 0:
                UpgradePrice = 25000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                break;
            case 1:
                UpgradePrice = 50000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                B_BribeNationalAssemblyMember.SetActive(true);
                B_ReliefActivities.SetActive(true);
                B_EstablishSubsidiaryCompany.SetActive(true);
                break;
            case 2:
                UpgradePrice = 100000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                B_BribeNationalAssemblyMember.SetActive(true);
                B_ReliefActivities.SetActive(true);
                B_EstablishSubsidiaryCompany.SetActive(true);
                B_CompanyExpand.SetActive(true);
                B_EmployeeWelfare.SetActive(true);
                B_WithdrawalShares.SetActive(true);
                break;
            case 3:
                B_EstablishSubsidiaryCompany.SetActive(true);
                B_ReliefActivities.SetActive(true);
                B_WithdrawalShares.SetActive(true);
                B_CompanyExpand.SetActive(true);
                B_EmployeeWelfare.SetActive(true);
                B_WithdrawalShares.SetActive(true);
                B_AnarchyCompany.SetActive(true);
                B_ManagementTier.SetActive(false);
                T_UpgradePrice.text = "최대업그레이드";
                break;
            default:
                break;
        }

        if (!onGovernmentAlliesPlan)
        {
            T_GovernmentAlliesPlan.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_GovernmentAlliesPlan.text = "취소";
        }

        if (!onScholarshipInvest)
        {
            T_ScholarshipInvest.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_ScholarshipInvest.text = "취소";
        }
        if (!onSubcontractorContract)
        {
            T_SubcontractorContract.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_SubcontractorContract.text = "취소";
        }
        if (!onBribeNationalAssemblyMemberb)
        {
            T_BribeNationalAssemblyMember.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_BribeNationalAssemblyMember.text = "취소";
        }
        if (!onReliefActivities)
        {
            T_ReliefActivities.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_ReliefActivities.text = "취소";
        }
        if (!onEstablishSubsidiaryCompany)
        {
            T_EstablishSubsidiaryCompany.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_EstablishSubsidiaryCompany.text = "취소";
        }
        if (!onWithdrawalShares)
        {
            T_WithdrawalShares.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_WithdrawalShares.text = "취소";
        }
        if (!onEmployeeWelfare)
        {
            T_EmployeeWelfare.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_EmployeeWelfare.text = "취소";
        }
        if (!onCompanyExpand)
        {
            T_CompanyExpand.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_CompanyExpand.text = "취소";
        }
        if (!onAnarchyCompany)
        {
            T_AnarchyCompany.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_AnarchyCompany.text = "취소";
        }
 
    }
    public void UpgradeManagement()
    {
        if(UpgradePrice<=MoneyManager.S.CurrentMoney())
        {
            MoneyManager.S.SpendMoney(UpgradePrice);
            ManagementTier += 1;
            switch (ManagementTier)
            {
                case 0:
                    UpgradePrice = 25000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    break;
                case 1:
                    UpgradePrice = 50000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    B_BribeNationalAssemblyMember.SetActive(true);
                    B_ReliefActivities.SetActive(true);
                    B_EstablishSubsidiaryCompany.SetActive(true);
                    break;
                case 2:
                    UpgradePrice = 100000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    B_WithdrawalShares.SetActive(true);
                    B_EmployeeWelfare.SetActive(true);
                    B_CompanyExpand.SetActive(true);
                    break;
                case 3:
                    B_AnarchyCompany.SetActive(true);
                    B_ManagementTier.SetActive(false);
                    T_UpgradePrice.text = "최대업그레이드";
                    break;
                default:
                    break;
            }
        }
        

    }
    public void GovernmentAlliesPlan()
    {
        SoundManager.S.PlaySE("정책");
        if (!onGovernmentAlliesPlan)
        {
            onGovernmentAlliesPlan = true;
            T_GovernmentAlliesPlan.text = "취소";
            activeNum += 1;
        }
        else
        {
            onGovernmentAlliesPlan = false;
            T_GovernmentAlliesPlan.text = "실행";
            activeNum -= 1;
        }
    }

    public void ScholarshipInvest()
    {
        SoundManager.S.PlaySE("정책");
        if (!onScholarshipInvest)
        {
            onScholarshipInvest = true;
            T_ScholarshipInvest.text = "취소";
            activeNum += 1;
        }
        else
        {
            onScholarshipInvest = false;
            T_ScholarshipInvest.text = "실행";
            activeNum -= 1;
        }
    }

    public void SubcontractorContract()
    {
        SoundManager.S.PlaySE("정책");
        if (!onSubcontractorContract)
        {
            onSubcontractorContract = true;
            T_SubcontractorContract.text = "취소";
            activeNum += 1;
        }
        else
        {
            onSubcontractorContract = false;
            T_SubcontractorContract.text = "실행";
            activeNum -= 1;
        }
    }

    public void BribeNationalAssemblyMember()
    {
        SoundManager.S.PlaySE("정책");
        if (!onBribeNationalAssemblyMemberb)
        {
            onBribeNationalAssemblyMemberb = true;
            T_BribeNationalAssemblyMember.text = "취소";
            activeNum += 1;
        }
        else
        {
            onBribeNationalAssemblyMemberb = false;
            T_BribeNationalAssemblyMember.text = "실행";
            activeNum -= 1;
        }
    }

    public void ReliefActivities()
    {
        SoundManager.S.PlaySE("정책");
        if (!onReliefActivities)
        {
            onReliefActivities = true;
            T_ReliefActivities.text = "취소";
            activeNum += 1;

        }
        else
        {
            onReliefActivities = false;
            T_ReliefActivities.text = "실행";
            activeNum -= 1;
        }
    }

    public void EstablishSubsidiaryCompany()
    {
        SoundManager.S.PlaySE("정책");
        if (!onEstablishSubsidiaryCompany)
        {
            T_EstablishSubsidiaryCompany.text = "취소";
            onEstablishSubsidiaryCompany = true;
            activeNum += 1;

        }
        else
        {
            T_EstablishSubsidiaryCompany.text = "실행";
            onEstablishSubsidiaryCompany = false;
            activeNum -= 1;

        }
    }

    public void WithdrawalShares()
    {
        SoundManager.S.PlaySE("정책");
        if (!onWithdrawalShares)
        {
            T_WithdrawalShares.text = "취소";
            onWithdrawalShares = true;
            activeNum += 1;
        }
        else
        {
            T_WithdrawalShares.text = "실행";
            onWithdrawalShares = false;
            activeNum -= 1;
        }
    }

    public void EmployeeWelfare()
    {
        SoundManager.S.PlaySE("정책");
        if (!onEmployeeWelfare)
        {
            T_EmployeeWelfare.text = "취소";
            onEmployeeWelfare = true;
            activeNum += 1;

        }
        else
        {
            T_EmployeeWelfare.text = "실행";
            onEmployeeWelfare = false;
            activeNum -= 1;
        }
    }
    public void CompanyExpand()
    {
        SoundManager.S.PlaySE("정책");
        if (!onCompanyExpand)
        {
            T_CompanyExpand.text = "취소";
            onCompanyExpand = true;
            activeNum += 1;

        }
        else
        {
            T_CompanyExpand.text = "실행";
            onCompanyExpand = false;
            activeNum -= 1;
        }
    }
    public void AnarchyCompany()
    {
        SoundManager.S.PlaySE("정책");
        if (!onAnarchyCompany)
        {
            T_AnarchyCompany.text = "취소";
            onAnarchyCompany = true;
            activeNum += 1;
        }
        else
        {
            T_AnarchyCompany.text = "실행";
            onAnarchyCompany = false;
            activeNum -= 1;
        }
    }
    public void YearManagement()
    {
       
        
        
        
    }
    public void MonthManagement()
    {
        if(onGovernmentAlliesPlan)//경영1
        {
            MoneyManager.S.SpendMoney(350);
            ProductManager.S.ChangeAllPrice(1.5f);
            Shop.S.VariationFame(-25);
            GeneralMeeting.S.ConsumerGroupDIVariation(1);
            GeneralMeeting.S.AnimalProtectionGroupDIVariation(1);
        }
        if (onScholarshipInvest)//경영2
        {
            MoneyManager.S.SpendMoney(300);
            GeneralMeeting.S.FDADIVariation(-2);
        }
        if (onSubcontractorContract)//경영3
        {
            MoneyManager.S.SpendMoney(400);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(-2);
        }
        if (onBribeNationalAssemblyMemberb)//경영4
        {
            MoneyManager.S.SpendMoney(750);
            ProductManager.S.ChangeAllPrice(2.5f);
            Shop.S.VariationFame(-40);
            GeneralMeeting.S.GovernmentDIVariation(2);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(2);
            GeneralMeeting.S.FDADIVariation(2);
        }
        if(onReliefActivities)
        {
            MoneyManager.S.SpendMoney(600);
            Shop.S.VariationFame(-30);
            GeneralMeeting.S.GovernmentDIVariation(-3);
        }
        if (onEstablishSubsidiaryCompany)
        {
            MoneyManager.S.SpendMoney(1000);
            GeneralMeeting.S.ConsumerGroupDIVariation(-2);
            GeneralMeeting.S.LaborUnionDIVariation(-2);
        }
        if (onWithdrawalShares)
        {
            MoneyManager.S.SpendMoney(1500);
            ProductManager.S.ChangeAllPrice(4);
            GeneralMeeting.S.GovernmentDIVariation(3);
            GeneralMeeting.S.ConsumerGroupDIVariation(3);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(3);
            GeneralMeeting.S.LaborUnionDIVariation(3);
            GeneralMeeting.S.FDADIVariation(3);
        }
        if (onEmployeeWelfare)
        {
            MoneyManager.S.SpendMoney(2250);
            GeneralMeeting.S.GovernmentDIVariation(-5);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(-5);
            GeneralMeeting.S.FDADIVariation(-5);
            Shop.S.VariationFame(-75);
        }
        if (onCompanyExpand)
        {
            MoneyManager.S.SpendMoney(2000);
            GeneralMeeting.S.ConsumerGroupDIVariation(-5);
            GeneralMeeting.S.LaborUnionDIVariation(-5);
        }
        if (onAnarchyCompany)
        {
            MoneyManager.S.SpendMoney(4000);
            GeneralMeeting.S.GovernmentDIVariation(-5);
            GeneralMeeting.S.ConsumerGroupDIVariation(-5);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(-5);
            GeneralMeeting.S.LaborUnionDIVariation(-5);
            GeneralMeeting.S.FDADIVariation(-5);
            GeneralMeeting.S.AnimalProtectionGroupDIVariation(-5);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(-5);
                }
            }
        }
    }
    public int ReturnManagementNum()
    {
        int _num = 0;
        if (onAnarchyCompany)
        {
            _num += 1;
        }
        if (onBribeNationalAssemblyMemberb)
        {
            _num += 1;
        }
        if (onCompanyExpand)
        {
            _num += 1;
        }
        if (onEmployeeWelfare)
        {
            _num += 1;
        }
        if (onEstablishSubsidiaryCompany)
        {
            _num += 1;
        }
        if (onGovernmentAlliesPlan)
        {
            _num += 1;
        }
        if (onReliefActivities)
        {
            _num += 1;
        }
        if (onScholarshipInvest)
        {
            _num += 1;
        }
        if (onSubcontractorContract)
        {
            _num += 1;
        }
        if (onWithdrawalShares)
        {
            _num += 1;
        }
        return _num;
    }
}
