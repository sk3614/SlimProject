using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Archive : MonoBehaviour
{
    public static Archive S;
    //돈계산은 달끝날떄
    public int sumSpendMoney;
    public int sumGetMoney;
    public int profits;
    public int[] monthProfits;//달 이익
    public int[] monthSpendMoney; //달 소비
    public int[] monthGetMoney; //달 얻은돈
    public int[] haveMoney;//가지고있는돈
    public int[] earnMoney;

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

    public LineRenderer HaveMoneylineRenderer;
    public int MaxCurrentMoney;
    public Text T_MaxCurrentMoney;
    public int MinCurrentMoney;
    public Text T_MinCurrentMoney;

    public int MaxGrowMoney;
    public Text T_MaxGrowMoney;
    public int MinGrowMoney;
    public Text T_MinGrowMoney;

    public GameObject CMoneyGraph;
    public GameObject GMoneyGraph;
    public GameObject MoneyChart;
    public GameObject MaterialChart;
    public GameObject SlimeChart;
    public GameObject ProductChart;
    public GameObject FameGraph;
    public GameObject CompanyValueGraph;

    public GameObject[] fameGraph;
    public CompanyGraph f_Draw;
    public GameObject[] currentMoneyGraph;
    public CompanyGraph c_Draw;
    public GameObject[] growMoneyGraph;
    public CompanyGraph g_Draw;
    public GameObject[] ValueGraph;
    public CompanyGraph v_Draw;

    public bool __________________UI______________________;

    public GameObject UI;


    public Text T_GetPast1;
    public Text T_GetPast2;
    public Text T_GetPast3;
    public Text T_GetPast4;


    public Text T_SpendPast1;
    public Text T_SpendPast2;
    public Text T_SpendPast3;
    public Text T_SpendPast4;


    public Text T_ProfitPast1;
    public Text T_ProfitPast2;
    public Text T_ProfitPast3;
    public Text T_ProfitPast4;

    public Text[] T_HaveMoney;

    public Text[] T_GrowMoney;
    public Text[] T_material1M;
    public Text[] T_material2M;
    public Text[] T_material3M;
    public Text[] T_material4M;

    public Text[] T_Slime1M;
    public Text[] T_Slime2M;
    public Text[] T_Slime3M;
    public Text[] T_Slime4M;

    public Text[] T_Product1M;
    public Text[] T_Product2M;
    public Text[] T_Product3M;
    public Text[] T_Product4M;

    //회사가치
    public int[] Value;
    public int maxCompanyValue;
    public Text[] T_value;
    public Text nowCompanyValue;
    public Text T_maxCompanyValue;

    void Awake()
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
        SetText();
        CurrentMoneyGraph();
        GrowMoneyGraph();
    }
    private void Update()
    {
        if (UI.activeInHierarchy && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }
    // Update is called once per frame
    private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            if (!LocationManager.openUI)
            {
                UI.SetActive(true);
                OpenCMoneyGraph();
                CurrentMoneyGraph();
                LocationManager.openUI = true;
                SoundManager.S.PlaySE("터치");

            }
        }
    }
    public void SumSpendMoney(int _num)
    {
        sumSpendMoney += _num;
    }
    public void SumGetMoney(int _num)
    {
        sumGetMoney += _num;
    }
    public void ShowMoenyInfo()
    {
        print("얻은돈"+sumGetMoney);
        print("쓴돈"+sumSpendMoney);
        print("번돈" + (sumGetMoney - sumSpendMoney));

        sumGetMoney = 0;
        sumSpendMoney = 0;
        profits = 0;
    }
    public void ChangeMonth()
    {
        profits = sumGetMoney - sumSpendMoney;

        if (Scenario.S.scenarioMaxNum==18)
        {
            if (profits>0)
            {
                Scenario.S.H_scenario18_month += 1;
            }
            else
            {
                Scenario.S.H_scenario18_month = 0;
            }
        }
        if (monthGetMoney[7]!=0)
        {
            for (int i = 0; i < 7; i++)
            {
                monthGetMoney[i] = monthGetMoney[i + 1];
            }
            monthGetMoney[7] = sumGetMoney;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (monthGetMoney[7 - i] == 0)
                {
                    monthGetMoney[7 - i] = sumGetMoney;
                    break;
                }
            }
        }
        if (monthSpendMoney[7] != 0)
        {
            for (int i = 0; i < 7; i++)
            {
                monthSpendMoney[i] = monthSpendMoney[i + 1];
            }
            monthSpendMoney[7] = sumSpendMoney;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (monthSpendMoney[7 - i] == 0)
                {
                    monthSpendMoney[7 - i] = sumSpendMoney;
                    break;
                }
            }
        }
        if (monthProfits[7] != 0)
        {
            for (int i = 0; i < 7; i++)
            {
                monthProfits[i] = monthProfits[i + 1];
            }
            monthProfits[7] = profits;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (monthProfits[7 - i] == 0)
                {
                    monthProfits[7 - i] = profits;
                    break;
                }
            }
        }
        if (haveMoney[7] != 0)
        {
            for (int i = 0; i < 7; i++)
            {
                haveMoney[i] = haveMoney[i + 1];
            }
            haveMoney[7] = MoneyManager.S.CurrentMoney();
        }
        else
        {
            haveMoney[7] = MoneyManager.S.CurrentMoney();
        }

        if (earnMoney[7] != 0)
        {
            for (int i = 0; i < 7; i++)
            {
                earnMoney[i] = earnMoney[i + 1];
            }
            earnMoney[7] = haveMoney[7]-haveMoney[6];
        }
        else
        {
            earnMoney[7] = haveMoney[7] - haveMoney[6];
            if (DayManager.S.year == 0 && DayManager.S.month == 2)
            {
                earnMoney[7] -= MoneyManager.S.startMoney;
            }
        }

        SetMaterial();
        SetSlimeStack();
        SetProduct();
        SetFame();
        SetValue();
        DrawFameGraph();
        SetText();
        sumGetMoney = 0;
        sumSpendMoney = 0;
        profits = 0;
    }
    public void SetText()
    {
        T_GetPast1.text = "1분기전:"+monthGetMoney[7].ToString();
        T_GetPast2.text = "2분기전:" + monthGetMoney[6].ToString();
        T_GetPast3.text = "3분기전:" + monthGetMoney[5].ToString();
        T_GetPast4.text = "4분기전:" + monthGetMoney[4].ToString();

        T_SpendPast1.text = "1분기전:" + monthSpendMoney[7].ToString();
        T_SpendPast2.text = "2분기전:" + monthSpendMoney[6].ToString();
        T_SpendPast3.text = "3분기전:" + monthSpendMoney[5].ToString();
        T_SpendPast4.text = "4분기전:" + monthSpendMoney[4].ToString();

        T_ProfitPast1.text = "1분기전:" + monthProfits[7].ToString();
        T_ProfitPast2.text = "2분기전:" + monthProfits[6].ToString();
        T_ProfitPast3.text = "3분기전:" + monthProfits[5].ToString();
        T_ProfitPast4.text = "4분기전:" + monthProfits[4].ToString();


        T_material1M[0].text = "1등급:" + materialTier1[3];
        T_material1M[1].text = "2등급:" + materialTier2[3];
        T_material1M[2].text = "3등급:" + materialTier3[3];
        T_material1M[3].text = "4등급:" + materialTier4[3];
        T_material1M[4].text = "5등급:" + materialTier5[3];
        T_material1M[5].text = "6등급:" + materialTier6[3];

        T_material2M[0].text = "1등급:" + materialTier1[2];
        T_material2M[1].text = "2등급:" + materialTier2[2];
        T_material2M[2].text = "3등급:" + materialTier3[2];
        T_material2M[3].text = "4등급:" + materialTier4[2];
        T_material2M[4].text = "5등급:" + materialTier5[2];
        T_material2M[5].text = "6등급:" + materialTier6[2];
    
        T_material3M[0].text = "1등급:" + materialTier1[1];
        T_material3M[1].text = "2등급:" + materialTier2[1];
        T_material3M[2].text = "3등급:" + materialTier3[1];
        T_material3M[3].text = "4등급:" + materialTier4[1];
        T_material3M[4].text = "5등급:" + materialTier5[1];
        T_material3M[5].text = "6등급:" + materialTier6[1];

        T_material4M[0].text = "1등급:" + materialTier1[0];
        T_material4M[1].text = "2등급:" + materialTier2[0];
        T_material4M[2].text = "3등급:" + materialTier3[0];
        T_material4M[3].text = "4등급:" + materialTier4[0];
        T_material4M[4].text = "5등급:" + materialTier5[0];
        T_material4M[5].text = "6등급:" + materialTier6[0];

        T_Slime1M[0].text = "회색:" + graySlime[3];
        T_Slime1M[1].text = "1등급:" + Slime1[3];
        T_Slime1M[2].text = "2등급:" + Slime2[3];
        T_Slime1M[3].text = "3등급:" + Slime3[3];
        T_Slime1M[4].text = "4등급:" + Slime4[3];
        T_Slime1M[5].text = "5등급:" + Slime5[3];
        T_Slime1M[6].text = "킹슬라임:" + Slime6[3];
        T_Slime1M[7].text = "쌍둥이 생산:" + TwinSlime[3];

        T_Slime2M[0].text = "회색:" + graySlime[2];
        T_Slime2M[1].text = "1등급:" + Slime1[2];
        T_Slime2M[2].text = "2등급:" + Slime2[2];
        T_Slime2M[3].text = "3등급:" + Slime3[2];
        T_Slime2M[4].text = "4등급:" + Slime4[2];
        T_Slime2M[5].text = "5등급:" + Slime5[2];
        T_Slime2M[6].text = "킹슬라임:" + Slime6[2];
        T_Slime2M[7].text = "쌍둥이 생산:" + TwinSlime[3];

        T_Slime3M[0].text = "회색:" + graySlime[1];
        T_Slime3M[1].text = "1등급:" + Slime1[1];
        T_Slime3M[2].text = "2등급:" + Slime2[1];
        T_Slime3M[3].text = "3등급:" + Slime3[1];
        T_Slime3M[4].text = "4등급:" + Slime4[1];
        T_Slime3M[5].text = "5등급:" + Slime5[1];
        T_Slime3M[6].text = "킹슬라임:" + Slime6[1];
        T_Slime3M[7].text = "쌍둥이 생산:" + TwinSlime[1];

        T_Slime4M[0].text = "회색:" + graySlime[0];
        T_Slime4M[1].text = "1등급:" + Slime1[0];
        T_Slime4M[2].text = "2등급:" + Slime2[0];
        T_Slime4M[3].text = "3등급:" + Slime3[0];
        T_Slime4M[4].text = "4등급:" + Slime4[0];
        T_Slime4M[5].text = "5등급:" + Slime5[0];
        T_Slime4M[6].text = "킹슬라임:" + Slime6[0];
        T_Slime4M[7].text = "쌍둥이 생산:" + TwinSlime[0];

        T_Product1M[0].text = "약품:" + Drugs[3];
        T_Product1M[1].text = "얼음제품:" + Ice[3];
        T_Product1M[2].text = "유리제품:" + Glass[3];
        T_Product1M[3].text = "연료:" + Fuel[3];

        T_Product2M[0].text = "약품:" + Drugs[2];
        T_Product2M[1].text = "얼음제품:" + Ice[2];
        T_Product2M[2].text = "유리제품:" + Glass[2];
        T_Product2M[3].text = "연료:" + Fuel[2];

        T_Product3M[0].text = "약품:" + Drugs[1];
        T_Product3M[1].text = "얼음제품:" + Ice[1];
        T_Product3M[2].text = "유리제품:" + Glass[1];
        T_Product3M[3].text = "연료:" + Fuel[1];

        T_Product4M[0].text = "약품:" + Drugs[0];
        T_Product4M[1].text = "얼음제품:" + Ice[0];
        T_Product4M[2].text = "유리제품:" + Glass[0];
        T_Product4M[3].text = "연료:" + Fuel[0];




    }

    public void CurrentMoneyGraph()
    {
        MaxCurrentMoney = 10000;
        T_MaxCurrentMoney.text = MaxCurrentMoney.ToString();
        MinCurrentMoney = -100;
        T_MinCurrentMoney.text = MinCurrentMoney.ToString();
        for (int i = 0; i < haveMoney.Length; i++)
        {
            if(MaxCurrentMoney<=haveMoney[i])
            {
                MaxCurrentMoney = haveMoney[i];
                T_MaxCurrentMoney.text = MaxCurrentMoney.ToString();
            }
            if (MinCurrentMoney >= haveMoney[i])
            {
                MinCurrentMoney = haveMoney[i];
                T_MinCurrentMoney.text = MinCurrentMoney.ToString();
            }
        }
        List<int> moneyValue = new List<int>();
        for (int i = 0; i < haveMoney.Length; i++)
        {
            moneyValue.Add(haveMoney[7 - i]);
        }

        c_Draw.ShowGraph(moneyValue, MaxCurrentMoney,MinCurrentMoney);


        for (int i = 0; i < currentMoneyGraph.Length; i++)
        {
            float value;
            if (haveMoney[7 - i]>0)
            {
                value = (float)haveMoney[7 - i] / MaxCurrentMoney;
            }
            else
            {
                value = (float)haveMoney[7 - i] / -MinCurrentMoney;
            }
                T_HaveMoney[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(T_HaveMoney[i].GetComponent<RectTransform>().anchoredPosition.x, 250f * value);
                T_HaveMoney[i].text = (i + 1).ToString() + "분기전\n" + haveMoney[7 - i].ToString();
                T_HaveMoney[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        }


    }
    public void GrowMoneyGraph()
    {
        MaxGrowMoney = 1000;
        T_MaxGrowMoney.text = MaxGrowMoney.ToString();
        MinGrowMoney = -1000;
        T_MinGrowMoney.text = MinGrowMoney.ToString();
        for (int i = 0; i < earnMoney.Length; i++)
        {
            if (MaxGrowMoney <= earnMoney[i])
            {
                MaxGrowMoney = earnMoney[i];
                T_MaxGrowMoney.text = MaxGrowMoney.ToString();
            }
            if (MinGrowMoney >= earnMoney[i])
            {
                MinGrowMoney = earnMoney[i];
                T_MinGrowMoney.text = MinGrowMoney.ToString();
            }
        }
        List<int> moneyValue = new List<int>();
        for (int i = 0; i < earnMoney.Length; i++)
        {
            moneyValue.Add(earnMoney[7 - i]);
        }

        g_Draw.ShowGraph(moneyValue, MaxGrowMoney,MinGrowMoney);

        for (int i = 0; i < growMoneyGraph.Length; i++)
        {
            float value;
            if (earnMoney[7 - i]>0)
            {
                value = (float)earnMoney[7 - i] / MaxGrowMoney;
            }
            else
            {
                value = (float)earnMoney[7 - i] / -MinGrowMoney;
            }
           

            T_GrowMoney[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(T_GrowMoney[i].GetComponent<RectTransform>().anchoredPosition.x, 250f * value);
            T_GrowMoney[i].text = (i + 1).ToString() + "분기전\n" + earnMoney[7 - i].ToString();
            T_GrowMoney[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);


        }
    }
    public void DrawFameGraph()
    {
        List<int> fame = new List<int>();
        for (int i = 0; i < Fame.Length; i++)
        {
            fame.Add(Fame[3 - i]);
        }

        f_Draw.ShowGraph(fame,1000);

    }
    public void DrawValueGraph()
    {
        maxCompanyValue = 100;
        T_maxCompanyValue.text = maxCompanyValue.ToString();
        for (int i = 0; i < Value.Length; i++)
        {
            if (maxCompanyValue <= Value[i])
            {
                maxCompanyValue = Value[i];
                T_maxCompanyValue.text = maxCompanyValue.ToString();
            }
        }
        List<int> value = new List<int>();
        for (int i = 0; i < Value.Length; i++)
        {
            value.Add(Value[3 - i]);
            T_value[i].text = (i + 1).ToString() + "분기전\n" + value[i].ToString();
        }

        v_Draw.ShowGraph(value, maxCompanyValue);
        nowCompanyValue.text = "현재 회사가치 : " +CompanyValue.S.allValue.ToString();
    }

    public void PlusMaterialStack(int i)
    {
        
        material[i] += 1;
    }
    public void PlusSlimeStack(int i)//0=회색,7=쌍둥이)
    {
        Slime[i] += 1;
    }
    public void PlusProductStack(int _drugs, int _ice, int _glass, int _fuel )
    {
        Product[0] += _drugs;
        Product[1] += _ice;
        Product[2] += _glass;
        Product[3] += _fuel;
    }
    public void OpenMoneyChart()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(false);
        GMoneyGraph.SetActive(false);
        MoneyChart.SetActive(true);
        MaterialChart.SetActive(false);
        SlimeChart.SetActive(false);
        FameGraph.SetActive(false);
        ProductChart.SetActive(false);
        CompanyValueGraph.SetActive(false);


    }
    public void OpenCMoneyGraph()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(true);
        GMoneyGraph.SetActive(false);
        MoneyChart.SetActive(false);
        MaterialChart.SetActive(false);
        SlimeChart.SetActive(false);
        FameGraph.SetActive(false);
        ProductChart.SetActive(false);
        CompanyValueGraph.SetActive(false);
    }
    public void OpenGMoneyGraph()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(false);
        GMoneyGraph.SetActive(true);
        MoneyChart.SetActive(false);
        MaterialChart.SetActive(false);
        SlimeChart.SetActive(false);
        FameGraph.SetActive(false);
        ProductChart.SetActive(false);
        CompanyValueGraph.SetActive(false);
    }
    public void OpenMaterialChart()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(false);
        GMoneyGraph.SetActive(false);
        MoneyChart.SetActive(false);
        MaterialChart.SetActive(true);
        SlimeChart.SetActive(false);
        FameGraph.SetActive(false);
        ProductChart.SetActive(false);
        CompanyValueGraph.SetActive(false);
    }
    public void OpenSlimeChart()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(false);
        GMoneyGraph.SetActive(false);
        MoneyChart.SetActive(false);
        MaterialChart.SetActive(false);
        SlimeChart.SetActive(true);
        FameGraph.SetActive(false);
        ProductChart.SetActive(false);
        CompanyValueGraph.SetActive(false);
    }

    public void OpenProductChart()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(false);
        GMoneyGraph.SetActive(false);
        MoneyChart.SetActive(false);
        MaterialChart.SetActive(false);
        SlimeChart.SetActive(false);
        FameGraph.SetActive(false);
        ProductChart.SetActive(true);
        CompanyValueGraph.SetActive(false);
    }
    public void OpenFameGraph()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(false);
        GMoneyGraph.SetActive(false);
        MoneyChart.SetActive(false);
        MaterialChart.SetActive(false);
        SlimeChart.SetActive(false);
        FameGraph.SetActive(true);
        ProductChart.SetActive(false);
        CompanyValueGraph.SetActive(false);
    }
    public void OpenCompanyValueGraph()
    {
        SoundManager.S.PlaySE("터치");
        CMoneyGraph.SetActive(false);
        GMoneyGraph.SetActive(false);
        MoneyChart.SetActive(false);
        MaterialChart.SetActive(false);
        SlimeChart.SetActive(false);
        FameGraph.SetActive(false);
        ProductChart.SetActive(false);
        CompanyValueGraph.SetActive(true);
    }
    public void SetFame()
    {
        if (Fame[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Fame[i] = Fame[i + 1];
            }
            Fame[3] = (int)Shop.S.fame;
        }
        else
        {
            Fame[3] = (int)Shop.S.fame;
        }
    }
    public void SetValue()
    {
        if (Value[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Value[i] = Value[i + 1];
            }
            Value[3] = CompanyValue.S.allValue;
        }
        else
        {
            Value[3] = CompanyValue.S.allValue;
        }
    }
    public void SetProduct()
    {
        if (Drugs[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Drugs[i] = Drugs[i + 1];
            }
            Drugs[3] = Product[0];
        }
        else
        {
            Drugs[3] = Product[0];
        }

        if (Ice[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Ice[i] = Ice[i + 1];
            }
            Ice[3] = Product[1];
        }
        else
        {
            Ice[3] = Product[1];
        }

        if (Glass[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Glass[i] = Glass[i + 1];
            }
            Glass[3] = Product[2];
        }
        else
        {
            Glass[3] = Product[2];
        }

        if (Fuel[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Fuel[i] = Fuel[i + 1];
            }
            Fuel[3] = Product[3];
        }
        else
        {
            Fuel[3] = Product[3];
        }
        for (int i = 0; i < Product.Length; i++)
        {
            Product[i] = 0;
        }
    }
    public void SetMaterial()
    {
        if (materialTier1[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                materialTier1[i] = materialTier1[i + 1];
            }
            materialTier1[3] = material[0];
        }
        else
        {
            materialTier1[3] = material[0];
        }

        if (materialTier2[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                materialTier2[i] = materialTier2[i + 1];
            }
            materialTier2[3] = material[1];
        }
        else
        {
            materialTier2[3] = material[1];
        }

        if (materialTier3[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                materialTier3[i] = materialTier3[i + 1];
            }
            materialTier3[3] = material[2];
        }
        else
        {
            materialTier3[3] = material[2];
        }

        if (materialTier4[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                materialTier4[i] = materialTier4[i + 1];
            }
            materialTier4[3] = material[3];
        }
        else
        {
            materialTier4[3] = material[3];
        }

        if (materialTier5[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                materialTier5[i] = materialTier5[i + 1];
            }
            materialTier5[3] = material[4];
        }
        else
        {
            materialTier5[3] = material[4];
        }

        if (materialTier6[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                materialTier6[i] = materialTier6[i + 1];
            }
            materialTier6[3] = material[5];
        }
        else
        {
            materialTier6[3] = material[5];
        }
        for (int i = 0; i < material.Length; i++)
        {
            material[i] = 0;
        }
    }

    public void SetSlimeStack()
    {
        if (graySlime[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                graySlime[i] = graySlime[i + 1];
            }
            graySlime[3] = Slime[0];
        }
        else
        {
            graySlime[3] = Slime[0];
        }

        if (Slime1[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Slime1[i] = Slime1[i + 1];
            }
            Slime1[3] = Slime[1];
        }
        else
        {
            Slime1[3] = Slime[1];
        }

        if (Slime2[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Slime2[i] = Slime2[i + 1];
            }
            Slime2[3] = Slime[2];
        }
        else
        {
            Slime2[3] = Slime[2];
        }
        if (Slime3[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Slime3[i] = Slime3[i + 1];
            }
            Slime3[3] = Slime[3];
        }
        else
        {
            Slime3[3] = Slime[3];
        }
        if (Slime4[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Slime4[i] = Slime4[i + 1];
            }
            Slime4[3] = Slime[4];
        }
        else
        {
            Slime4[3] = Slime[4];
        }
        if (Slime5[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Slime5[i] = Slime5[i + 1];
            }
            Slime5[3] = Slime[5];
        }
        else
        {
            Slime5[3] = Slime[5];
        }
        if (Slime6[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Slime6[i] = Slime6[i + 1];
            }
            Slime6[3] = Slime[6];
        }
        else
        {
            Slime6[3] = Slime[6];
        }
        if (TwinSlime[3] != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                TwinSlime[i] = TwinSlime[i + 1];
            }
            TwinSlime[3] = Slime[7];
        }
        else
        {
            TwinSlime[3] = Slime[7];
        }
        for (int i = 0; i < Slime.Length; i++)
        {
            Slime[i] = 0;
        }
    }
}
