using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeBookSlot : MonoBehaviour
{
    public Item item;
    public GameObject HideUI;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = item.itemImage;
    }
    public void HideUIOpen()
    {
        HideUI.SetActive(false);
    }
    public void SetBook()
    {
        SlimeBook.S.SetUI(item);
    }
}
