using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Cell : MonoBehaviour {
    public int remainItemNum;
    private float makeTime;
    public float remainTime;
    public Item item;
    public Item resultSlime;
    public Inventory inven;
    public GameObject T_RemainTime;
    public CreateCancel createCancel;
    public int makeDoubleChance;

    public GameObject TrashStorageUI;
    public Text T_GetTrashNum;
    public Text T_GetTrashTierNum;

    public GameObject TrashSelectUI;
    public GameObject TrashSelectUIBase;
    public GameObject SlimeFarmOnUI;
    public GameObject SlimeFarmOnUIBase;
    public GameObject Event11_Image;

    public enum CellKind
    {
        None,
        SlimeFarm,
        TrashStorage
    }
    public CellKind cellKind;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if(cellKind==CellKind.SlimeFarm)
        {
            if ((SlimeFarmOnUI.activeInHierarchy || TrashSelectUI.activeInHierarchy) && LocationManager.openUI == false)
            {
                LocationManager.openUI = true;
            }
        }
        else
        {
            if (TrashStorageUI.activeInHierarchy&& LocationManager.openUI == false)
            {
                LocationManager.openUI = true;
            }
        }
        
        if (cellKind == CellKind.SlimeFarm)
        {
            MakeSlime();
        }

      
    }

        private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (!LocationManager.openUI && item == null && cellKind == CellKind.SlimeFarm)
            {

                TrashSelectUI.SetActive(true);
                TrashSelectUIBase.GetComponent<SlimeFarmUI>().slimeFarm = this;

            }
            else if (!LocationManager.openUI && item != null && cellKind == CellKind.SlimeFarm)
            {
                SlimeFarmOnUIBase.GetComponent<SlimeFarmUI>().slimeFarm = this;
                SlimeFarmOnUIBase.GetComponent<SlimeFarmUI>().SetText();
                SlimeFarmOnUI.SetActive(true);

            }

            if (!LocationManager.openUI && cellKind == CellKind.TrashStorage)
            {
                TrashStorageUI.SetActive(true);
                LocationManager.openUI = true;
                SetTrashStorageText(FarmUpgrade.S.TrashQualityUpTier);
            }

        }

    }
    public void SlimeFarmOn(Item _item, int _itemNum)
    {
        item = _item;
        DayManager.S.FarmActive();
        if(item.Tier>=5)
        {
            switch (DifficultManager.S.gameDifficult)
            {
                case DifficultManager.GameDifficult.normal:
                    GeneralMeeting.S.FDADIVariation(-0.25f);
                    break;
                case DifficultManager.GameDifficult.hard:
                    GeneralMeeting.S.FDADIVariation(-0.37f);
                    break;
                case DifficultManager.GameDifficult.endless:
                    GeneralMeeting.S.FDADIVariation(-0.37f);
                    break;
                default:
                    break;
            }
            GeneralMeeting.S.Use5TierMaterial(_itemNum);
        }
        remainItemNum = _itemNum;
        CompanyValue.S.SetItemValue(_item, _itemNum, true);
        resultSlime = AddItem.S.GetItemFromName(DropTable.S.GetSlimeTable(item));
        makeTime = resultSlime.growTime;
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                break;
            case DifficultManager.GameDifficult.normal:
                makeTime += makeTime * 0.2f;
                break;
            case DifficultManager.GameDifficult.hard:
                makeTime += makeTime * 0.5f;
                break;
            case DifficultManager.GameDifficult.endless:
                break;
            default:
                break;
        }
        remainTime = makeTime;


        T_RemainTime.SetActive(true);
    }
    public void SlimeFarmLoad(string _trashName,int _remainItemNum, string _resultSlime,float _remainTime)
    {
        item = AddItem.S.GetItemFromName(_trashName);
        if(item!=null)
        {
            remainItemNum = _remainItemNum;
            resultSlime = AddItem.S.GetItemFromName(_resultSlime);
            makeTime = resultSlime.growTime;
            remainTime = _remainTime;
            T_RemainTime.SetActive(true);
        }
            
        
    }
    public void MakeSlime()
    {
        if (item != null)
        {
            if (remainItemNum > 0)
            {
                remainTime -= 1 * Time.deltaTime;
                T_RemainTime.GetComponent<TextMesh>().text = ((int)remainTime).ToString();
                if (remainTime <= 0)
                {
                    int value = Random.Range(1, 101);
                    remainItemNum -= 1;
                   
                    Archive.S.PlusSlimeStack(resultSlime.Tier);
                    AddItem.S.SearchItem(resultSlime.itemName);
                    
                    if(FarmUpgrade.S.TwinSlimeTier>0)
                    {
                        makeDoubleChance = 15 + 6 * (FarmUpgrade.S.TwinSlimeTier - 1);
                    }
                    if(value< makeDoubleChance)
                    {
                        Archive.S.PlusSlimeStack(7);
                        Archive.S.PlusSlimeStack(resultSlime.Tier);
                        AddItem.S.SearchItem(resultSlime.itemName);
                    }
                    resultSlime = AddItem.S.GetItemFromName(DropTable.S.GetSlimeTable(item));
                    makeTime = resultSlime.growTime;
                    remainTime = makeTime;
                    if(SlimeFarmOnUI.activeInHierarchy)
                    {
                        SlimeFarmOnUIBase.GetComponent<SlimeFarmUI>().SetText();
                    }
                    
                }
            }
            else
            {
                item = null;
                resultSlime = null;
                makeTime = 0;
                remainTime = 0;
                T_RemainTime.SetActive(false);
                SlimeFarmOnUI.SetActive(false);
                LocationManager.openUI = false;
                Message.S.AddMessage("슬라임농장의 생산이 끝났습니다",Message.MessageType.farm);
                LocationManager.S.FarmAlarmOn();

            }

        }
    }
    public void MakeTrash()
    {
        if (cellKind == CellKind.TrashStorage)
            DropTable.S.GetTrashTable(FarmUpgrade.S.TrashQualityUpTier);
    }
    public void MakeCancel()
    {
        for (int i = 1; i < remainItemNum; i++)
        {
            AddItem.S.SearchItem(item.itemName);
        }
        remainItemNum = 0;
        item = null;
        resultSlime = null;
        remainTime = 0;
        T_RemainTime.SetActive(false);
        GeneralMeeting.S.EnvironmentalGroupDIVariation(2);
        SlimeFarmOnUI.SetActive(false);


    }

    public void TrashSelect()
    {
        SelectItemUI.S.SlectTrashUI(this);

    }

    public void SelectMakecancel()
    {
        createCancel.CancelUIOn(this);
    }

    public void SetTrashStorageText(int _num)
    {
        switch (_num)
        {
            case 0:
                T_GetTrashNum.text = "생산 갯수:2~4";
                T_GetTrashTierNum.text = "★:60%\n★★:30%\n★★★:10%\n★★★★:0%\n★★★★★:0%\n★★★★★★:0%";
                break;
            case 1:
                T_GetTrashNum.text = "생산 갯수:3~6";
                T_GetTrashTierNum.text = "★:35%\n★★:40%\n★★★:20%\n★★★★:5%\n★★★★★:0%\n★★★★★★:0%";
                break;
            case 2:
                T_GetTrashNum.text = "생산 갯수:4~8";
                T_GetTrashTierNum.text = "★:20%\n★★:35%\n★★★:30%\n★★★★:10%\n★★★★★:5%\n★★★★★★:0%";
                break;
            case 3:
                T_GetTrashNum.text = "생산 갯수:5~10";
                T_GetTrashTierNum.text = "★:10%\n★★:25%\n★★★:35%\n★★★★:20%\n★★★★★:9%\n★★★★★★:1%";
                break;
            case 4:
                T_GetTrashNum.text = "생산 갯수:6~12";
                T_GetTrashTierNum.text = "★:0%\n★★:10%\n★★★:40%\n★★★★:30%\n★★★★★:17%\n★★★★★★:3%";
                break;
            case 5:
                T_GetTrashNum.text = "생산 갯수:8~16";
                T_GetTrashTierNum.text = "★:0%\n★★:0%\n★★★:30%\n★★★★:40%\n★★★★★:22%\n★★★★★★:8%";
                break;

            default:
                break;
        }
    }
    
}
