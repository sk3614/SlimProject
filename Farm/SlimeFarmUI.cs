using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeFarmUI : MonoBehaviour
{
    
    public Cell slimeFarm;
    public Item item;
    public Image SlimeImage;
    public Text T_RemainTime;
    public Text T_SlimeName;
    public Text T_SlimeTier;
    public Text T_RemainMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeInHierarchy&& slimeFarm.remainTime>0)
        {
            T_RemainTime.text = "남은 시간:"+((int)slimeFarm.remainTime).ToString()+"초";
            T_RemainMaterial.text ="남은 원자재:" + (slimeFarm.remainItemNum-1).ToString() + "개";
        }

    }
    public void TrashSelect()
    {
        slimeFarm.TrashSelect();
    }
    public void MakeCancel()
    {
        slimeFarm.SelectMakecancel();
    }
    public void SetText()
    {
        item = slimeFarm.resultSlime;
        SlimeImage.sprite = item.itemImage;

        T_SlimeName.text = item.itemName;
        T_SlimeTier.text ="";
        
        for (int i = 0; i < item.Tier; i++)
        {
            T_SlimeTier.text += '★';
        }
    }
}
