using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GeneralMeeting : MonoBehaviour
{
    public static GeneralMeeting S;

    public GameObject GeneralMeetingUI;
    public GameObject EventUI;
    public Image EventImage;
    //DI=Discomfort Index=불쾌지수
    [SerializeField]
    public float governmentDI;
    public Image I_governmentDI;

    [SerializeField]
    public float consumerGroupDI;
    public Image I_consumerGroupDI;

    [SerializeField]
    public float environmentalGroupDI;
    public Image I_environmentalGroupDI;

    [SerializeField]
    public float laborUnionDI;
    public Image I_laborUnionDI;

    [SerializeField]
    public float FDADI;
    public Image I_FDADI;

    [SerializeField]
    public float AnimalProtectionGroupDI;
    public Image I_AnimalProtectionGroupDI;

    //--------------------------------이벤트--------------
    public List<int> eventList;
    public Text T_evnetName;
    public Text T_eventText;
    public Text T_penalty;
    private string eventName;
    private string eventText;
    private string penalty;
    public Sprite[] Event_Images;


    //이벤트 반복횟수
    public int event6_Num;
    public int event8_Num;
    public int event9_Num;
    public int event12_Num;

    public int event7_Num;

    //이벤트 쿨타임
    public bool event3_Active;

    //이벤트발생조건
    public int event7_UpgradeNum;
    public int illegality_Stack;
    public int tier5Material;
    public int useGraySlime;
    public int useKingSlime;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                governmentDI = 80;
                consumerGroupDI = 80;
                environmentalGroupDI = 80;
                laborUnionDI = 80;
                FDADI = 80;
                AnimalProtectionGroupDI = 80;
                break;
            case DifficultManager.GameDifficult.easy:
                governmentDI = 80;
                consumerGroupDI = 80;
                environmentalGroupDI = 80;
                laborUnionDI = 80;
                FDADI = 80;
                AnimalProtectionGroupDI = 80;
                break;
            case DifficultManager.GameDifficult.normal:
                governmentDI = 100;
                consumerGroupDI = 100;
                environmentalGroupDI = 100;
                laborUnionDI = 100;
                FDADI = 100;
                AnimalProtectionGroupDI = 100;
                break;
            case DifficultManager.GameDifficult.hard:
                governmentDI = 120;
                consumerGroupDI = 120;
                environmentalGroupDI = 120;
                laborUnionDI = 120;
                FDADI = 120;
                AnimalProtectionGroupDI = 120;
                break;
            case DifficultManager.GameDifficult.endless:
                governmentDI = 100;
                consumerGroupDI = 100;
                environmentalGroupDI = 100;
                laborUnionDI = 100;
                FDADI = 100;
                AnimalProtectionGroupDI = 100;
                break;
            default:
                break;
        }
       
        DIImageUpdate();
        EventActive();
    }

    // Update is called once per frame
    void Update()
    {
        if ((GeneralMeetingUI.activeInHierarchy||EventUI.activeInHierarchy) && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&LocationManager.openUI==false)
        {
            LocationManager.openUI = true;
            GeneralMeetingUI.SetActive(true);
            SoundManager.S.PlaySE("닫기");
        }

    }
        public void DIImageUpdate()
    {
        if (governmentDI < 40)
            I_governmentDI.color = new Color(0f, 1f, 0f);
        else if (governmentDI < 80)
            I_governmentDI.color = new Color(0.5f, 1f, 0.5f);
        else if (governmentDI < 120)
            I_governmentDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (governmentDI < 160)
            I_governmentDI.color = new Color(1f,0.5f,0.5f);
        else I_governmentDI.color = new Color(1f,0f,0f);

        if (consumerGroupDI < 40)
            I_consumerGroupDI.color = new Color(0f, 1f, 0f);
        else if (consumerGroupDI < 80)
            I_consumerGroupDI.color = new Color(0.5f, 1f, 0.5f);
        else if (consumerGroupDI < 120)
            I_consumerGroupDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (consumerGroupDI < 160)
            I_consumerGroupDI.color = new Color(1f, 0.5f, 0.5f);
        else I_consumerGroupDI.color = new Color(1f, 0f, 0f);

        if (environmentalGroupDI < 40)
            I_environmentalGroupDI.color = new Color(0f, 1f, 0f);
        else if (environmentalGroupDI < 80)
            I_environmentalGroupDI.color = new Color(0.5f, 1f, 0.5f);
        else if (environmentalGroupDI < 120)
            I_environmentalGroupDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (environmentalGroupDI < 160)
            I_environmentalGroupDI.color = new Color(1f, 0.5f, 0.5f);
        else I_environmentalGroupDI.color = new Color(1f, 0f, 0f);

        if (laborUnionDI < 40)
            I_laborUnionDI.color = new Color(0f, 1f, 0f);
        else if (laborUnionDI < 80)
            I_laborUnionDI.color = new Color(0.5f, 1f, 0.5f);
        else if (laborUnionDI < 120)
            I_laborUnionDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (laborUnionDI < 160)
            I_laborUnionDI.color = new Color(1f, 0.5f, 0.5f);
        else I_laborUnionDI.color = new Color(1f, 0f, 0f);

        if (FDADI < 40)
            I_FDADI.color = new Color(0f, 1f, 0f);
        else if (FDADI < 80)
            I_FDADI.color = new Color(0.5f, 1f, 0.5f);
        else if (FDADI < 120)
            I_FDADI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (FDADI < 160)
            I_FDADI.color = new Color(1f, 0.5f, 0.5f);
        else I_FDADI.color = new Color(1f, 0f, 0f);

        if (AnimalProtectionGroupDI < 40)
            I_AnimalProtectionGroupDI.color = new Color(0f, 1f, 0f);
        else if (AnimalProtectionGroupDI < 80)
            I_AnimalProtectionGroupDI.color = new Color(0.5f, 1f, 0.5f);
        else if (AnimalProtectionGroupDI < 120)
            I_AnimalProtectionGroupDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (AnimalProtectionGroupDI < 160)
            I_AnimalProtectionGroupDI.color = new Color(1f, 0.5f, 0.5f);
        else I_AnimalProtectionGroupDI.color = new Color(1f, 0f, 0f);
    }

    public void GovernmentDIVariation(float _num)
    {
        governmentDI += _num;
        Mathf.Clamp(governmentDI, 0, 200);
        if (governmentDI < 40)
            I_governmentDI.color = new Color(0f, 1f, 0f);
        else if (governmentDI < 80)
            I_governmentDI.color = new Color(0.5f, 1f, 0.5f);
        else if (governmentDI < 120)
            I_governmentDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (governmentDI < 160)
            I_governmentDI.color = new Color(1f, 0.5f, 0.5f);
        else I_governmentDI.color = new Color(1f, 0f, 0f);
    }
    public void ConsumerGroupDIVariation(float _num)
    {
        consumerGroupDI += _num;
        Mathf.Clamp(consumerGroupDI, 0, 200);
        if (consumerGroupDI < 40)
            I_consumerGroupDI.color = new Color(0f, 1f, 0f);
        else if (consumerGroupDI < 80)
            I_consumerGroupDI.color = new Color(0.5f, 1f, 0.5f);
        else if (consumerGroupDI < 120)
            I_consumerGroupDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (consumerGroupDI < 160)
            I_consumerGroupDI.color = new Color(1f, 0.5f, 0.5f);
        else I_consumerGroupDI.color = new Color(1f, 0f, 0f);
    }
    public void EnvironmentalGroupDIVariation(float _num)
    {
        environmentalGroupDI += _num;
        Mathf.Clamp(environmentalGroupDI, 0, 200);
        if (environmentalGroupDI < 40)
            I_environmentalGroupDI.color = new Color(0f, 1f, 0f);
        else if (environmentalGroupDI < 80)
            I_environmentalGroupDI.color = new Color(0.5f, 1f, 0.5f);
        else if (environmentalGroupDI < 120)
            I_environmentalGroupDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (environmentalGroupDI < 160)
            I_environmentalGroupDI.color = new Color(1f, 0.5f, 0.5f);
        else I_environmentalGroupDI.color = new Color(1f, 0f, 0f);
    }
    public void LaborUnionDIVariation(float _num)
    {
        laborUnionDI += _num;
        Mathf.Clamp(laborUnionDI, 0, 200);
        if (laborUnionDI < 40)
            I_laborUnionDI.color = new Color(0f, 1f, 0f);
        else if (laborUnionDI < 80)
            I_laborUnionDI.color = new Color(0.5f, 1f, 0.5f);
        else if (laborUnionDI < 120)
            I_laborUnionDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (laborUnionDI < 160)
            I_laborUnionDI.color = new Color(1f, 0.5f, 0.5f);
        else I_laborUnionDI.color = new Color(1f, 0f, 0f);
    }
    public void FDADIVariation(float _num)
    {
        FDADI += _num;
        Mathf.Clamp(FDADI, 0, 200);
        if (FDADI < 40)
            I_FDADI.color = new Color(0f, 1f, 0f);
        else if (FDADI < 80)
            I_FDADI.color = new Color(0.5f, 1f, 0.5f);
        else if (FDADI < 120)
            I_FDADI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (FDADI < 160)
            I_FDADI.color = new Color(1f, 0.5f, 0.5f);
        else I_FDADI.color = new Color(1f, 0f, 0f);
    }
    public void AnimalProtectionGroupDIVariation(float _num)
    {
        AnimalProtectionGroupDI += _num;
        Mathf.Clamp(AnimalProtectionGroupDI, 0, 200);
        if (AnimalProtectionGroupDI < 40)
            I_AnimalProtectionGroupDI.color = new Color(0f, 1f, 0f);
        else if (AnimalProtectionGroupDI < 80)
            I_AnimalProtectionGroupDI.color = new Color(0.5f, 1f, 0.5f);
        else if (AnimalProtectionGroupDI < 120)
            I_AnimalProtectionGroupDI.color = new Color(0.5f, 0.5f, 0.5f);
        else if (AnimalProtectionGroupDI < 160)
            I_AnimalProtectionGroupDI.color = new Color(1f, 0.5f, 0.5f);
        else I_AnimalProtectionGroupDI.color = new Color(1f, 0f, 0f);
    }

    //-------------------------------------------정부기관 팝업 이벤트----------------------------------------
    public void DetectIllegalActivity()//1
    {
        EventImage.sprite = Event_Images[0];
        eventName = "탈세 적발";
        T_evnetName.text = eventName;
        eventText = "일부 임원들의 탈세가 적발되었습니다. 벌금과 함께 몇몇 기관의 불만이 증가합니다.";
        T_eventText.text = eventText;
        penalty = "벌금:" + (5000 + FarmUpgrade.S.TrashQualityUpTier*(CompanyValue.S.allValue/100)).ToString()+"\n 감사원 불만 증가, 그외 기관 불만 약간증가";
        MoneyManager.S.SpendMoney(5000 + FarmUpgrade.S.TrashQualityUpTier+1 * (CompanyValue.S.allValue / 100));
        GovernmentDIVariation(-10);
        EnvironmentalGroupDIVariation(2 + FarmUpgrade.S.TrashQualityUpTier * 2);
        ConsumerGroupDIVariation(2+FarmUpgrade.S.TrashQualityUpTier*2);
        LaborUnionDIVariation(2 + FarmUpgrade.S.TrashQualityUpTier * 2);
        FDADIVariation(2 + FarmUpgrade.S.TrashQualityUpTier * 2);
        AnimalProtectionGroupDIVariation(2 + FarmUpgrade.S.TrashQualityUpTier * 2);
        T_penalty.text = penalty;

    }

    public void DetectedBribeMajor()//2
    {
        EventImage.sprite = Event_Images[0];
        eventName = "매수 적발";
        T_evnetName.text = eventName;
        eventText = "이사회에서 특정 단체를 매수하려는 행위가 고발되었습니다. 벌금과 함께 해당 기관에서의 불만과 평판이 감소합니다.";
        T_eventText.text = eventText;
        penalty = "벌금:"+(3000+3000*FactoryUpgrade.S.ProductQualityUpTier).ToString()+", 평판 감소\n소비자,노동자조합 불만 증가";
        T_penalty.text = penalty;

        MoneyManager.S.SpendMoney(3000 + 3000 * FactoryUpgrade.S.ProductQualityUpTier);
        ConsumerGroupDIVariation(10);
        LaborUnionDIVariation(10);
        Shop.S.VariationFame(-75);
    }
    public void GovernmentDeficit()//3
    {
        EventImage.sprite = Event_Images[0];
        eventName = "감사 불합격";
        T_evnetName.text = eventName;
        eventText = "정부기관의 감사 결과 불합격 판정을 받았습니다 벌금과 함께 해당 기관의 불만이 증가합니다";
        T_eventText.text = eventText;
        penalty = "벌금:"+((CompanyValue.S.allValue/50)* FactoryUpgrade.S.ProductQualityUpTier).ToString()+"\n감사원 불만 증가";
        T_penalty.text = penalty;
        MoneyManager.S.SpendMoney((CompanyValue.S.allValue / 50) * FactoryUpgrade.S.ProductQualityUpTier);
        GovernmentDIVariation(5+5*FactoryUpgrade.S.ProductQualityUpTier);
    }
    //-------------------------------------------소비자단체 팝업 이벤트----------------------------------------

    public void ConsumerDemonstration()
    {
        EventImage.sprite = Event_Images[1];
        eventName = "불량품 데모";
        T_evnetName.text = eventName;
        eventText = "불량품으로 인해 불만이 생긴 소비자 단체가 각지에서 시위를 펼칩니다.";
        T_eventText.text = eventText;
        penalty = "감사원, 환경단체, 식약청 불만 증가\n평판감소, 모든 직원충성도 감소";
        T_penalty.text = penalty;
        GovernmentDIVariation(-10);
        EnvironmentalGroupDIVariation(5+ 5*FactoryUpgrade.S.ProductQualityUpTier);
        FDADIVariation(5 + 5 * FactoryUpgrade.S.ProductQualityUpTier);
        Shop.S.VariationFame(-50 + (-30 * FactoryUpgrade.S.ProductQualityUpTier));
        for (int i = 0; i < DayManager.S.allStaff.Length; i++)
        {
            if (DayManager.S.allStaff[i].GetStaffOn())
            {
                DayManager.S.allStaff[i].ChangeLoyalty(-(FactoryUpgrade.S.ProductQualityUpTier+1));
            }

        }

    }

    public void ComplaintsExplosion()
    {
        EventImage.sprite = Event_Images[1];
        eventName = "서비스 데모";
        T_evnetName.text = eventName;
        eventText = "회사의 질낮은 서비스에 불만이 생긴 소비자 단체가 시위를 펼칩니다";
        T_eventText.text = eventText;
        penalty = "소비자, 노동자조합 불만 증가\n평판감소, 모든 직원충성도 감소";
        T_penalty.text = penalty;

        ConsumerGroupDIVariation(20);
        LaborUnionDIVariation(10);
        Shop.S.VariationFame(-50+(-50*FarmUpgrade.S.TrashQualityUpTier));
        for (int i = 0; i < DayManager.S.allStaff.Length; i++)
        {
            if (DayManager.S.allStaff[i].GetStaffOn())
            {
                DayManager.S.allStaff[i].ChangeLoyalty(-(FarmUpgrade.S.TrashQualityUpTier + 1));
            }

        }
    }

    public void BlackConsumer()
    {
        if (event6_Num < 10)
        {
            event6_Num += 1;
        }
        EventImage.sprite = Event_Images[1];
        eventName = "불의의 사고";
        T_evnetName.text = eventName;
        eventText = "불의의 사고로 금전적, 정신적으로 피해를 입은 소비자들이 법적 대응을 시작합니다.";
        T_eventText.text = eventText;
        penalty = "벌금:"+(2500*event6_Num).ToString()+"\n평판감소";
        T_penalty.text = penalty;
        
        MoneyManager.S.SpendMoney(2500*event6_Num);
        Shop.S.VariationFame(-45*event6_Num);

    }

    //-------------------------------------------환경단체 팝업 이벤트----------------------------------------

    public void EnvironmentalGroupDemonstration()
    {
        if(event7_Num<10)
        {
            event7_Num += 1;
        }
        

        EventImage.sprite = Event_Images[2];
        eventName = "삼림 파괴 고발";
        T_evnetName.text = eventName;
        eventText = "이번 년도의 과도한 개발로 인해 환경단체에서 삼림파괴로 고발당했습니다";
        T_eventText.text = eventText;
        penalty = "벌금:"+(3000* event7_Num).ToString()+"\n모든기관 불만 증가";
        T_penalty.text = penalty;

        MoneyManager.S.SpendMoney(3000 * event7_Num);
        GovernmentDIVariation(5* event7_Num);
        EnvironmentalGroupDIVariation(5 * event7_Num);
        ConsumerGroupDIVariation(5 * event7_Num);
        LaborUnionDIVariation(5 * event7_Num);
        FDADIVariation(5 * event7_Num);
        AnimalProtectionGroupDIVariation(5 * event7_Num);
        event7_UpgradeNum -= 3;
    }
    public void EnviromentDemoonstration()
    {
        if (event8_Num < 5)
        {
            event8_Num += 1;
        }
        EventImage.sprite = Event_Images[2];
        eventName = "환경 데모";
        T_evnetName.text = eventName;
        eventText = "환경 파괴에 분노한 사람들이 각지에서 시위를 벌입니다.";
        T_eventText.text = eventText;
        penalty = "모든기관 불만 증가, 회사평판 감소"; ;
        T_penalty.text = penalty;

        GovernmentDIVariation(6 * event8_Num);
        EnvironmentalGroupDIVariation(6 * event8_Num);
        ConsumerGroupDIVariation(6 * event8_Num);
        LaborUnionDIVariation(6 * event8_Num);
        FDADIVariation(6 * event8_Num);
        AnimalProtectionGroupDIVariation(6 * event8_Num);
        Shop.S.VariationFame(-30*event8_Num);

        illegality_Stack -= 3;



    }

    public void EnviromentalGroupCharge()
    {
        if (event9_Num < 5)
        {
            event9_Num += 1;
        }
        EventImage.sprite = Event_Images[2];
        eventName = "페수 오염 고발";
        T_evnetName.text = eventName;
        eventText = "환경 파괴로 인한 폐수 오염으로 환경단체로부터 고발당했습니다.";
        T_eventText.text = eventText;
        penalty = "모든기관 불만 증가\n평판 감소, 상품단가 감소";
        T_penalty.text = penalty;

        GovernmentDIVariation(3 * event9_Num);
        EnvironmentalGroupDIVariation(3 * event9_Num);
        ConsumerGroupDIVariation(3 * event9_Num);
        LaborUnionDIVariation(3 * event9_Num);
        FDADIVariation(3 * event9_Num);
        AnimalProtectionGroupDIVariation(3 * event9_Num);
        Shop.S.VariationFame(-30 * event9_Num);
        ProductManager.S.ChangeAllPrice(-Random.Range(event9_Num, event9_Num * 2+1));

    }
    //-------------------------------------------노동자조합 팝업 이벤트----------------------------------------

    public void FrequentDismissal()
    {
        EventImage.sprite = Event_Images[3];
        eventName = "부당 해고 데모";
        T_evnetName.text = eventName;
        eventText = "부당 해고에 불만을 가진 노동자들이 시위를 벌입니다.";
        T_eventText.text = eventText;
        penalty ="감사원, 노동자조합 불만 증가\n모든 직원의 충성도를 10 낮춥니다.";
        T_penalty.text = penalty;

        GovernmentDIVariation(10);
        LaborUnionDIVariation(10);
        for (int i = 0; i < DayManager.S.allStaff.Length; i++)
        {
            if(DayManager.S.allStaff[i].GetStaffOn())
            {
                DayManager.S.allStaff[i].ChangeLoyalty(-10);
            }
            
        }

    }

    public void SalaryDemostration()
    {
        EventImage.sprite = Event_Images[3];
        eventName = "임금 인상 데모";
        T_evnetName.text = eventName;
        eventText = "회사 자본에 비해 낮은 임금에 불만을 가진 노동자들이 시위를 벌입니다.";
        T_eventText.text = eventText;
        penalty = "노동자조합 불만 증가, 직원들의 급여 상승\n직원들의 충성도 5감소";
        T_penalty.text = penalty;
        LaborUnionDIVariation(10);
        for (int i = 0; i < DayManager.S.allStaff.Length; i++)
        {
            if (DayManager.S.allStaff[i].GetStaffOn())
            {
                DayManager.S.allStaff[i].ChangeLoyalty(-5);
                DayManager.S.allStaff[i].IncreaseSalary(100 * Mathf.RoundToInt(laborUnionDI / 40));
            }

        }
        DayManager.S.yearStaffFireStack -= 3;

    }

    public void Walkout()
    {
        if (event12_Num <5)
        {
            event12_Num += 1;
        }
        EventImage.sprite = Event_Images[3];
        eventName = "파업";
        T_evnetName.text = eventName;
        eventText = "노동자들이 위법임을 알고서도 출근 거부를 시작합니다.";
        T_eventText.text = eventText;
        penalty = ", 회사평판 대폭감소, 단가"+ (2 * event12_Num ).ToString()+ "% 하락\n직원들의 충성도"+(5 * event12_Num).ToString()+" 감소";
        T_penalty.text = penalty;
        for (int i = 0; i < DayManager.S.allStaff.Length; i++)
        {
            if (DayManager.S.allStaff[i].GetStaffOn())
            {
                DayManager.S.allStaff[i].ChangeLoyalty(-5*event12_Num);
            }

        }
        Shop.S.VariationFame(-250 + (-100 * event12_Num));
        ProductManager.S.ChangeAllPrice(-2 * event12_Num);






    }
    //-------------------------------------------식약청 이벤트---------------------------------------------------------------------
    public void IllegalityFarming()
    {

        EventImage.sprite = Event_Images[4];
        eventName = "위생 기준 미달";
        T_evnetName.text = eventName;
        eventText = "생산 공정 과정 중 위생 수준이 미달이여 벌금을 물게 됩니다.";
        T_eventText.text = eventText;
        penalty = "벌금:10000,모든기관 불만증가, 평판감소" ;
        T_penalty.text = penalty;

        MoneyManager.S.SpendMoney(10000);
        Shop.S.VariationFame(-200);
        EnvironmentalGroupDIVariation(10);
        GovernmentDIVariation(10);
        ConsumerGroupDIVariation(10);
        LaborUnionDIVariation(10);
        FDADIVariation(10);
        AnimalProtectionGroupDIVariation(10);
    }
    public void UseDangerMaterial()
    {
        EventImage.sprite = Event_Images[4];
        eventName = "상품 내 성분 평가 미달";
        T_evnetName.text = eventName;
        eventText = "상품 검사 결과 상품 내 성분 평가 미달이 발견되어 제재를 받게 됩니다.";
        T_eventText.text = eventText;
        penalty = "벌금:5000, 감사원, 식약청 불만 증가\n평판 감소";
        T_penalty.text = penalty;

        MoneyManager.S.SpendMoney(5000);
        GovernmentDIVariation(10);
        FDADIVariation(10);
        Shop.S.VariationFame(-150);

    }
    public void UseLowClassMaterial()
    {
        EventImage.sprite = Event_Images[4];
        eventName = "발암 물질 발견";
        T_evnetName.text = eventName;
        eventText = "상품에서 치명적인 발암물질이 발견되어 제재를 받게 됩니다.";
        T_eventText.text = eventText;
        int value = Random.Range(3, 10);
        penalty = "상품 단가" + value.ToString() + "%하락, 평판감소\n소비자단체,노동자조합 불만증가";
        T_penalty.text = penalty;
        Shop.S.VariationFame(-50+(-50 * FarmUpgrade.S.TrashQualityUpTier));
        ProductManager.S.ChangeAllPrice(value);
        ConsumerGroupDIVariation(3+3 * FarmUpgrade.S.TrashQualityUpTier);
        LaborUnionDIVariation(3 + 3 * FarmUpgrade.S.TrashQualityUpTier);
        illegality_Stack += 2;
    }
    //-----------------------------------------------동물보호단체 이벤트----------------------------------------
    public void AbuseSlime()
    {
        EventImage.sprite = Event_Images[5];
        eventName = "슬라임 보호 시위";
        T_evnetName.text = eventName;
        eventText = "동물 애호가들이 슬라임은 애완 동물과 같다며 소비 반대 시위를 합니다.";
        T_eventText.text = eventText;
        penalty = "회사평판 감소,\n소비자단체,노동자조합 불만증가";
        T_penalty.text = penalty;

        int value = CompanyValue.S.allValue;
        value = Mathf.Clamp(value, 0, 500000);

        Shop.S.VariationFame(-value/1000);
        ConsumerGroupDIVariation(value / 10000);
        LaborUnionDIVariation(value / 10000);
    }
    public void SlimeManufacture()
    {
        EventImage.sprite = Event_Images[5];
        eventName = "불법 취재로 인한 선동";
        T_evnetName.text = eventName;
        eventText = "슬라임 양식 및 처리 과정을 담은 불법 취재 동영상이 유행합니다.";
        T_eventText.text = eventText;
        penalty = "평판감소,\n감사원,환경단체,식약청 불만증가";
        T_penalty.text = penalty;

        int value = CompanyValue.S.allValue;
        value = Mathf.Clamp(value, 0, 500000);

        Shop.S.VariationFame(-value / 1000);
        EnvironmentalGroupDIVariation(value / 10000);
        GovernmentDIVariation(value / 10000);
        FDADIVariation(value / 10000);
        illegality_Stack += 1;

    }
    public void BribeExecutive()
    {
        EventImage.sprite = Event_Images[5];
        eventName = "불매 운동";
        T_evnetName.text = eventName;
        eventText = "슬라임 보호를 주장하는 단체들이 불매운동을 펼칩니다.";
        T_eventText.text = eventText;
        penalty = "회사 평판 절반감소, 동물 보호단체 불만 대폭 증가\n상품단가 6%하락, 직원들의 충성도20감소";
        T_penalty.text = penalty;

        AnimalProtectionGroupDIVariation(30);
        Shop.S.VariationFame((int)(-Shop.S.fame/2));
        for (int i = 0; i < DayManager.S.allStaff.Length; i++)
        {
            if (DayManager.S.allStaff[i].GetStaffOn())
            {
                DayManager.S.allStaff[i].ChangeLoyalty(-20);
            }

        }
        ProductManager.S.ChangeAllPrice(-6);
    }

    public void DayEventCheck()
    {
        if (event7_UpgradeNum>=4)//환경부-1
        {
                eventList.Add(7);
        }
        if (illegality_Stack>=4)//환경부-2
        {
                eventList.Add(8);
        }
        if (CompanyValue.S.allValue * 2.5f < MoneyManager.S.CurrentMoney()&&DayManager.S.yearStaffFireStack>=3)//노동부-1
        {

            int value = Random.Range(0, 99);
            if (value < 66)
            {
                eventList.Add(10);
            }
        }
        EventActive();

    }

    public void MonthEventCheak()
    {
        if (governmentDI >= 110)//정부-1
        {
            int value = Random.Range(0,80);
            if (DayManager.S.StaffLoyaltyUnderHalf())
            {
                if (value < 30)
                {
                    eventList.Add(1);
                }
            }
            else
            {
                if (value < 10)
                {
                    eventList.Add(1);
                }
            }
            

        }
        if (governmentDI >= 60&&CompanyValue.S.allValue>=40000+40000*FactoryUpgrade.S.ProductQualityUpTier)//정부-2
        {
            if (consumerGroupDI<=100||laborUnionDI<=100)
            {
                int value = Random.Range(0, 100);
                if (value <25)
                {
                    eventList.Add(2);
                }
            }
           

        }

        if (governmentDI <= 150 && CompanyValue.S.allValue >= 50000 + 50000 * FactoryUpgrade.S.ProductQualityUpTier && event3_Active ==false)//정부-3
        {
            int value = Random.Range(0,100);
            if (value < 25)
            {
                eventList.Add(3);
                event3_Active = true;
            }        

        }
        if (consumerGroupDI >= 100 &&Archive.S.profits>0)//소비자-1
        {
            int value = Random.Range(0,96);
            if (value <16)
            {
                eventList.Add(4);
            }

        }
        if (consumerGroupDI >= 50&&CompanyValue.S.allValue>=20000+20000*FarmUpgrade.S.TrashQualityUpTier)//소비자-2
        {
            int value = Random.Range(0,100);
            if (DayManager.S.StaffLoyaltyUnderHalf())
            {
                if (value < 50)
                {
                    eventList.Add(5);
                }
            }
            else
            {
                if (value < 13)
                {
                    eventList.Add(5);
                }
            }

        }
        if (CompanyValue.S.allValue*2.5f<MoneyManager.S.CurrentMoney())//소비자-3
        {
            int loyaltyValue = 0;
            if (DayManager.S.StaffLoyaltyUnderHalf())
            {
                loyaltyValue = 50;
            }
            if (consumerGroupDI <= 50)
            {
                int value = Random.Range(0, 100);
                if (value < 50+ loyaltyValue)
                {
                    eventList.Add(6);
                }

            }
            else
            {
                int value = Random.Range(0, 100);
                if (value < 33+ loyaltyValue)
                {
                    eventList.Add(6);
                }
            }
        }
        if (environmentalGroupDI >= 60)//환경부-3
        {
            int value = Random.Range(0, 100);
            if (environmentalGroupDI >= 120)
            {
                if (value < 25)
                {
                    eventList.Add(9);
                }
            }
            else
            {
                if (value < 12)
                {
                    eventList.Add(9);
                }
            }
            
        }
        if (laborUnionDI >= 40&&DayManager.S.year>0&& CompanyValue.S.allValue * 2.5f < MoneyManager.S.CurrentMoney())//노동부-2
        {
            int value = Random.Range(0, 100);
            if (value < 10)
            {
                eventList.Add(11);
            }
        }




        if (FDADI >= 115)//식약청-1
        {
            int value = Random.Range(0,99);
            if (value <33)
            {
                eventList.Add(13);
            }
            
        }
        if (FDADI >= 75&&FactoryUpgrade.S.ProductQualityUpTier>=1&&illegality_Stack>0)//식약청-2
        {
            int value = Random.Range(0,100);
            if (value <20)
            {
                eventList.Add(14);
            }
        }
        
        if (AnimalProtectionGroupDI>=20&&CompanyValue.S.allValue>=60000)//동물보호단체-1
        {
            int value = Random.Range(0,100);
            if (value <20)
            {
                eventList.Add(16);
                
            }
        }
        if (AnimalProtectionGroupDI >= 45 && CompanyValue.S.allValue >= 100000)//동물보호단체-2
        {
            int value = Random.Range(0,100);
            if (value <25)
            {
                eventList.Add(17);

            }
        }
        if (AnimalProtectionGroupDI >= 60&& CompanyValue.S.allValue >= 150000&&illegality_Stack>=2)//동물보호단체-3
        {
            float value = Random.Range(0, 99);
            if (value < 33)
            {
                eventList.Add(18);
            }
        }
        EventActive();
    }

    public void yearEventCheak()
    {

        if (laborUnionDI >= 125&& DayManager.S.year > 0 && CompanyValue.S.allValue * 2.5f < MoneyManager.S.CurrentMoney())//노동부-3
        {
            int value = Random.Range(0, 100);
            if (DayManager.S.StaffLoyaltyUnderHalf())
            {
                if (value < 50)
                {
                    eventList.Add(12);
                }
            }
            else
            {
                if (value < 80)
                {
                    eventList.Add(12);
                }
            }
           

        }
        if (DayManager.S.year>5&&FactoryUpgrade.S.ProductQualityUpTier>=2)//식약청-3
        {
            int value = Random.Range(0, 100);
            if (FDADI>=100)
            {
                if (value < 50)
                {
                    eventList.Add(15);
                }
            }
            else
            {
                if (value < 25)
                {
                    eventList.Add(15);
                }
            }
         
        }
      
        event3_Active = false;
        EventActive();
    }

    public void EventActive()
    {
        
        if (eventList.Count>=1)
        {
            if(Time.timeScale>0)
            {
                Pause.S.PauseGame();
            }
            
                switch (eventList[0])
                {
                    case 1:
                        DetectIllegalActivity();
                        break;
                    case 2:
                        DetectedBribeMajor();
                        break;
                    case 3:
                        GovernmentDeficit();
                        break;
                    case 4:
                        ConsumerDemonstration();
                        break;
                    case 5:
                        ComplaintsExplosion();
                        break;
                    case 6:
                        BlackConsumer();
                        break;
                    case 7:
                        EnvironmentalGroupDemonstration();
                        break;
                    case 8:
                        EnviromentDemoonstration();
                        break;
                    case 9:
                        EnviromentalGroupCharge();
                        break;
                    case 10:
                        FrequentDismissal();
                        break;
                    case 11:
                        SalaryDemostration();
                        break;
                    case 12:
                        Walkout();
                        break;
                    case 13:
                        IllegalityFarming();
                        break;
                    case 14:
                        UseDangerMaterial();
                        break;
                    case 15:
                        UseLowClassMaterial();
                        break;
                    case 16:
                        AbuseSlime();
                        break;
                    case 17:
                        SlimeManufacture();
                        break;
                    case 18:
                        BribeExecutive();
                        break;
                    default:
                        break;
                }
            DayManager.S.PopupEventCheck();
            if (!EventUI.gameObject.activeInHierarchy)
            {
                EventUI.SetActive(true);

            }
            eventList.RemoveAt(0);
        }
        else
        {
            EventUI.SetActive(false);
            LocationManager.openUI = false;
            if (Time.timeScale == 0)
            {
                Pause.S.PauseGame();
            }
        }

    }
  

    public void Use5TierMaterial(int _num)
    {
        tier5Material += _num;
        if (tier5Material>=20)
        {
            tier5Material -= 20;
            illegality_Stack += 1;
        }
        illegality_Stack = Mathf.Clamp(illegality_Stack, 0, 20);
    }
    public void UseGraySlime(int _num)
    {
        useGraySlime += _num;
        if (tier5Material >= 100)
        {
            useGraySlime -= 100;
            illegality_Stack += 1;
        }
        illegality_Stack = Mathf.Clamp(illegality_Stack, 0, 20);
    }
    public void UseKingSlime(int _num)
    {
        useKingSlime += _num;
        if (useKingSlime >= 20)
        {
            useKingSlime -= 20;
            illegality_Stack -= 1;
            
        }
        illegality_Stack= Mathf.Clamp(illegality_Stack, 0, 20);
    }
    public void PlusUpgradeNum()
    {
        if (DayManager.S.year==0&&DayManager.S.month==1)
        {
            return;
        }
        event7_UpgradeNum += 1;
    }
}
