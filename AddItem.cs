using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {
    public static AddItem S;
    public Item[] items;
    public Item[] trashitems;
    public Item item;
    Dictionary<string, Item> ItemDictionary = new Dictionary<string, Item>();


    public Inventory inven;
     void Awake()
    {
        if(S==null)
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
        for (int i = 0; i < items.Length; i++)
        {
            ItemDictionary.Add(items[i].itemName, items[i]);
        }
        for (int i = 0; i < trashitems.Length; i++)
        {
            ItemDictionary.Add(trashitems[i].itemName, trashitems[i]);
        }

       

    }

    private void addItem () {
        inven.AcquireItem(item);
    }
    public void SearchItem(string _itemname,int num=1)
    {

       

        Item tmpItem= ItemDictionary[_itemname];
        item = tmpItem;

        CompanyValue.S.SetItemValue(item,num);

        SlimeBook.S.OpenSlot(item);

       
        for (int i = 0; i < num; i++)
        {
            inven.AcquireItem(item);
        }
        item = null;

    }
    public Item GetItemFromName(string _itemName)
    {
        if(_itemName == "")
        {
            return null;
        }
        else
        {
            Item tmpItem = ItemDictionary[_itemName];
            return tmpItem;
        }
        
    }

}
