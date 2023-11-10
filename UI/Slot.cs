using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour {
    public Item item;
    public string itemName;
    public int itemCount;
    public Image itemImage;
    public Text itemNameText;
    public Item.ItemType itemType;
    public Image selectImage;

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    private void Setcolor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    public void Select()
    {
        if(SelectItemUI.S.selectTrashUiOn&&this.item!=null)
        {
            SelectItemUI.S.UseTrash(item,this);
        }
        if (SelectItemUI.S.selectSlimeUiOn && this.item != null)
        {
            SelectItemUI.S.UseSlime(item,this);
        }

    }

    public void AddItem(Item _item, int _count=1)
    {
        item = _item;
        itemCount = _count;
        itemName = _item.itemName;
        itemImage.sprite = item.itemImage;
        itemNameText.text = item.itemName;
        itemType = _item.itemType;
        if (itemType == Item.ItemType.Slime)
        {
            text_Count.color = Color.white;
        }
        else if (itemType == Item.ItemType.Trash)
        {
            text_Count.color = Color.black;
        }
        go_CountImage.SetActive(true);
        text_Count.text = itemCount.ToString();

        Setcolor(1);


    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();
        
        if(itemCount<=0)
            ClearSlot();
    }
    public void ClearSlot()
    {
        item = null;
        itemName = "";
        itemCount = 0;
        itemNameText.text = "";
        itemImage.sprite = null;
        itemType = Item.ItemType.ETC;
        Setcolor(0);

        go_CountImage.SetActive(false);
        text_Count.text = "0";
    }
}
