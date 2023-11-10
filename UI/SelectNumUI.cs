using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectNumUI : MonoBehaviour {
    public Text T_itemName;
    public Text T_itemNum;
    public Slider slider;
    private Item item;
    public Item.ItemType itemType;
    private InsertSlime insert;
    private Cell cell;
    public Inventory inven;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        T_itemNum.text = ((int)slider.value).ToString();
	}

    public void SelectNumUIOn(Slot _slot,InsertSlime _insert)
    {
        item = _slot.item;
        slider.maxValue = _slot.itemCount;
        insert = _insert;
        T_itemName.text = item.itemName;
        slider.value = 1;

    }
    public void SelectNumUIOn(Slot _slot, Cell _cell)
    {
        item = _slot.item;

        slider.maxValue = _slot.itemCount;
        cell = _cell;
        T_itemName.text = item.itemName;
        slider.value = 1;

    }
    public void OK()
    {
        if(item.itemType==Item.ItemType.Slime)
        {
            insert.PutSlime(item, (int)slider.value);
            insert.insertSlimeUI.SetActive(true);
            inven.AcquireItem(item, -(int)slider.value);
            
        }
        else if(item.itemType==Item.ItemType.Trash)
        {
            if(item.itemName=="퇴비 자루"&&Scenario.S.scenarioMaxNum==2)
            {
                Scenario.S.scenario2_compost += (int)slider.value;
            }
            if (item.itemName == "고철 자루" && Scenario.S.scenarioMaxNum == 2)
            {
                Scenario.S.scenario2_scrab += (int)slider.value;
            }
            if (item.itemName == "석탄 자루" && Scenario.S.scenarioMaxNum == 2)
            {
                Scenario.S.scenario2_coal += (int)slider.value;
            }
            cell.SlimeFarmOn(item, (int)slider.value);
            inven.AcquireItem(item, -(int)slider.value);
        }
        
        LocationManager.openUI = false;
    }
    public void SetMax()
    {
        slider.value = slider.maxValue;
    }
    public void SetMin()
    {
        slider.value = 1;
    }
    public void SliderSE()
    {
        SoundManager.S.PlaySE("스크롤");
    }
}
