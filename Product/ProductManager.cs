using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProductManager : MonoBehaviour {
    public static ProductManager S;
    public Shop shop;
    public Text drugsText;
    public Text iceText;
    public Text glassText;
    public Text fuelText;

    public Text drugsNameText;
    public Text iceNameText;
    public Text glassNameText;
    public Text fuelNameText;

    public Text T_drugsPrice;
    public Text T_icePrice;
    public Text T_glassPrice;
    public Text T_fuelPrice;

    public Sprite[] drugsImages;
    public Sprite[] iceImages;
    public Sprite[] glassImages;
    public Sprite[] fuelImages;

    public Image drugsImage;
    public Image iceImage;
    public Image glassImage;
    public Image fuelImage;

    public float ChangePriceNum;

    private int drugs;//약품갯수
    private int ice;//얼음갯수
    private int glass;//유리갯수
    private int fuel;//연료갯수

    private int baseDrugPrice;//약품기본가격
    private int baseIcePrice;//얼음기본가격
    private int baseGlassPrice;//유리기본가격
    private int baseFuelPrice;//연료기본가격

    public int drugPrice;//약품가격
    public int icePrice;//얼음가격
    public int glassPrice;//유리가격
    public int fuelPrice;//연료가격

    private string drugsName;
    private string iceName;
    private string glassName;
    private string fuelName;

    private int drugSeasonPrice;
    private int iceSeasonPrice;
    private int glassSeasonPrice;
    private int fuelSeasonPrice;



    // Use this for initialization
    void Awake () {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    void Start()
    {
        UpgradeProductSet();
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                ChangeAllPrice();
                break;
            case DifficultManager.GameDifficult.easy:
                ChangeAllPrice();
                break;
            case DifficultManager.GameDifficult.normal:
                ChangeAllPrice(-10.0f);
                break;
            case DifficultManager.GameDifficult.hard:
                ChangeAllPrice(-15.0f);
                break;
            case DifficultManager.GameDifficult.endless:
                ChangeAllPrice(-10.0f);
                break;
            default:
                break;
        }


    }
    // Update is called once per frame
    void Update () {
       
    }
    //상품판매
    public void SellDrugs(SellLine sellLine)//비료판매
    {
        if(drugs>=1)
        {
            if(LocationManager.S.GetLocation()==LocationManager.Location.Shop)
            {
                SoundManager.S.PlaySE("판매");
            }
           
            drugs -= 1;
            CompanyValue.S.SetProductVaule();
            drugsText.text = "보유:"+drugs;
            MoneyManager.S.GetMoney(drugPrice);
            sellLine.DecreaseCustomer();
            sellLine.SellStaffAnimation(true);
            sellLine.makeCustomer.StartCoroutine("MoveCustomer");
            if(Scenario.S.scenarioMaxNum==6)
            {
                Scenario.S.scenario6_sellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum==18)
            {
                Scenario.S.E_scenario18_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum==3)
            {
                Scenario.S.N_scenario3_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 7)
            {
                Scenario.S.N_scenario7_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 1)
            {
                Scenario.S.H_scenario1_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 9)
            {
                Scenario.S.H_scenario9_Sellnum += 1;
            }

        }
        else
        {
            sellLine.SellStaffAnimation(false);
            shop.VariationFame(-1);
        }
        
    }
    public void SellIce(SellLine sellLine)//슬라임슬러쉬판매
    {

        if (ice>=1)
        {
            if (LocationManager.S.GetLocation() == LocationManager.Location.Shop)
            {
                SoundManager.S.PlaySE("판매");
            }
            ice -= 1;
            CompanyValue.S.SetProductVaule();
            iceText.text = "보유:" + ice;
            MoneyManager.S.GetMoney(icePrice);
            sellLine.DecreaseCustomer();
            sellLine.SellStaffAnimation(true);
            sellLine.makeCustomer.StartCoroutine("MoveCustomer");
            if (Scenario.S.scenarioMaxNum == 6)
            {
                Scenario.S.scenario6_sellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 18)
            {
                Scenario.S.E_scenario18_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 3)
            {
                Scenario.S.N_scenario3_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 7)
            {
                Scenario.S.N_scenario7_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 1)
            {
                Scenario.S.H_scenario1_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 9)
            {
                Scenario.S.H_scenario9_Sellnum += 1;
            }
        }
        else
        {
            sellLine.SellStaffAnimation(false);
            shop.VariationFame(-1);

        }

    }
    public void SellGlass(SellLine sellLine)//우윳잔판매
    {

        if(glass>=1)
        {
            if (LocationManager.S.GetLocation() == LocationManager.Location.Shop)
            {
                SoundManager.S.PlaySE("판매");
            }
            glass -= 1;
            glassText.text = "보유:" + glass;
            CompanyValue.S.SetProductVaule();
            MoneyManager.S.GetMoney(glassPrice);
            sellLine.DecreaseCustomer();
            sellLine.SellStaffAnimation(true);
            sellLine.makeCustomer.StartCoroutine("MoveCustomer");
            if (Scenario.S.scenarioMaxNum == 6)
            {
                Scenario.S.scenario6_sellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 18)
            {
                Scenario.S.E_scenario18_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 3)
            {
                Scenario.S.N_scenario3_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 7)
            {
                Scenario.S.N_scenario7_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 1)
            {
                Scenario.S.H_scenario1_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 9)
            {
                Scenario.S.H_scenario9_Sellnum += 1;
            }
        }
        else
        {
            sellLine.SellStaffAnimation(false);
            shop.VariationFame(-1);
        }

    }
    public void SellFuel(SellLine sellLine)//젤라틴판매
    {
        if(fuel>=1)
        {
            if (LocationManager.S.GetLocation() == LocationManager.Location.Shop)
            {
                SoundManager.S.PlaySE("판매");
            }
            fuel -= 1;
            fuelText.text = "보유:" + fuel;
            CompanyValue.S.SetProductVaule();
            MoneyManager.S.GetMoney(fuelPrice);
            sellLine.DecreaseCustomer();
            sellLine.SellStaffAnimation(true);
            sellLine.makeCustomer.StartCoroutine("MoveCustomer");
            if (Scenario.S.scenarioMaxNum == 6)
            {
                Scenario.S.scenario6_sellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 18)
            {
                Scenario.S.E_scenario18_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 3)
            {
                Scenario.S.N_scenario3_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 7)
            {
                Scenario.S.N_scenario7_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 1)
            {
                Scenario.S.H_scenario1_SellNum += 1;
            }
            if (Scenario.S.scenarioMaxNum == 9)
            {
                Scenario.S.H_scenario9_Sellnum += 1;
            }
        }
        else
        {
            sellLine.SellStaffAnimation(false);
            shop.VariationFame(-1);
        }

    }
    //상품 가격 변경

    public void ChangeAllPrice(float _num = 0)
    {
        SeasonPrice(DayManager.S.season);
        drugPrice = baseDrugPrice;
        icePrice = baseIcePrice;
        glassPrice = baseGlassPrice;
        fuelPrice = baseFuelPrice;

        ChangePriceNum += _num;
        float AllChangePriceNum = ChangePriceNum + FamePriceNum();
        drugPrice+= (baseDrugPrice * (int)AllChangePriceNum) /100;
        icePrice += (baseIcePrice * (int)AllChangePriceNum) / 100;
        glassPrice += (baseGlassPrice * (int)AllChangePriceNum) / 100;
        fuelPrice += (baseFuelPrice * (int)AllChangePriceNum) / 100;

        drugPrice += drugPrice * drugSeasonPrice / 100;
        icePrice += icePrice * iceSeasonPrice / 100;
        glassPrice += glassPrice * glassSeasonPrice / 100;
        fuelPrice += fuelPrice * fuelSeasonPrice / 100;

        T_drugsPrice.text = "가격:" + drugPrice.ToString();
        T_icePrice.text = "가격:" + icePrice.ToString();
        T_glassPrice.text = "가격:" + glassPrice.ToString();
        T_fuelPrice.text = "가격:" + fuelPrice.ToString();
    }
    public void ChangeFertilizerPrice()//비료가격변경
    {

    }
    public void ChangeSluushiePrice()//슬러쉬가격변경
    {

    }
    public void ChangeMilkCupPrice()//우윳잔가격변경
    {

    }
    public void ChangeGelatinPrice()//젤라틴가격변경
    {

    }

    public void GetDrugs(int num)
    {

        drugs += num;
        drugsText.text = "보유:" + drugs;
        Archive.S.PlusProductStack(num, 0, 0, 0);
        CompanyValue.S.SetProductVaule(num,false);
    }

    public void GetIce(int num)
    {
        ice += num;
        iceText.text = "보유:" + ice;
        Archive.S.PlusProductStack(0, num, 0, 0);
        CompanyValue.S.SetProductVaule(num, false);
    }
    public void GetGlass(int num)
    {
        glass += num;
        glassText.text = "보유:" + glass;
        Archive.S.PlusProductStack(0, 0, num, 0);
        CompanyValue.S.SetProductVaule(num, false);
    }
    public void GetFuel(int num)
    {
        fuel += num;
        fuelText.text = "보유:" + fuel;
        Archive.S.PlusProductStack(0, 0, 0, num);
        CompanyValue.S.SetProductVaule(num, false);
    }

    public void UpgradeProductSet()
    {
        
        switch (FactoryUpgrade.S.ProductQualityUpTier)
        {
            case 0:
                baseDrugPrice = 80;
                baseIcePrice = 80;
                baseGlassPrice = 90;
                baseFuelPrice = 80;
                drugsName="약초";
                iceName="슬라임 젤리";
                glassName="실리콘";
                fuelName="슬라임탄";
                drugsImage.sprite = drugsImages[0];
                iceImage.sprite = iceImages[0];
                glassImage.sprite = glassImages[0];
                fuelImage.sprite = fuelImages[0];
                break;
            case 1:
                baseDrugPrice = 140;
                baseIcePrice = 140;
                baseGlassPrice = 160;
                baseFuelPrice = 140;
                drugsName = "물약";
                iceName = "슬라임 음료";
                glassName = "유리잔";
                fuelName = "슬라임 유";
                drugsImage.sprite = drugsImages[1];
                iceImage.sprite = iceImages[1];
                glassImage.sprite = glassImages[1];
                fuelImage.sprite = fuelImages[1];
                break;
            case 2:
                baseDrugPrice = 225;
                baseIcePrice = 225;
                baseGlassPrice = 255;
                baseFuelPrice = 225;
                drugsName = "소독약";
                iceName = "슬라임 슬러시";
                glassName = "유리 창문";
                fuelName = "슬라임 가스";
                drugsImage.sprite = drugsImages[2];
                iceImage.sprite = iceImages[2];
                glassImage.sprite = glassImages[2];
                fuelImage.sprite = fuelImages[2];
                break;
            case 3:
                baseDrugPrice = 350;
                baseIcePrice = 350;
                baseGlassPrice = 400;
                baseFuelPrice = 350;
                drugsName = "농약";
                iceName = "슬라임 아이스크림";
                glassName = "정밀 렌즈";
                fuelName = "슬라임 전지";
                drugsImage.sprite = drugsImages[3];
                iceImage.sprite = iceImages[3];
                glassImage.sprite = glassImages[3];
                fuelImage.sprite = fuelImages[3];
                break;
            case 4:
                baseDrugPrice = 500;
                baseIcePrice = 500;
                baseGlassPrice = 560;
                baseFuelPrice = 500;
                drugsName = "멸균제";
                iceName = "슬라임 아이스";
                glassName = "슬라임 석영";
                fuelName = "슬라늄";
                drugsImage.sprite = drugsImages[4];
                iceImage.sprite = iceImages[4];
                glassImage.sprite = glassImages[4];
                fuelImage.sprite = fuelImages[4];
                break;
            default:
                break;
        }
        drugsNameText.text = drugsName;
        iceNameText.text = iceName;
        glassNameText.text = glassName;
        fuelNameText.text = fuelName;
        ChangeAllPrice();
        

    }
    public void UpgradePenalty()
    {
        drugs-=(drugs/ 2);
        drugsText.text = "보유:" + drugs;
        ice-=(ice / 2);
        iceText.text = "보유:" + ice;
        glass -=(glass / 2);
        glassText.text = "보유:" + glass;
        fuel -=(fuel / 2);
        fuelText.text = "보유:" + fuel;
    }
    public void SeasonPrice(DayManager.Season _season)
    {
        switch (_season)
        {
            case DayManager.Season.Spring:
                 drugSeasonPrice=20;
                 iceSeasonPrice=-25;
                 glassSeasonPrice=-10;
                 fuelSeasonPrice=-15;
                break;
            case DayManager.Season.Summer:
                drugSeasonPrice = 0;
                iceSeasonPrice = 50;
                glassSeasonPrice = 0;
                fuelSeasonPrice = -50;
                break;
            case DayManager.Season.Fall:
                drugSeasonPrice = -40;
                iceSeasonPrice = -25;
                glassSeasonPrice = 10;
                fuelSeasonPrice = -15;
                break;
            case DayManager.Season.Winter:
                drugSeasonPrice = 0;
                iceSeasonPrice = -65;
                glassSeasonPrice = 0;
                fuelSeasonPrice = 35;
                break;
            default:
                break;
        }
    }
    public int DrugNum()
    {
        return drugs;
    }
    public int IceNum()
    {
        return ice;
    }
    public int GlassNum()
    {
        return glass;
    }
    public int FuelNum()
    {
        return fuel;
    }

    public void SetProductNum(int _drug,int _ice,int _glass,int _fuel)
    {
        drugs = _drug;
        drugsText.text = "보유:" + drugs;
        ice = _ice;
        iceText.text = "보유:" + ice;
        glass = _glass;
        glassText.text = "보유:" + glass;
        fuel = _fuel;
        fuelText.text = "보유:" + fuel;
    }
    public Sprite DrugImage()
    {
        return drugsImage.sprite;
    }
    public Sprite IceImage()
    {
        return iceImage.sprite;
    }
    public Sprite GlassImage()
    {
        return glassImage.sprite;
    }
    public Sprite FuelImage()
    {
        return fuelImage.sprite;
    }
    public float FamePriceNum()
    {
       
        return ((int)Shop.S.fame / (100-(10*ShopUpgrade.S.ShopAdvertisingTier))) * (2.5f+(0.5f*ShopUpgrade.S.InteriorReformationTier));
    }
}
