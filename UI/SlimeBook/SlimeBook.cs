using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Kind
{
    public bool[] G = new bool[5];
    public bool[] B = new bool[5];
    public bool[] Y = new bool[5];
    public bool[] R = new bool[5];
    public bool[] N = new bool[2];
}
[System.Serializable]
public class BookUI
{
    public Image itemImage;
    public Text itemName;
    public Text itemInfo;
    public GameObject UIBase;

    public SlimeBookSlot[] G;
    public SlimeBookSlot[] B;
    public SlimeBookSlot[] Y;
    public SlimeBookSlot[] R;
    public SlimeBookSlot[] N;

    public GameObject[] Type;
}
public class SlimeBook : MonoBehaviour
{
    public static SlimeBook S;

    public Kind slime=new Kind();
    public Kind material=new Kind();

    public BookUI slimeUI;
    public BookUI materialUI;
    public GameObject SelectUI;

    public SaveNLoad saveNLoad;
    private void Awake()
    {
        if (S==null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        material.N = new bool[1];
    }

    public void OpenSlot(Item item)
    {
        int kind=0;
        int tier=0;

        tier = item.Tier - 1;
        
        if (item.itemType==Item.ItemType.Slime)
        {
            switch (item.slimeType)
            {
                case Item.SlimeType.Green:
                    kind = 0;
                    break;
                case Item.SlimeType.Blue:
                    kind = 1;
                    break;
                case Item.SlimeType.Yellow:
                    kind = 2;
                    break;
                case Item.SlimeType.Red:
                    kind = 3;
                    break;
                case Item.SlimeType.King:
                    tier = 1;
                    kind = 4;
                    break;
                case Item.SlimeType.Ash:
                    kind = 4;
                    break;
                default:
                    break;
            }

            OpenSlime(kind, tier);
        }
        else
        {
            switch (item.trashType)
            {
                case Item.TrashType.Fertilizer:
                    kind = 0;
                    break;
                case Item.TrashType.ScrapMetal:
                    kind = 1;
                    break;
                case Item.TrashType.WasteWater:
                    kind = 3;
                    break;
                case Item.TrashType.Jewel:
                    tier = 0;
                    kind = 4;
                    break;
                default:
                    break;
            }
            OpenMaterial(kind, tier);
        }
    }

    public void OpenSlime(int _kind, int _tier)
    {
        switch (_kind)
        {
            case 0://G
                slime.G[_tier] = true;
                break;
            case 1://B
                slime.B[_tier] = true;
                break;
            case 2://Y
                slime.Y[_tier] = true;
                break;
            case 3://R
                slime.R[_tier] = true;
                break;
            case 4://N
                slime.N[_tier] = true;
                break;
            default:
                break;
        }
    }
    public void OpenMaterial(int _kind, int _tier)
    {
        switch (_kind)
        {
            case 0://G
                material.G[_tier] = true;
                break;
            case 1://B
                material.B[_tier] = true;
                break;
            case 2://Y
                material.Y[_tier] = true;
                break;
            case 3://R
                material.R[_tier] = true;
                break;
            case 4://N
                material.N[_tier] = true;
                break;
            default:
                break;
        }
    }

    public void OpenSlimeBookUI()
    {
        SelectUI.SetActive(true);
        materialUI.UIBase.SetActive(false);
        slimeUI.UIBase.SetActive(false);
        SoundManager.S.PlaySE("터치");
    }

    public void OpenSlimeBook()
    {
        SoundManager.S.PlaySE("터치");

        materialUI.UIBase.SetActive(false);
        slimeUI.UIBase.SetActive(true);
        for (int i = 0; i < slimeUI.G.Length; i++)
        {
            if (slime.G[i])
            {
                slimeUI.G[i].HideUIOpen();
            }

        }
        for (int i = 0; i < slimeUI.B.Length; i++)
        {
            if (slime.B[i])
            {
                slimeUI.B[i].HideUIOpen();
            }

        }
        for (int i = 0; i < slimeUI.Y.Length; i++)
        {
            if (slime.Y[i])
            {
                slimeUI.Y[i].HideUIOpen();
            }

        }
        for (int i = 0; i < slimeUI.R.Length; i++)
        {
            if (slime.R[i])
            {
                slimeUI.R[i].HideUIOpen();
            }

        }
        for (int i = 0; i < slimeUI.N.Length; i++)
        {
            if (slime.N[i])
            {
                slimeUI.N[i].HideUIOpen();
            }

        }
    }
    public void OpenMaterialBookUI()
    {

        SoundManager.S.PlaySE("터치");
        materialUI.UIBase.SetActive(true);
        slimeUI.UIBase.SetActive(false);
        for (int i = 0; i < materialUI.G.Length; i++)
        {
            if (material.G[i])
            {
                materialUI.G[i].HideUIOpen();
            }

        }
        for (int i = 0; i < materialUI.B.Length; i++)
        {
            if (material.B[i])
            {
                materialUI.B[i].HideUIOpen();
            }

        }
        for (int i = 0; i < materialUI.Y.Length; i++)
        {
            if (material.Y[i])
            {
                materialUI.Y[i].HideUIOpen();
            }

        }
        for (int i = 0; i < materialUI.R.Length; i++)
        {
            if (material.R[i])
            {
               materialUI.R[i].HideUIOpen();
            }

        }
        for (int i = 0; i < materialUI.N.Length; i++)
        {
            if (material.N[i])
            {
                materialUI.N[i].HideUIOpen();
            }

        }
    }

    public void SetUI(Item item)
    {
        SoundManager.S.PlaySE("터치");
        if (slimeUI.UIBase.activeInHierarchy)
        {
            slimeUI.itemImage.sprite = item.itemImage;
            slimeUI.itemName.text = item.itemName;
            slimeUI.itemInfo.text = item.info;
        }
        else
        {
            materialUI.itemImage.sprite = item.itemImage;
            materialUI.itemName.text = item.itemName;
            materialUI.itemInfo.text = item.info;
        }
      
        
    }
    public void ShowSlimeType(int _num)
    {
        SoundManager.S.PlaySE("터치");
        for (int i = 0; i < slimeUI.Type.Length; i++)
        {
            slimeUI.Type[i].SetActive(false);
        }
        slimeUI.Type[_num].SetActive(true);
    }
    public void ShowMaterialType(int _num)
    {
        SoundManager.S.PlaySE("터치");
        for (int i = 0; i < materialUI.Type.Length; i++)
        {
            materialUI.Type[i].SetActive(false);
        }
        materialUI.Type[_num].SetActive(true);
    }

    public void LoadDataInTitle()
    {
        SlimeBookData slimeBookData = saveNLoad.LoadSlimeBookData();

        slime.G = slimeBookData.G_S;
        slime.B = slimeBookData.B_S;
        slime.Y = slimeBookData.Y_S;
        slime.R = slimeBookData.R_S;
        slime.N = slimeBookData.N_S;

        material.G = slimeBookData.G_M;
        material.B = slimeBookData.B_M;
        material.Y = slimeBookData.Y_M;
        material.R = slimeBookData.R_M;
        material.N = slimeBookData.N_M;
    }
}
