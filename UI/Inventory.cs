using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlimeSlotsParent;
    [SerializeField]
    private GameObject go_TrashSlotsParent;
    [SerializeField]
    private GameObject go_ProductSlotsParent;

    private Slot[] slimeSlot;
    private Slot[] trashSlot;
    // Use this for initialization
    void Start() {
        slimeSlot = go_SlimeSlotsParent.GetComponentsInChildren<Slot>();
        trashSlot = go_TrashSlotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update() {
        if (go_InventoryBase.activeInHierarchy && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }

    public void TryOpenInventory()
    {
        if (!LocationManager.openUI && !inventoryActivated)
        {
            OpenInventory();
        }
        else if (LocationManager.openUI && inventoryActivated)
        {
            CloseInventory();
        }
           
    }

    private void OpenInventory()
    {
        inventoryActivated = true;
            LocationManager.openUI = true;
            go_InventoryBase.SetActive(true);
        SlimeSlotOn();


    }
    private void CloseInventory()
    {
        SoundManager.S.PlaySE("닫기2");
        inventoryActivated = false;
            LocationManager.openUI = false;
            go_InventoryBase.SetActive(false);
            
    }

    public void AcquireItem(Item _item,int _count=1)
    {
        //슬라임일때
        if (Item.ItemType.Slime == _item.itemType)
        {
            for (int i = 0; i < slimeSlot.Length; i++)
            {
                if (slimeSlot[i].item != null)
                {
                    if (slimeSlot[i].item.itemName == _item.itemName)
                    {
                        slimeSlot[i].SetSlotCount(_count);
                        return;
                    }
                }
            }

            for (int i = 0; i < slimeSlot.Length; i++)
            {
                if (slimeSlot[i].item == null)
                {
                    slimeSlot[i].AddItem(_item, _count);
                    return;
                }

            }
        }
        //쓰레기일때
        if(Item.ItemType.Trash == _item.itemType)
        {
            for (int i = 0; i < trashSlot.Length; i++)
            {
                if (trashSlot[i].item != null)
                {
                    if (trashSlot[i].item.itemName == _item.itemName)
                    {
                        trashSlot[i].SetSlotCount(_count);
                        return;
                    }
                }
            }

            for (int i = 0; i < trashSlot.Length; i++)
            {
                if (trashSlot[i].item == null)
                {
                    trashSlot[i].AddItem(_item, _count);
                    return;
                }

            }
        }

    }
    public void SlimeSlotOn()
    {
        SoundManager.S.PlaySE("터치");
        go_SlimeSlotsParent.SetActive(true);
        go_TrashSlotsParent.SetActive(false);
        go_ProductSlotsParent.SetActive(false);
    }
    public void TrashSlotOn()
    {
        SoundManager.S.PlaySE("터치");
        go_SlimeSlotsParent.SetActive(false);
        go_TrashSlotsParent.SetActive(true);
        go_ProductSlotsParent.SetActive(false);
    }
    public void ProductSlotOn()
    {
        SoundManager.S.PlaySE("터치");
        go_SlimeSlotsParent.SetActive(false);
        go_TrashSlotsParent.SetActive(false);
        go_ProductSlotsParent.SetActive(true);
    }

    public Slot[] GetSlimeSlot()
    {
        return slimeSlot;
    }
    public Slot[] GetTrashSlot()
    {
        return trashSlot;
    }
    public void ClearSlot()
    {
        for (int i = 0; i < slimeSlot.Length; i++)
        {
            slimeSlot[i].ClearSlot();
        }
        for (int i = 0; i < trashSlot.Length; i++)
        {
            trashSlot[i].ClearSlot();
        }
    }
}


