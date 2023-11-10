using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Staff : MonoBehaviour {

    public enum StaffKind
    {
        Factory,
        Shop
    }

    public GameObject StaffHireUI;
    public GameObject StaffHireUIBase;
    public GameObject StaffManagementUI;
    public GameObject StaffManagementUIBase;
    public GameObject under40Effect;
    public int companyValue;

    [SerializeField]
    private Sprite[] factoryStaffIooks;//공장직원생김새들
    [SerializeField]
    private Sprite[] shopStaffIooks;//상점직원생김새들
    [SerializeField]
    private string[] staffNames;//이름들
    [SerializeField]
    public StaffKind staffKind;
    public Animator anim;


    [SerializeField]
    private string staffName;
    [SerializeField]
    private int loyalty;//충성도
    [SerializeField]
    private int salary;//월급
    [SerializeField]
    private bool staffOn;//직원 고용여부

    public int hireYear;
    public float hireTime;

    // Use this for initialization
    void Start() {
        staffOn = false;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (staffOn)
        {
            hireTime += 1.0f * Time.deltaTime;
        }
        if (hireTime >= DayManager.S.changeDay * DayManager.S.changeMonth * DayManager.S.changeYear)
        {
            IncreaseSalary();
            IncreaseCompanyValue();
            hireTime = 0;
        }
        if ((StaffHireUI.activeInHierarchy || StaffManagementUI.activeInHierarchy) && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
        if (loyalty < 40 && staffOn)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 1);

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void NewStaff()
    {
        MoneyManager.S.SpendMoney(500);
        staffOn = true;
        staffName = "직원";
        if (staffKind == StaffKind.Factory)
        {
            GetComponent<SpriteRenderer>().sprite = factoryStaffIooks[1];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = shopStaffIooks[1];
        }
        gameObject.GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().sprite.bounds.size;
        loyalty = 100;
        salary = 500;
        companyValue = 20+4*DayManager.S.year;
        CompanyValue.S.SetStaffValue();
        if (this.staffKind == StaffKind.Shop)
        {
            Shop.S.shopStaffNum += 1;
        }
        anim.SetBool("StaffOn", true);
    }
    public void FireStaff()
    {
        staffOn = false;
        staffName = null;
        DayManager.S.StaffFireStack += 1;
        DayManager.S.yearStaffFireStack += 1;
        salary = 0;
        loyalty = 0;
        hireYear = 0;
        hireTime = 0;
        companyValue = 0;
        CompanyValue.S.SetStaffValue();
        GetComponent<SpriteRenderer>().sprite = factoryStaffIooks[0];
        gameObject.GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().sprite.bounds.size;
        GeneralMeeting.S.LaborUnionDIVariation(10);
        if (this.staffKind == StaffKind.Shop)
        {
            Shop.S.shopStaffNum -= 1;
            if (Shop.S.shopStaffNum == 0)
            {
                Shop.S.AllShopStaffFire();
            }

        }
        anim.SetBool("StaffOn", false);

        if (Scenario.S.scenarioMaxNum==17)
        {
            Scenario.S.H_scenario17_FireNum += 1;
        }

    }

    public bool GetStaffOn()
    {
        return staffOn;
    }
    public string GetStaffName()
    {
        return staffName;
    }
    public int GetStaffSalary()
    {
        return salary;
    }
    public int GetStaffLoyalty()
    {
        return loyalty;
    }

    void OnMouseUpAsButton()
    {
        if (!LocationManager.openUI&&!EventSystem.current.IsPointerOverGameObject())
        {
            if (staffOn == false)
            {
                StaffHireUI.SetActive(true);
                StaffHireUIBase.GetComponent<StaffHire>().UIOn(this);
                LocationManager.openUI = true;
            }
            else
            {
                StaffManagementUI.SetActive(true);
                StaffManagementUIBase.GetComponent<StaffManagement>().UIOn(this);
                LocationManager.openUI = true;
            }
        }


    }

    public void SellStaffAniOff()
    {
        anim.SetBool("IsSell", false);
    }
    public void ChangeLoyalty(int _num)
    {
        loyalty += _num;
        if (loyalty > 100)
        {
            loyalty = 100;
        } else if (loyalty < 0)
        {
            loyalty = 0;
        }

    }
    public void IncreaseSalary()
    {
        hireYear += 1;
        salary += 100;
        ChangeLoyalty(10);

    }
    public void IncreaseCompanyValue()
    {
        companyValue += 4;
        CompanyValue.S.SetStaffValue();
    }

    public void IncreaseSalary(int _num)
    {
        salary += _num;
    }
    public void RecoverLoyalty(int _num)
    {
        if (loyalty<_num)
        {
            loyalty = _num;
        }
        
    }
    public void LoadStaff(bool _staffOn,string _staffName,int _loyalty,int _hireYear,float _hireTime,int _salary,int _companyValue)
    {
        staffOn = _staffOn;
        if(staffOn!=false)
        {
            staffName = _staffName;
            loyalty = _loyalty;
            hireYear = _hireYear;
            hireTime = _hireTime;
            salary = _salary;
            companyValue = _companyValue;

            if (staffKind == StaffKind.Factory)
            {
                GetComponent<SpriteRenderer>().sprite = factoryStaffIooks[1];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = shopStaffIooks[1];
            }
            gameObject.GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().sprite.bounds.size;
            anim.SetBool("StaffOn", true);
        }
        else
        {
            anim.SetBool("StaffOn", false);
        }
       
    }
}
