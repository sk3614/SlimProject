using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashPickUp : MonoBehaviour {
    public static TrashPickUp S;
    private bool trashPickUpUIOn;
    public GameObject TrashPickUpBase;
    public GameObject PickUpItemImage;
    public Text pickUpItemText;
    public Inventory inven;
    private Item item;
    // Use this for initialization
    void Awake () {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryOpenTrashPickUp()
    {
        if (!LocationManager.openUI && !trashPickUpUIOn)
        {
            OpenTrashPickUp();
        }
        else if (LocationManager.openUI && trashPickUpUIOn)
        {
            CloseTrashPickUp();
        }

    }
    private void OpenTrashPickUp()
    {
            trashPickUpUIOn = !trashPickUpUIOn;
            LocationManager.openUI = true;
            TrashPickUpBase.SetActive(true);
        
    }
    private void CloseTrashPickUp()
    {
            trashPickUpUIOn = !trashPickUpUIOn;
            LocationManager.openUI = false;
            TrashPickUpBase.SetActive(false);
       
    }

    public void PickUpTrash()
    {
        int i = Random.Range(0, 8);
        Item[] items = AddItem.S.trashitems;
        item = items[i];
        inven.AcquireItem(item);
        PickUpItemImage.GetComponent<Image>().sprite = item.itemImage;
        pickUpItemText.text = item.itemName;
    }
}
