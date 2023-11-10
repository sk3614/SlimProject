using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Marketing : MonoBehaviour
{
    public static Marketing S;
    public int activeNum;
    private Staff[] allStaffs;
    public GameObject MarketingUI;

    public int markettingTier;
    public int UpgradePrice;
    public Text T_UpgradePrice;
    public GameObject B_markettingTier;
    
    public bool onGreenfoodBusiness;
    public GameObject B_GreenfoodBusiness;
    public Text T_GreenfoodBusiness;

    public bool onFreeGift;
    public GameObject B_FreeGift;
    public Text T_FreeGift;

    public bool onMascot;
    public GameObject B_Mascot;
    public Text T_Mascot;
    
    public bool onEco_FriendlyMaterials;
    public GameObject B_Eco_FriendlyMaterials;
    public Text T_Eco_FriendlyMaterials;
    
    public bool onCouponMarketing;
    public GameObject B_CouponMarketing;
    public Text T_CouponMarketing;
    
    public bool onMascotAD;
    public GameObject B_MascotAD;
    public Text T_MascotAD;
    
    public bool onUseLocalMaterialAD;
    public GameObject B_UseLocalMaterialAD;
    public Text T_UseLocalMaterialAD;
    
    public bool onDiscountDayEvent;
    public GameObject B_DiscountDayEvent;
    public Text T_DiscountDayEventn;
    
    public bool onCollaboration;
    public GameObject B_Collaboration;
    public Text T_Collaboration;

    public bool onGlobalCompany;
    public GameObject B_GlobalCompany;
    public Text T_GlobalCompany;
    public int globalCompanyStack;

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
    private void Update()
    {
        if (MarketingUI.activeInHierarchy&& LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && LocationManager.openUI == false)
        {
            SoundManager.S.PlaySE("시나리오");
            MarketingUI.SetActive(true);
            LocationManager.openUI = true;
        }
    }
    void Start()
    {
        allStaffs = DayManager.S.AllStaff();
        switch (markettingTier)
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

    public void UpgradeMarketingTier()
    {
        if(UpgradePrice<=MoneyManager.S.CurrentMoney())
        {
            markettingTier += 1;
            MoneyManager.S.SpendMoney(UpgradePrice);
            switch (markettingTier)
            {
                case 0:
                    UpgradePrice = 25000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    break;
                case 1:
                    UpgradePrice = 50000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    B_Eco_FriendlyMaterials.SetActive(true);
                    B_CouponMarketing.SetActive(true);
                    B_MascotAD.SetActive(true);
                    break;
                case 2:
                    UpgradePrice = 100000;
                    T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                    B_UseLocalMaterialAD.SetActive(true);
                    B_DiscountDayEvent.SetActive(true);
                    B_Collaboration.SetActive(true);
                    break;
                case 3:
                    B_GlobalCompany.SetActive(true);
                    B_markettingTier.SetActive(false);
                    T_UpgradePrice.text = "최대업그레이드";
                    break;
                case 4:
                default:
                    break;
            }
        }
        
    }
    public void GreenfoodBusiness()
    {
        SoundManager.S.PlaySE("정책");
        if (!onGreenfoodBusiness)
        {
            onGreenfoodBusiness = true;
            T_GreenfoodBusiness.text = "취소";
            activeNum += 1;
        }
        else
        {
            onGreenfoodBusiness = false;
            T_GreenfoodBusiness.text = "실행";
            activeNum -= 1;
        }
    }

    public void FreeGift()
    {
        SoundManager.S.PlaySE("정책");
        if (!onFreeGift)
        {
            onFreeGift = true;
            T_FreeGift.text = "취소";
            activeNum += 1;
        }
        else
        {
            onFreeGift = false;
            T_FreeGift.text = "실행";
            activeNum -= 1;
        }
    }
    public void Mascot()
    {
        SoundManager.S.PlaySE("정책");
        if (!onMascot)
        {
            onMascot = true;
            T_Mascot.text = "취소";
            activeNum += 1;
        }
        else
        {
            onMascot = false;
            T_Mascot.text = "실행";
            activeNum -= 1;
        }
    }
    public void Eco_FriendlyMaterials()
    {
        SoundManager.S.PlaySE("정책");
        if (!onEco_FriendlyMaterials)
        {
            onEco_FriendlyMaterials = true;
            T_Eco_FriendlyMaterials.text = "취소";
            activeNum += 1;
        }
        else
        {
            onEco_FriendlyMaterials = false;
            T_Eco_FriendlyMaterials.text = "실행";
            activeNum -= 1;

        }
    }

    public void CouponMarketing()
    {
        SoundManager.S.PlaySE("정책");
        if (!onCouponMarketing)
        {
            onCouponMarketing = true;
            T_CouponMarketing.text = "취소";
            activeNum += 1;
        }
        else
        {
            onCouponMarketing = false;
            T_CouponMarketing.text = "실행";
            activeNum -= 1;
        }
    }
    public void MascotAD()
    {
        SoundManager.S.PlaySE("정책");
        if (!onMascotAD)
        {
            onMascotAD = true;
            T_MascotAD.text = "취소";
            activeNum += 1;
        }
        else
        {
            onMascotAD = false;
            T_MascotAD.text = "실행";
            activeNum -= 1;
        }
    }
    public void UseLocalMaterialAD()
    {
        SoundManager.S.PlaySE("정책");
        if (!onUseLocalMaterialAD)
        {
            onUseLocalMaterialAD = true;
            T_UseLocalMaterialAD.text = "취소";
            activeNum += 1;
        }
        else
        {
            onUseLocalMaterialAD = false;
            T_UseLocalMaterialAD.text = "실행";
            activeNum -= 1;
        }
    }

    public void DiscountDayEvent()
    {
        SoundManager.S.PlaySE("정책");
        if (!onDiscountDayEvent)
        {
            onDiscountDayEvent = true;
            T_DiscountDayEventn.text = "취소";
            activeNum += 1;
        }
        else
        {
            onDiscountDayEvent = false;
            T_DiscountDayEventn.text = "실행";
            activeNum -= 1;
        }
    }

    public void Collaboration()
    {
        SoundManager.S.PlaySE("정책");
        if (!onCollaboration)
        {
            onCollaboration = true;
            T_Collaboration.text = "취소";
            activeNum += 1;
        }
        else
        {
            onCollaboration = false;
            T_Collaboration.text = "실행";
            activeNum -= 1;
        }
    }

    public void GlobalCompany()
    {
        SoundManager.S.PlaySE("정책");
        if (!onGlobalCompany)
        {
            onGlobalCompany = true;
            T_GlobalCompany.text = "취소";
            activeNum += 1;
        }
        else
        {
            onGlobalCompany = false;
            T_GlobalCompany.text = "실행";
            activeNum -= 1;
        }
    }
    public void SetMarketing()
    {
        switch (markettingTier)
        {
            case 0:
                UpgradePrice = 25000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                break;
            case 1:
                UpgradePrice = 50000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                B_Eco_FriendlyMaterials.SetActive(true);
                B_CouponMarketing.SetActive(true);
                B_MascotAD.SetActive(true);
                break;
            case 2:
                UpgradePrice = 100000;
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                B_Eco_FriendlyMaterials.SetActive(true);
                B_CouponMarketing.SetActive(true);
                B_MascotAD.SetActive(true);
                B_UseLocalMaterialAD.SetActive(true);
                B_DiscountDayEvent.SetActive(true);
                B_Collaboration.SetActive(true);
                break;
            case 3:
                T_UpgradePrice.text = "₩:" + UpgradePrice.ToString();
                B_Eco_FriendlyMaterials.SetActive(true);
                B_CouponMarketing.SetActive(true);
                B_MascotAD.SetActive(true);
                B_UseLocalMaterialAD.SetActive(true);
                B_DiscountDayEvent.SetActive(true);
                B_Collaboration.SetActive(true);
                B_GlobalCompany.SetActive(true);
                B_markettingTier.SetActive(false);
                T_UpgradePrice.text = "최대업그레이드";
                break;
            default:
                break;
        }
        if (!onGreenfoodBusiness)
        {
            T_GreenfoodBusiness.text = "실행";
        }
        else
        {
            T_GreenfoodBusiness.text = "취소";
            activeNum += 1;
        }
        if (!onFreeGift)
        {
            T_FreeGift.text = "실행";
        }
        else
        {
            T_FreeGift.text = "취소";
            activeNum += 1;
        }
        if (!onMascot)
        {
            T_Mascot.text = "실행";
        }
        else
        {
            T_Mascot.text = "취소";
            activeNum += 1;
        }
        if (!onEco_FriendlyMaterials)
        {
            T_Eco_FriendlyMaterials.text = "실행";
        }
        else
        {
            T_Eco_FriendlyMaterials.text = "취소";
            activeNum += 1;

        }
        if (!onEco_FriendlyMaterials)
        {
            T_Eco_FriendlyMaterials.text = "실행";
        }
        else
        {
            T_Eco_FriendlyMaterials.text = "취소";
            activeNum += 1;

        }
        if (!onEco_FriendlyMaterials)
        {
            T_Eco_FriendlyMaterials.text = "실행";
        }
        else
        {
            T_Eco_FriendlyMaterials.text = "취소";
            activeNum += 1;

        }
        if (!onCouponMarketing)
        {
            T_CouponMarketing.text = "실행";
        }
        else
        {
            T_CouponMarketing.text = "취소";
            activeNum += 1;
        }
        if (!onMascotAD)
        {
            T_MascotAD.text = "실행";
        }
        else
        {
            T_MascotAD.text = "취소";
            activeNum += 1;
        }
        if (!onUseLocalMaterialAD)
        {
            T_UseLocalMaterialAD.text = "실행";
        }
        else
        {
            T_UseLocalMaterialAD.text = "취소";
            activeNum += 1;
        }
        if (!onDiscountDayEvent)
        {
            T_DiscountDayEventn.text = "실행";
        }
        else
        {
            T_DiscountDayEventn.text = "취소";
            activeNum += 1;
        }
        if (!onCollaboration)
        {
            T_Collaboration.text = "실행";
        }
        else
        {
            T_Collaboration.text = "취소";
            activeNum += 1;
        }
        if (!onGlobalCompany)
        {
            T_GlobalCompany.text = "실행";
        }
        else
        {
            T_GlobalCompany.text = "취소";
            activeNum += 1;
        }
    }

    public void MonthMarketting()
    {
        if(onGreenfoodBusiness)//마케팅1
        {
            Shop.S.VariationFame(25);
            GeneralMeeting.S.FDADIVariation(-1);
            GeneralMeeting.S.GovernmentDIVariation(-1);
            GeneralMeeting.S.EnvironmentalGroupDIVariation(-1);
            GeneralMeeting.S.AnimalProtectionGroupDIVariation(-1);
            GeneralMeeting.S.ConsumerGroupDIVariation(-1);
            GeneralMeeting.S.LaborUnionDIVariation(-1);
            MoneyManager.S.SpendMoney(250);
        }
        if(onFreeGift)//마케팅2
        {
            MoneyManager.S.SpendMoney(600);
            Shop.S.VariationFame(50);
        }
        if(onMascot)//마케팅3
        {
            Shop.S.VariationFame(50);
            GeneralMeeting.S.LaborUnionDIVariation(1);
            GeneralMeeting.S.ConsumerGroupDIVariation(-2);

            MoneyManager.S.SpendMoney(300);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(-2);
                }
            }
        }
        if(onEco_FriendlyMaterials)//마케팅4
        {
            MoneyManager.S.SpendMoney(600);
            Shop.S.VariationFame(75);
            GeneralMeeting.S.ConsumerGroupDIVariation(2);
        }
        
        if (onCouponMarketing)//마케팅5
        {
            MoneyManager.S.SpendMoney(1500);
            Shop.S.VariationFame(100);
        }
        if (onMascotAD)//마케팅6
        {
            MoneyManager.S.SpendMoney(725);
            Shop.S.VariationFame(100);
            GeneralMeeting.S.LaborUnionDIVariation(2);
            for (int i = 0; i < allStaffs.Length; i++)
            {
                if (allStaffs[i].GetComponent<Staff>().GetStaffOn())
                {
                    allStaffs[i].GetComponent<Staff>().ChangeLoyalty(-3);
                }
            }
        }
        if (onUseLocalMaterialAD)//마케팅7
        {
            MoneyManager.S.SpendMoney(1400);
            Shop.S.VariationFame(150);
            GeneralMeeting.S.ConsumerGroupDIVariation(3);
        }
        if(onDiscountDayEvent)//마케팅8
        {
            Shop.S.VariationFame(175);
            MoneyManager.S.SpendMoney(2400);
        }
        if(onCollaboration)//마케팅9
        {
            
            Shop.S.VariationFame(225);
            MoneyManager.S.SpendMoney(1900);
            GeneralMeeting.S.LaborUnionDIVariation(2);
            GeneralMeeting.S.ConsumerGroupDIVariation(2);
        }
        if(onGlobalCompany)//마케팅10
        {
            MoneyManager.S.SpendMoney(2500);
            globalCompanyStack += 1;
            if(globalCompanyStack>=4)
            {
                Shop.S.VariationFame(1000);
                globalCompanyStack = 0;
            }
        }
    }
    

    public int ReturnMarketingNum()
    {
        int _num=0;
        if (onCollaboration)
        {
            _num += 1;
        }
        if (onCouponMarketing)
        {
            _num += 1;
        }
        if (onDiscountDayEvent)
        {
            _num += 1;
        }
        if (onEco_FriendlyMaterials)
        {
            _num += 1;
        }
        if (onFreeGift)
        {
            _num += 1;
        }
        if (onGlobalCompany)
        {
            _num += 1;
        }
        if (onGreenfoodBusiness)
        {
            _num += 1;
        }
        if (onMascot)
        {
            _num += 1;
        }
        if (onMascotAD)
        {
            _num += 1;
        }
        if (onUseLocalMaterialAD)
        {
            _num += 1;
        }
        return _num;
    }
}
