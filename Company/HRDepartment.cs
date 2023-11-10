using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class HRDepartment : MonoBehaviour
{

    public static HRDepartment S;
    [SerializeField]
    private Staff[] allStaffs;
    public GameObject HRDepartmentUI;
    public int activeNum;

    public int HRDepartmentTier;
    public GameObject B_HRDepartmentTier;
    public Text T_UpgradePrice;
    public int UpgradePrice;
    
    public bool onInterviewHire;
    public GameObject B_InterviewHire;
    public Text T_InterviewHire;

    public bool onCompanyWelfare;
    public GameObject B_CompanyWelfare;
    public Text T_CompanyWelfare;
    
    public bool onCompanyInsurance;
    public GameObject B_CompanyInsurance;
    public Text T_CompanyInsurance;

    public bool onPublicEmployment;
    public GameObject B_PublicEmployment;
    public Text T_PublicEmployment;

    public bool onPayBonus;
    public GameObject B_PayBonus;
    public Text T_PayBonus;
    
    public bool onRegularRetirement;
    public GameObject B_RegularRetirement;
    public Text T_RegularRetirement;
    
    public bool onHireDisabledPersons;
    public GameObject B_HireDisabledPerson;
    public Text T_HireDisabledPerson;
    
    public bool onListedCompany;
    public GameObject B_ListedCompany;
    public Text T_ListedCompany;
    
    public bool onPensionSystem;
    public GameObject B_PensionSystem;
    public Text T_PensionSystem;
    
    public bool onHugeCompany;
    public GameObject B_HugeCompany;
    public Text T_HugeCompany;
    public int HugeCompanyStack;
    // Start is called before the first frame update

    private void Awake()
    {
        if (S == null)
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
        switch (HRDepartmentTier)
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
    private void Update()
    {
        if (HRDepartmentUI.activeInHierarchy && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }
    // Update is called once per frame
    private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && LocationManager.openUI == false)
        {
            SoundManager.S.PlaySE("시나리오");

            HRDepartmentUI.SetActive(true);
            LocationManager.openUI = true;
        }
    }
    public void SetHRDepartment()
    {
        switch (HRDepartmentTier)
        {
            case 0:
                UpgradePrice = 25000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                break;
            case 1:
                UpgradePrice = 50000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                B_PublicEmployment.SetActive(true);
                B_PayBonus.SetActive(true);
                B_RegularRetirement.SetActive(true);
                break;
            case 2:
                UpgradePrice = 100000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                B_PublicEmployment.SetActive(true);
                B_PayBonus.SetActive(true);
                B_RegularRetirement.SetActive(true);
                B_ListedCompany.SetActive(true);
                B_HireDisabledPerson.SetActive(true);
                B_PensionSystem.SetActive(true);
                break;
            case 3:
                B_PublicEmployment.SetActive(true);
                B_PayBonus.SetActive(true);
                B_RegularRetirement.SetActive(true);
                B_ListedCompany.SetActive(true);
                B_HireDisabledPerson.SetActive(true);
                B_PensionSystem.SetActive(true);
                B_HugeCompany.SetActive(true);
                B_HRDepartmentTier.SetActive(false);
                T_UpgradePrice.text = "최대업그레이드";
                break;
            default:
                break;
        }

        if (!onInterviewHire)
        {
            T_InterviewHire.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_InterviewHire.text = "취소";
        }

        if (!onCompanyWelfare)
        {
            T_CompanyWelfare.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_CompanyWelfare.text = "취소";
        }
        if (!onCompanyInsurance)
        {
            T_CompanyInsurance.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_CompanyInsurance.text = "취소";
        }
        if (!onPublicEmployment)
        {
            T_PublicEmployment.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_PublicEmployment.text = "취소";
        }
        if (!onPayBonus)
        {
            T_PayBonus.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_PayBonus.text = "취소";
        }
        if (!onRegularRetirement)
        {
            T_RegularRetirement.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_RegularRetirement.text = "취소";
        }
        if (!onHireDisabledPersons)
        {
            T_HireDisabledPerson.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_HireDisabledPerson.text = "취소";
        }
        if (!onListedCompany)
        {
            T_ListedCompany.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_ListedCompany.text = "취소";
        }
        if (!onPensionSystem)
        {
            T_PensionSystem.text = "실행";

        }
        else
        {
            activeNum += 1;
            T_PensionSystem.text = "취소";
        }
        if (!onHugeCompany)
        {
            T_HugeCompany.text = "실행";
        }
        else
        {
            activeNum += 1;
            T_HugeCompany.text = "취소";
        }

    }
    public void UpgradeHRDepartment()
    {
        if(MoneyManager.S.CurrentMoney()>= UpgradePrice)
        {
            MoneyManager.S.SpendMoney(UpgradePrice);
            HRDepartmentTier += 1;
            switch (HRDepartmentTier)
            {
                case 0:
                    UpgradePrice = 25000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    break;
                case 1:
                    UpgradePrice = 50000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    B_PayBonus.SetActive(true);
                    B_RegularRetirement.SetActive(true);
                    B_PublicEmployment.SetActive(true);
                    break;
                case 2:
                    UpgradePrice = 100000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    B_HireDisabledPerson.SetActive(true);
                    B_ListedCompany.SetActive(true);
                    B_PensionSystem.SetActive(true);
                    break;
                case 3:
                    B_HugeCompany.SetActive(true);
                    B_HRDepartmentTier.SetActive(false);
                    T_UpgradePrice.text = "최대업그레이드";
                    break;
                default:
                    break;
            }
        }
        

    }
    public void InterviewHire()
    {
        SoundManager.S.PlaySE("정책");
        if (!onInterviewHire)
        {
            onInterviewHire = true;
            T_InterviewHire.text = "취소";
            activeNum += 1;

        }
        else
        {
            onInterviewHire = false;
            T_InterviewHire.text = "실행";
            activeNum -= 1;
        }
    }

    public void CompanyWelfare()
    {
        SoundManager.S.PlaySE("정책");
        if (!onCompanyWelfare)
        {
            onCompanyWelfare = true;
            T_CompanyWelfare.text = "취소";
            activeNum += 1;

        }
        else
        {
            onCompanyWelfare = false;
            T_CompanyWelfare.text = "실행";
            activeNum -= 1;
        }
    }

    public void CompanyInsurance()
    {
        SoundManager.S.PlaySE("정책");
        if (!onCompanyInsurance)
        {
            onCompanyInsurance = true;
            T_CompanyInsurance.text = "취소";
            activeNum += 1;
        }
        else
        {
            onCompanyInsurance = false;
            T_CompanyInsurance.text = "실행";
            activeNum -= 1;
        }
    }

    public void PublicEmployment()
    {
        SoundManager.S.PlaySE("정책");
        if (!onPublicEmployment)
        {
            onPublicEmployment = true;
            T_PublicEmployment.text = "취소";
            activeNum += 1;
        }
        else
        {
            onPublicEmployment = false;
            T_PublicEmployment.text = "실행";
            activeNum -= 1;
        }
    }

    public void PayBonus()
    {
        SoundManager.S.PlaySE("정책");
        if (!onPayBonus)
        {
            onPayBonus = true;
            T_PayBonus.text = "취소";
            activeNum += 1;

        }
        else
        {
            onPayBonus = false;
            T_PayBonus.text = "실행";
            activeNum -= 1;
        }
    }

    public void RegularRetirement()
    {
        SoundManager.S.PlaySE("정책");
        if (!onRegularRetirement)
        {
            T_RegularRetirement.text = "취소";
            onRegularRetirement = true;
            activeNum += 1;

        }
        else
        {
            T_RegularRetirement.text = "실행";
            onRegularRetirement = false;
            activeNum -= 1;
        }
    }

    public void HireDisabledPersons()
    {
        SoundManager.S.PlaySE("정책");
        if (!onHireDisabledPersons)
        {
            T_HireDisabledPerson.text = "취소";
            onHireDisabledPersons = true;
            activeNum += 1;
        }
        else
        {
            T_HireDisabledPerson.text = "실행";
            onHireDisabledPersons = false;
            activeNum -= 1;
        }
    }

    public void ListedCompany()
    {
        SoundManager.S.PlaySE("정책");
        if (!onListedCompany)
        {
            T_ListedCompany.text = "취소";
            onListedCompany = true;
            activeNum += 1;

        }
        else
        {
            T_ListedCompany.text = "실행";
            onListedCompany = false;
            activeNum -= 1;
        }
    }
    public void PensionSystem()
    {
        SoundManager.S.PlaySE("정책");
        if (!onPensionSystem)
        {
            T_PensionSystem.text = "취소";
            onPensionSystem = true;
            activeNum += 1;

        }
        else
        {
            T_PensionSystem.text = "실행";
            onPensionSystem = false;
            activeNum -= 1;
        }
    }
    public void HugeCompany()
    {
        SoundManager.S.PlaySE("정책");
        if (!onHugeCompany)
        {
            T_HugeCompany.text = "취소";
            onHugeCompany = true;
            activeNum += 1;
        }
        else
        {
            T_HugeCompany.text = "실행";
            onHugeCompany = false;
            activeNum -= 1;
        }
    }
    public void YearHRDepartment()
    {
       
    }
    public void MonthHRDepartment()
    {
        if (onInterviewHire)//1
        {
            MoneyManager.S.SpendMoney(350);
            GeneralMeeting.S.LaborUnionDIVariation(-1);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(2);
                }
            }
        }
        if (onCompanyWelfare)//2
        {
            MoneyManager.S.SpendMoney(200);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if(allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(2);
                }
            }
        }
        if (onCompanyInsurance)//3
        {
            MoneyManager.S.SpendMoney(750);
            ProductManager.S.ChangeAllPrice(0.5f);
            Shop.S.VariationFame(25);
        }
        if (onPublicEmployment)//4
        {
            MoneyManager.S.SpendMoney(700);
            GeneralMeeting.S.GovernmentDIVariation(-3);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(-3);
            GeneralMeeting.S.FDADIVariation(-3);
            GeneralMeeting.S.LaborUnionDIVariation(2);
            GeneralMeeting.S.ConsumerGroupDIVariation(2);
            Shop.S.VariationFame(40);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(-1);
                }
            }
        }
        if (onPayBonus)//5
        {
            MoneyManager.S.SpendMoney(600);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(3);
                }
            }
        }
        if (onRegularRetirement)//6
        {
            MoneyManager.S.SpendMoney(750);
            GeneralMeeting.S.GovernmentDIVariation(-3);
            GeneralMeeting.S.AnimalProtectionGroupDIVariation(-3);
            ProductManager.S.ChangeAllPrice(-0.75f);
        }

        if (onHireDisabledPersons)//7
        {
            MoneyManager.S.SpendMoney(1750);
            GeneralMeeting.S.LaborUnionDIVariation(-4);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(1);
                }
            }
            Shop.S.VariationFame(-35);
        }
        if (onListedCompany)//8
        {
            MoneyManager.S.SpendMoney(1800);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(4);
                }
            }
        }
        if (onPensionSystem)//9
        {
            MoneyManager.S.SpendMoney(3000);
            GeneralMeeting.S.GovernmentDIVariation(4);
            GeneralMeeting.S.ConsumerGroupDIVariation(4);
            GeneralMeeting.S.LaborUnionDIVariation(4);
            GeneralMeeting.S.FDADIVariation(4);
            GeneralMeeting.S.AnimalProtectionGroupDIVariation(4);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(4);
            ProductManager.S.ChangeAllPrice(4);

        }

        if (onHugeCompany)//10
        {
            MoneyManager.S.SpendMoney(4000);
            HugeCompanyStack += 1;
            if(HugeCompanyStack>=4)
            {
                GeneralMeeting.S.GovernmentDIVariation(-50);
                GeneralMeeting.S.ConsumerGroupDIVariation(-50);
                GeneralMeeting.S.LaborUnionDIVariation(-50);
                GeneralMeeting.S.FDADIVariation(-50);
                GeneralMeeting.S.AnimalProtectionGroupDIVariation(-50);
                GeneralMeeting.S.EnvironmentalGroupDIVariation(-50);
                HugeCompanyStack = 0;
            }
        }
    }
    public int ReturnHRDepartmentNum()
    {
        int _num = 0;
        if (onCompanyInsurance)
        {
            _num += 1;
        }
        if (onCompanyWelfare)
        {
            _num += 1;
        }
        if (onHireDisabledPersons)
        {
            _num += 1;
        }
        if (onHugeCompany)
        {
            _num += 1;
        }
        if (onInterviewHire)
        {
            _num += 1;
        }
        if (onListedCompany)
        {
            _num += 1;
        }
        if (onPayBonus)
        {
            _num += 1;
        }
        if (onPensionSystem)
        {
            _num += 1;
        }
        if (onPublicEmployment)
        {
            _num += 1;
        }
        if (onRegularRetirement)
        {
            _num += 1;
        }
        return _num;
    }
}
