using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InsertSlime : MonoBehaviour {
    //public float remainItemNum;
    //public float makeTime;
    //public float remainTime;
    public Item item;
    public Inventory inven;
    public GameObject T_RemainTime;
    public GameObject StaffRequire;
    public Staff produceStaff;
    public Staff packingStaff;
    public CreateCancel createCancel;
    public Image drugImage;
    public Image iceImage;
    public Image glassImage;
    public Image fuelImage;

    public Sprite[] sprites;

    public Image ProductImage;
    public Text ProductText;
    // 새로운 제작방식

    public GameObject insertSlimeUI;
    public GameObject selectTypeFirst;
    public GameObject event11_Image;
    public GameObject ProductChangeWarningUI1;
    public GameObject ProductChangeWarningUI2;
    public GameObject ProductChangeWarningUI3;
    public GameObject ProductChangeWarningUI4;
    public GameObject LineGO;
    public enum MakeProductType
    {
        None,
        Drugs,
        Ice,
        Glass,
        Fuel
    }
    public bool isCreateLineUse;
    public int itemStack;
    public float moveItemStackSetTime;
    public float moveItemStackTime;
    public int movePackageLineNum;//한번에 포장라인으로 넘기는 갯수
    public MakeProductType productType;
    public Text T_itemStack;
    public Text T_itemType;
    public Text T_itemCreateText;

    //포장라인
    public Text T_PackageItemStack;
    public Text T_itemPackageText;
    public Text T_isPackageOn;
    public Text T_materialRequireNum;
    public bool isPackageLineUse;
    public int packageItemStack;
    public float packageSetTime;
    public float packageTime;
    public int packageItemNum;
    public int packageItemStackSpend;
    public MakeProductType packageProductType;



    public bool isCreating;
    public bool isPacking;
    // Use this for initialization
    void Start () {
        
        movePackageLineNum = 10;
        moveItemStackSetTime = 5f;
        moveItemStackTime = moveItemStackSetTime;
        packageSetTime = 1.5f;
        packageTime = packageSetTime;
        packageItemNum = 2;
        ProductImageChange();
        switch (productType)
        {
            case MakeProductType.None:
                T_itemType.text = "생산물품:없음";
                break;
            case MakeProductType.Drugs:
                T_itemType.text = "생산물품:약품";
                break;
            case MakeProductType.Ice:
                T_itemType.text = "생산물품:얼음";
                break;
            case MakeProductType.Glass:
                T_itemType.text = "생산물품:유리";
                break;
            case MakeProductType.Fuel:
                T_itemType.text = "생산물품:연료";
                break;
            default:
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
        CheckScenario3();
        if (insertSlimeUI.activeInHierarchy&&LocationManager.openUI==false)
        {
            LocationManager.openUI = true;
        }
        UpgradeSet();
        T_itemStack.text = "원료:" + itemStack.ToString();
        T_itemCreateText.text = ((int)moveItemStackSetTime).ToString() + "초당" + movePackageLineNum.ToString() + "개 원료 소모";
        T_materialRequireNum.text = "원료" + (FactoryUpgrade.S.ProductQualityUpTier + 1).ToString() + "개당 상품 하나 생산";
        if (packingStaff.GetStaffOn())
        {
            T_isPackageOn.text = "포장이 진행중입니다";
        }
        else
        {
            T_isPackageOn.text = "직원이 없습니다";
        }

        T_itemPackageText.text = ((int)packageSetTime).ToString() + "초당" + packageItemNum.ToString() + "개만큼 포장";
        T_PackageItemStack.text = "남은 상품 갯수"+packageItemStack.ToString();
        if(packageProductType==MakeProductType.None)
        {
            ProductText.gameObject.SetActive(true);
        }
        else
        {
            ProductText.gameObject.SetActive(false);
        }
        MoveItemStack();
        ChangeProductType();
        PackageProduct();
       
    }

    private void OnMouseUpAsButton()
    {
        if (!LocationManager.openUI &&!EventSystem.current.IsPointerOverGameObject())
        {
            SoundManager.S.PlaySE("닫기");
            insertSlimeUI.SetActive(true);
            LocationManager.openUI = true;
        }
        //else if(!LocationManager.openUI && item != null && !EventSystem.current.IsPointerOverGameObject())
        //{
        //    createCancel.CancelUIOn(this);
        //}
    }

    public void ChangeProductWarning(int _productNum)
    {
        MakeProductType ChangeProductType;
        ChangeProductType = MakeProductType.None;
        switch (_productNum)
        {
            case 1:
                ChangeProductType = MakeProductType.Drugs;
                break;
            case 2:
                ChangeProductType = MakeProductType.Ice;
                break;
            case 3:
                ChangeProductType = MakeProductType.Glass;
                break;
            case 4:
                ChangeProductType = MakeProductType.Fuel;
                break;
            default:
                break;
        }
        if (productType == MakeProductType.None)
        {
            ChangeProduct(_productNum);
        }
        else if(productType== ChangeProductType)
        {
            return;
        }
        else
        {
            if (!(ProductChangeWarningUI1.activeInHierarchy||
                ProductChangeWarningUI2.activeInHierarchy||
                ProductChangeWarningUI3.activeInHierarchy||
                ProductChangeWarningUI4.activeInHierarchy))
            {
                ProductChangeWarningUIOn(_productNum);
            }
            
        }
        
    }
    public void ProductChangeWarningUIOn(int _productNum)
    {
        SoundManager.S.PlaySE("터치");
        switch (_productNum)
        {
            case 1:
                ProductChangeWarningUI1.SetActive(true);
                break;
            case 2:
                ProductChangeWarningUI2.SetActive(true);
                break;
            case 3:
                ProductChangeWarningUI3.SetActive(true);
                break;
            case 4:
                ProductChangeWarningUI4.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void ChangeProduct(int _productNum)
    {
        SoundManager.S.PlaySE("닫기2");
        if (_productNum!=0)
        {
            itemStack = 0;

        }
        switch (_productNum)
        {
            case 0:
                productType = MakeProductType.None;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_productNum];
                break;
            case 1:
                productType = MakeProductType.Drugs;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_productNum];
                break;
            case 2:
                productType = MakeProductType.Ice;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_productNum];
                break;
            case 3:
                productType = MakeProductType.Glass;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_productNum];
                break;
            case 4:
                productType = MakeProductType.Fuel;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_productNum];
                break;
            default:
                break;
        }
        switch (productType)
        {
            case MakeProductType.None:
                T_itemType.text = "생산물품:없음";
                break;
            case MakeProductType.Drugs:
                T_itemType.text = "생산물품:약품";
                break;
            case MakeProductType.Ice:
                T_itemType.text = "생산물품:얼음";
                break;
            case MakeProductType.Glass:
                T_itemType.text = "생산물품:유리";
                break;
            case MakeProductType.Fuel:
                T_itemType.text = "생산물품:연료";
                break;
            default:
                break;
        }
        ProductChangeWarningUI1.SetActive(false);
        ProductChangeWarningUI2.SetActive(false);
        ProductChangeWarningUI3.SetActive(false);
        ProductChangeWarningUI4.SetActive(false);
    }

    public void SelectSlime()
    {
        if(!produceStaff.GetStaffOn())
        {
            SoundManager.S.PlaySE("닫기");
            StaffRequire.SetActive(true);
        }
        else if(productType==MakeProductType.None)
        {
            SoundManager.S.PlaySE("닫기");
            selectTypeFirst.SetActive(true);
        }
        else
        {
            insertSlimeUI.SetActive(false);
            SelectItemUI.S.SlectSlimeUI(this);
        }


    }
    public void PutSlime(Item _item, int _itemNum)
    {
        int difficultValue=100;
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                difficultValue = 100;
                break;
            case DifficultManager.GameDifficult.normal:
                difficultValue = 85;
                break;
            case DifficultManager.GameDifficult.hard:
                difficultValue = 60;
                break;
            case DifficultManager.GameDifficult.endless:
                difficultValue = 85;
                break;
            default:
                break;
        }
        CompanyValue.S.SetItemValue(_item,_itemNum,true);
        isCreateLineUse = true;
        item = _item;
        if (item.itemName == "회색 슬라임")
        {
            GeneralMeeting.S.UseGraySlime(_itemNum);
        }
        if (item.itemName == "킹 슬라임")
        {
            GeneralMeeting.S.UseKingSlime(_itemNum);
        }
        switch (productType)
        {
            case MakeProductType.None:
                break;
            case MakeProductType.Drugs:
                for (int i = 0; i < _itemNum; i++)
                {
                    itemStack += (item.MakeDrugs()*difficultValue)/100;
                }
                break;
            case MakeProductType.Ice:
                for (int i = 0; i < _itemNum; i++)
                {
                    itemStack += (item.MakeIce() * difficultValue) / 100;
                }
                break;
            case MakeProductType.Glass:
                for (int i = 0; i < _itemNum; i++)
                {
                    itemStack += (item.MakeGlass() * difficultValue) / 100;
                }
                break;
            case MakeProductType.Fuel:
                for (int i = 0; i < _itemNum; i++)
                {
                    itemStack += (item.MakeFuel() * difficultValue) / 100;
                }
                break;
            default:
                break;
        }
        item = null;
    }
    public void UpgradePenalty()
    {
        packageItemStack -= (packageItemStack) / 2;
    }
    public void MoveItemStack()
    {
        if(produceStaff.GetStaffOn()&&packageProductType==productType&& itemStack> (FactoryUpgrade.S.ProductQualityUpTier + 1))
        {
            moveItemStackTime -= 1 * Time.deltaTime;
            produceStaff.anim.SetBool("IsCreate", true);
            LineGO.GetComponent<Animator>().SetBool("Active", true);
            isCreating = true;
            if (moveItemStackTime <= 0)
            {
                DayManager.S.FactoryActive();
                if(itemStack <= movePackageLineNum)
                {
                    packageItemStack += itemStack/(FactoryUpgrade.S.ProductQualityUpTier+1);
                    itemStack %= (FactoryUpgrade.S.ProductQualityUpTier + 1);

                    string productName="";
                    switch (productType)
                    {
                        case MakeProductType.None:
                            break;
                        case MakeProductType.Drugs:
                            productName = "약품";
                            break;
                        case MakeProductType.Ice:
                            productName = "얼음제품";
                            break;
                        case MakeProductType.Glass:
                            productName = "유리제품";
                            break;
                        case MakeProductType.Fuel:
                            productName = "연료";
                            break;
                        default:
                            break;
                    }
                    LocationManager.S.FactoryAlarmOn();
                    Message.S.AddMessage("공장의 "+productName.ToString()+ "생산이 끝났습니다",Message.MessageType.factory);
                }
                else
                {
                    packageItemStack += movePackageLineNum / (FactoryUpgrade.S.ProductQualityUpTier + 1);
                    itemStack -= movePackageLineNum;
                    itemStack += movePackageLineNum % (FactoryUpgrade.S.ProductQualityUpTier + 1);


                }
                moveItemStackTime = moveItemStackSetTime;
            }

        }
        else
        {
            moveItemStackTime = moveItemStackSetTime;
            produceStaff.anim.SetBool("IsCreate", false);
            LineGO.GetComponent<Animator>().SetBool("Active", false);
            isCreating = false;
        }
        switch (packageProductType)
        {
            case MakeProductType.None:
                ProductImage.sprite = null;
                ProductImage.color = Color.gray;
                break;
            case MakeProductType.Drugs:
                ProductImage.sprite = ProductManager.S.DrugImage();
                ProductImage.color = Color.white;
                break;
            case MakeProductType.Ice:
                ProductImage.sprite = ProductManager.S.IceImage();
                ProductImage.color = Color.white;
                break;
            case MakeProductType.Glass:
                ProductImage.sprite = ProductManager.S.GlassImage();
                ProductImage.color = Color.white;
                break;
            case MakeProductType.Fuel:
                ProductImage.sprite = ProductManager.S.FuelImage();
                ProductImage.color = Color.white;
                break;
            default:
                break;
        }

    }
    public void ChangeProductType()
    {
        if (productType != packageProductType && packageItemStack < FactoryUpgrade.S.ProductQualityUpTier + 1)
        {
            packageItemStack = 0;
            packageProductType = productType;
            
        }

    }
    public void PackageProduct()
    {
        
        if (packingStaff.GetStaffOn() && packageItemStack >= packageItemNum)
        {
            isPackageLineUse = true;
            packageTime -= 1 * Time.deltaTime;
            packingStaff.anim.SetBool("IsPackage", true);
            isPacking = true;
            if (packageTime < 0)
            {
                packageItemStack -= packageItemNum;
                packageTime = packageSetTime;
                if (Scenario.S.scenarioMaxNum == 4)
                {
                    Scenario.S.scenario4_createNum += packageItemNum;
                }
                switch (packageProductType)
                {
                    case MakeProductType.None:
                        break;
                    case MakeProductType.Drugs:
                        ProductImage.sprite = ProductManager.S.DrugImage();
                        ProductManager.S.GetDrugs(packageItemNum);
                        break;
                    case MakeProductType.Ice:
                        ProductImage.sprite = ProductManager.S.IceImage();
                        ProductManager.S.GetIce(packageItemNum);
                        if(Scenario.S.scenarioMaxNum == 8)
                        {
                            Scenario.S.E_scenario8_createNum += packageItemNum;
                        }
                        
                        break;
                    case MakeProductType.Glass:
                        ProductImage.sprite = ProductManager.S.GlassImage();
                        ProductManager.S.GetGlass(packageItemNum);
                        break;
                    case MakeProductType.Fuel:
                        ProductImage.sprite = ProductManager.S.FuelImage();
                        ProductManager.S.GetFuel(packageItemNum);
                        break;
                    default:
                        break;
                }
            }
        }
        else if(packingStaff.GetStaffOn() &&packageItemStack>0&& packageItemStack < packageItemNum)
        {
            packageTime -= 1 * Time.deltaTime;
            packingStaff.anim.SetBool("IsPackage", true);
            isPacking = true;
            if (packageTime < 0)
            {
                
                packageTime = packageSetTime;
                switch (packageProductType)
                {
                    case MakeProductType.None:
                        break;
                    case MakeProductType.Drugs:
                        ProductImage.sprite = ProductManager.S.DrugImage();
                        ProductManager.S.GetDrugs(packageItemStack);
                        break;
                    case MakeProductType.Ice:
                        ProductImage.sprite = ProductManager.S.IceImage();
                        ProductManager.S.GetIce(packageItemStack);
                        break;
                    case MakeProductType.Glass:
                        ProductImage.sprite = ProductManager.S.GlassImage();
                        ProductManager.S.GetGlass(packageItemStack);
                        break;
                    case MakeProductType.Fuel:
                        ProductImage.sprite = ProductManager.S.FuelImage();
                        ProductManager.S.GetFuel(packageItemStack);
                        break;
                    default:
                        break;
                }
                packageItemStack = 0;
            }
            
        }else if(packingStaff.GetStaffOn()  && packageItemStack ==0)
        {
            packingStaff.anim.SetBool("IsPackage", false);
            isPacking = false;
        }
    }

    public void UpgradeSet()
    {
        movePackageLineNum = (10 + 10 * FactoryUpgrade.S.MoreCreateTier);
        moveItemStackSetTime = 5f - 0.5f * FactoryUpgrade.S.CreateFasterTier;
        packageItemNum = 2 + 2 * FactoryUpgrade.S.MorePackageTier;
        packageSetTime = 1.5f - 0.12f * FactoryUpgrade.S.PackageFasterTier;

        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                break;
            case DifficultManager.GameDifficult.normal:
                moveItemStackSetTime += moveItemStackSetTime * 1.15f;
                packageSetTime += packageSetTime * 1.15f;
                break;
            case DifficultManager.GameDifficult.hard:
                moveItemStackSetTime += moveItemStackSetTime * 1.25f;
                packageSetTime += packageSetTime * 1.25f;
                break;
            case DifficultManager.GameDifficult.endless:
                moveItemStackSetTime += moveItemStackSetTime * 1.25f;
                packageSetTime += packageSetTime * 1.25f;
                break;
            default:
                break;
        }
    }
    public void ProductImageChange()
    {
        drugImage.sprite = ProductManager.S.DrugImage();
        iceImage.sprite = ProductManager.S.IceImage();
        glassImage.sprite = ProductManager.S.GlassImage();
        fuelImage.sprite = ProductManager.S.FuelImage();

    }
    public int GetCreateProductType()
    {
        switch (productType)
        {
            case MakeProductType.None:
                return 0;
            case MakeProductType.Drugs:
                return 1;
            case MakeProductType.Ice:
                return 2;
            case MakeProductType.Glass:
                return 3;
            case MakeProductType.Fuel:
                return 4;
            default:
                return 0;
        }
    }
    public int GetPackageProductType()
    {
        switch (packageProductType)
        {
            case MakeProductType.None:
                return 0;
            case MakeProductType.Drugs:
                return 1;
            case MakeProductType.Ice:
                return 2;
            case MakeProductType.Glass:
                return 3;
            case MakeProductType.Fuel:
                return 4;
            default:
                return 0;
        }
    }
    public void LoadCreateLine(int _createItemStack,float _createRemainTime,int createPT,
                                int _packageItemStack,float _packageReaminTime,int _packagePT)
    {
        itemStack = _createItemStack;
        moveItemStackTime = _createRemainTime;
        switch (createPT)
        {
            case 0:
                productType = MakeProductType.None;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[createPT];
                T_itemType.text = "생산물품:없음";
                break;
            case 1:
                productType = MakeProductType.Drugs;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[createPT];
                T_itemType.text = "생산물품:약품";
                break;
            case 2:
                productType = MakeProductType.Ice;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[createPT];
                T_itemType.text = "생산물품:얼음";
                break;
            case 3:
                productType = MakeProductType.Glass;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[createPT];
                T_itemType.text = "생산물품:유리";
                break;
            case 4:
                productType = MakeProductType.Fuel;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[createPT];
                T_itemType.text = "생산물품:연료";
                break;
            default:
                break;
        }
        packageItemStack = _packageItemStack;
        packageTime = _packageReaminTime;
        switch (_packagePT)
        {
            case 0:
                packageProductType = MakeProductType.None;
                ProductImage.sprite = null;
                ProductImage.color = Color.gray;
                break;
            case 1:
                packageProductType = MakeProductType.Drugs;
                ProductImage.sprite = ProductManager.S.DrugImage();
                ProductImage.color = Color.white;
                break;
            case 2:
                packageProductType = MakeProductType.Ice;
                ProductImage.sprite = ProductManager.S.IceImage();
                ProductImage.color = Color.white;
                break;
            case 3:
                packageProductType = MakeProductType.Glass;
                ProductImage.sprite = ProductManager.S.GlassImage();
                ProductImage.color = Color.white;
                break;
            case 4:
                packageProductType = MakeProductType.Fuel;
                ProductImage.sprite = ProductManager.S.FuelImage();
                ProductImage.color = Color.white;
                break;
            default:
                break;
        }
        ProductImageChange();
    }
    public bool CheckScenario3()
    {
        if (Scenario.S.scenarioMaxNum == 3)
        {
            if (produceStaff.GetStaffOn() && packingStaff.GetStaffOn())
            {
                Scenario.S.scenario3_Check = true;
            }
        }
        else if (Scenario.S.scenarioMaxNum == 5)
        {
            if (produceStaff.GetStaffOn() && packingStaff.GetStaffOn())
            {
                return true; ;
            }
            return false;
        }
        return false;
        
    }
}
