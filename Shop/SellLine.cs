using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SellLine : MonoBehaviour {
    public enum ItemKind
    {
        none,
        Drugs,
        Ice,
        Glass,
        Fuel
    }
    
    public GameObject SellItemUI;
    public GameObject[] ChangeProducts;
    public Text T_itemKind;
    public Text T_itemPrice;
    public Text T_itemRemainNum;
    public Text T_remainConsumer;
    public float consumerTime;
    public int consumer;//손님
    public int MaxConsumer;//손님 최대수
    public float sellTime;
    private bool sellItemUIOn;
    public bool shopOpen;
    public int sellProductOn;
    public Shop shop;
    public ItemKind itemKind;
    public Customer makeCustomer;

    public GameObject sellItemImage;

    public Image drugImage;
    public Image iceImage;
    public Image glassImage;
    public Image fuelImage;
    [SerializeField]
    private Staff staff;
	// Use this for initialization
	void Start () {
        sellItemUIOn = false;
        itemKind = ItemKind.none;
        MaxConsumer = 12;
        makeCustomer = gameObject.GetComponent<Customer>();
    }
	
	// Update is called once per frame
	void Update () {
            if (SellItemUI.activeInHierarchy && LocationManager.openUI == false)
            {
                LocationManager.openUI = true;
            }
            SellItem();
        
        SellLineUIUpdate();
        if (consumer>0&&!staff.GetStaffOn())
        {
            if (consumer >= 3)
            {
                shop.VariationFame(-60-(15*(consumer-3)));
            }
            consumer = 0;
            consumerTime = 0;
            makeCustomer.RemoveCustomer();
            
        }
        
    }
    private void LateUpdate()
    {

        NewCustomer();
        
    }
    void OnMouseUpAsButton()
    {
        if (LocationManager.openUI == false && sellItemUIOn == false && !EventSystem.current.IsPointerOverGameObject())
        {
            SellItemUI.SetActive(true);
            SoundManager.S.PlaySE("닫기");
        }
    }
    void SellItem()
    {
        if(staff.GetStaffOn()&&consumer > 0)
        {
                sellTime += 1 * Time.deltaTime;
            if (sellTime >= 1.0f)
            {
                switch (itemKind)
                {
                    case ItemKind.none:
                        break;
                    case ItemKind.Drugs:
                        ProductManager.S.SellDrugs(this);
                        break;
                    case ItemKind.Ice:
                        ProductManager.S.SellIce(this);
                        break;
                    case ItemKind.Glass:
                        ProductManager.S.SellGlass(this);
                        break;
                    case ItemKind.Fuel:
                        ProductManager.S.SellFuel(this);
                        break;
                }
                
                sellTime = 0.0f;
            }
        }
    }
    public void SellProductChange(int _num)//1=약품 2=얼음 3=유리,4=연료 0=판매중지
    {
        switch (_num)
        {
            case 0:
                if (itemKind != ItemKind.none)
                {
                    ChangeProducts[_num].SetActive(true);
                }
                break;
            case 1:
                if(itemKind==ItemKind.none)
                {
                    SellDrugs();

                }
                else if(itemKind!=ItemKind.Drugs)
                {
                    ChangeProducts[_num].SetActive(true);
                }
                break;
            case 2:
                if (itemKind == ItemKind.none)
                {
                    SellIce();

                }
                else if (itemKind != ItemKind.Ice)
                {
                    ChangeProducts[_num].SetActive(true);
                }
                break;
            case 3:
                if (itemKind == ItemKind.none)
                {
                    SellGlass();

                }
                else if (itemKind != ItemKind.Glass)
                {
                    ChangeProducts[_num].SetActive(true);
                }
                break;
            case 4:
                if (itemKind == ItemKind.none)
                {
                    SellFuel();

                }
                else if (itemKind != ItemKind.Fuel)
                {
                    ChangeProducts[_num].SetActive(true);
                }
                break;
            
                
            default:
                break;
        }
    }
    public void SellDrugs()
    {
        itemKind = ItemKind.Drugs;
        sellItemImage.SetActive(true);
        sellItemImage.GetComponent<SpriteRenderer>().sprite = drugImage.sprite;
        if (consumer>=3)
        {
            shop.VariationFame(-5*consumer);
        }
        consumer = 0;
        consumerTime = 0;
        makeCustomer.RemoveCustomer();
        T_itemKind.text = "판매중인 상품:약품";
        
    }
    public void SellIce()
    {
        itemKind = ItemKind.Ice;
        sellItemImage.SetActive(true);
        sellItemImage.GetComponent<SpriteRenderer>().sprite = iceImage.sprite;
        if (consumer >= 3)
        {
            shop.VariationFame(-5 * consumer);
        }
        consumer = 0;
        consumerTime = 0;
        makeCustomer.RemoveCustomer();
        T_itemKind.text = "판매중인 상품:얼음제품";
    }
    public void SellGlass()
    {
        itemKind = ItemKind.Glass;
        sellItemImage.SetActive(true);
        sellItemImage.GetComponent<SpriteRenderer>().sprite = glassImage.sprite;
        if (consumer >= 3)
        {
            shop.VariationFame(-5 * consumer);
        }
        consumer = 0;
        consumerTime = 0;
        makeCustomer.RemoveCustomer();
        T_itemKind.text = "판매중인 상품:유리제품";
    }
    public void SellFuel()
    {
        itemKind = ItemKind.Fuel;
        sellItemImage.SetActive(true);
        sellItemImage.GetComponent<SpriteRenderer>().sprite = fuelImage.sprite;
        if (consumer >= 3)
        {
            shop.VariationFame(-5 * consumer);
        }
        consumer = 0;
        consumerTime = 0;
        makeCustomer.RemoveCustomer();
        T_itemKind.text = "판매중인 상품:연료제품";
    }
    public void SellNone()
    {
        itemKind = ItemKind.none;
        sellItemImage.SetActive(false);
        if (consumer >= 3)
        {
            shop.VariationFame(-5 * consumer);
        }
        consumer = 0;
        consumerTime = 0;
        makeCustomer.RemoveCustomer();
        T_itemKind.text = "판매중인 상품:없음";
    }

    public void NewCustomer()
    {
        if (staff.GetStaffOn())
        {
            shopOpen = true;
            
        }
        else shopOpen = false;
        
        if (shopOpen&&itemKind!=ItemKind.none)
        {
            sellProductOn = 1;
            shop.SetNewCustomerTime();
            if(shop.newCustomerTime<100)
            {
                consumerTime += 1f * Time.deltaTime;
            }
            
            if (consumerTime > shop.newCustomerTime&& consumer < MaxConsumer)
            {
                consumer += 1;
                consumerTime = 0;
                makeCustomer.NewCustomer();

            }
            else if (consumerTime > shop.newCustomerTime && consumer == MaxConsumer)
            {
                GeneralMeeting.S.ConsumerGroupDIVariation(2);
                shop.VariationFame(-4);
                consumerTime = 0;
            }

        }
        else
        {
            sellProductOn = 0;
        }
        


    }
    public void DecreaseCustomer()
    {
        consumer-= 1;
        shop.pastMonthCustomer -= 1;
        DayManager.S.ShopActive();
    }
    public void SellLineUIUpdate()
    {
        if (itemKind == ItemKind.none)
        {
            T_itemKind.text = "판매중인 상품:없음";
        }
        T_itemPrice.text = "약품:" + ProductManager.S.drugPrice + "원\n" +
            "얼음제품" + ProductManager.S.icePrice + "원\n" +
            "유리제품" + ProductManager.S.glassPrice + "원\n" +
            "연료제품" + ProductManager.S.fuelPrice + "원\n";
        T_itemRemainNum.text = "약품:" + ProductManager.S.DrugNum() + "개\n" +
            "얼음제품" + ProductManager.S.IceNum() + "개\n" +
            "유리제품" + ProductManager.S.GlassNum() + "개\n" +
            "연료제품" + ProductManager.S.FuelNum() + "개\n";
        T_remainConsumer.text = "대기 손님:" + consumer.ToString() + "명";
    }

    public bool ShopOpen()
    {
        return shopOpen;
    }
    public Staff GetStaff()
    {
        return staff;
    }
    public void ProductImageChange()
    {
        drugImage.sprite = ProductManager.S.DrugImage();
        iceImage.sprite = ProductManager.S.IceImage();
        glassImage.sprite = ProductManager.S.GlassImage();
        fuelImage.sprite = ProductManager.S.FuelImage();
        SellItemImageUpdate();
    }
    public void SellStaffAnimation(bool onOff)
    {
        if(onOff)
        {
            staff.anim.SetBool("IsSell", true);
        }
        else
        {
            staff.anim.SetBool("IsSell", false);
        }
        
    }
    public int GetSellItemKind()
    {
        switch (itemKind)
        {
            case ItemKind.none:
                return 0;
            case ItemKind.Drugs:
                return 1;
            case ItemKind.Ice:
                return 2;
            case ItemKind.Glass:
                return 3;
            case ItemKind.Fuel:
                return 4;
            default:
                return 0;
        }
    }

    public void SetSellItemKind(int _num)
    {
        switch (_num)
        {
            case 0:
                itemKind = ItemKind.none;
                T_itemKind.text = "판매중인 상품:없음";
                sellItemImage.SetActive(false);
                break;
            case 1:
                itemKind = ItemKind.Drugs;
                T_itemKind.text = "판매중인 상품:약품";
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = drugImage.sprite;
                break;
            case 2:
                itemKind = ItemKind.Ice;
                T_itemKind.text = "판매중인 상품:얼음제품";
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = iceImage.sprite;
                break;
            case 3:
                itemKind = ItemKind.Glass;
                T_itemKind.text = "판매중인 상품:유리제품";
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = glassImage.sprite;
                break;
            case 4:
                itemKind = ItemKind.Fuel;
                T_itemKind.text = "판매중인 상품:연료제품";
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = fuelImage.sprite;
                break;
            default:
                itemKind = ItemKind.none;
                T_itemKind.text = "판매중인 상품:없음";
                sellItemImage.SetActive(false);
                break;
        }
    }

    public void SellItemImageUpdate()
    {
        switch (itemKind)
        {
            case ItemKind.none:
                sellItemImage.SetActive(false);
                return;
            case ItemKind.Drugs:
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = drugImage.sprite;
                return ;
            case ItemKind.Ice:
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = iceImage.sprite;
                return ;
            case ItemKind.Glass:
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = glassImage.sprite;
                return ;
            case ItemKind.Fuel:
                sellItemImage.SetActive(true);
                sellItemImage.GetComponent<SpriteRenderer>().sprite = fuelImage.sprite;
                return ;
            default:
                return ;
        }
    }
    public void LoadSellLine(int _consumer,float _sellTime, int _sellKind)
    {
            consumer = _consumer;
            sellTime = _sellTime;
            SetSellItemKind(_sellKind);
            makeCustomer.RemoveCustomer();
            for (int i = 0; i < consumer; i++)
            {
                makeCustomer.NewCustomer();
            }
        ProductImageChange();
    }
}
