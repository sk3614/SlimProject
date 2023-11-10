using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemUI : MonoBehaviour {
    public static SelectItemUI S;
    public Inventory inven;
    public Slot[] itemSlots;
    public bool selectSlimeUiOn;
    public bool selectTrashUiOn;
    public bool selectProductUiOn;

    public Cell slimeFarm;

    public GameObject itemSlotsParent;
    public GameObject SelectUIBase;
    public GameObject selectNumUI;
    public GameObject selectNumUIBase;
    private InsertSlime insertSlime;
    private Cell cell;
    public int UseNum=1;
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
    // Use this for initialization
    void Start ()
    {
		itemSlots=itemSlotsParent.GetComponentsInChildren<Slot>();
        selectSlimeUiOn = false;
        selectTrashUiOn = false;
        selectProductUiOn = false;
}
	
	// Update is called once per frame
	void Update ()
    {
        if ((SelectUIBase.activeInHierarchy || selectNumUI.activeInHierarchy) && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }
    public void SlectSlimeUI(InsertSlime _insertLine)
    {
        SoundManager.S.PlaySE("닫기");
        insertSlime = _insertLine;
        SelectUIBase.SetActive(true);
        selectSlimeUiOn = true;
        Slot[] invenItemSlots = inven.GetSlimeSlot();
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].ClearSlot();
            if (invenItemSlots[i].item != null)
            {
                itemSlots[i].AddItem(invenItemSlots[i].item, invenItemSlots[i].itemCount);
            }
        }
    }
    public void SlectTrashUI(Cell _cell)
    {
        SoundManager.S.PlaySE("닫기");
        cell = _cell;
        SelectUIBase.SetActive(true);
        selectTrashUiOn = true;
        Slot[] invenItemSlots = inven.GetTrashSlot();
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].ClearSlot();
            if (invenItemSlots[i].item != null)
            {
                itemSlots[i].AddItem(invenItemSlots[i].item, invenItemSlots[i].itemCount);
            }
        }
    }
    public void UseTrash(Item item,Slot _slot)
    {
       // AddItem.S.SearchItem("슬라임");
        //inven.AcquireItem(item,-1);
        SelectItemUIOff();

        selectNumUI.SetActive(true);
        selectNumUIBase.GetComponent<SelectNumUI>().SelectNumUIOn(_slot, cell);

        
    }

    public void UseSlime(Item item,Slot _slot)
    {

       // insertSlime.FactoryOn(item, UseNum);
        SelectItemUIOff();

        selectNumUI.SetActive(true);
        selectNumUIBase.GetComponent<SelectNumUI>().SelectNumUIOn(_slot,insertSlime);
        LocationManager.openUI = true;


    }


    public void SelectItemUIOff()
    {
        selectSlimeUiOn = false;
        selectTrashUiOn = false;
        selectProductUiOn = false;
        SelectUIBase.SetActive(false);
        LocationManager.openUI = false;

    }
}
