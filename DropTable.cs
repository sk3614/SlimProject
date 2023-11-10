using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable : MonoBehaviour
{

    public static DropTable S;
    private float green, blue, yellow, red;
    // Start is called before the first frame update
    void Awake()
    {

        if (S == null)
        {
            S = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void GetTrashTable(int _TrashQualityTier)
    {
        int value;//나올확률
        int value2;//종류 랜덤
        switch (_TrashQualityTier)
        {
            case 0:
                for (int i = 0; i < Random.Range(3, 6); i++)
                {
                    value = Random.Range(1, 101);
                    value2 = Random.Range(1, 4);
                    if (value <= 70)
                    {
                        GetTrash(1, value2);
                    }
                    else if (value <= 95)
                    {
                        GetTrash(2, value2);
                    }
                    else if (value <= 100)
                    {
                        GetTrash(3, value2);
                    }
                    
                }
                
                break;
            case 1:
                for (int i = 0; i < Random.Range(4, 7); i++)
                {
                    value = Random.Range(1, 101);
                    value2 = Random.Range(1, 4);
                    if (value <= 50)
                    {
                        GetTrash(1, value2);
                    }
                    else if (value <= 85)
                    {
                        GetTrash(2, value2);
                    }
                    else if (value <= 97)
                    {
                        GetTrash(3, value2);
                    }
                    else if (value <= 100)
                    {
                        GetTrash(4, value2);
                    }

                }
               
                break;
            case 2:
                for (int i = 0; i < Random.Range(5, 8); i++)
                {
                    value = Random.Range(1, 101);
                    value2 = Random.Range(1, 4);
                    if (value <= 35)
                    {
                        GetTrash(1, value2);
                    }
                    else if (value <= 65)
                    {
                        GetTrash(2, value2);
                    }
                    else if (value <= 85)
                    {
                        GetTrash(3, value2);
                    }
                    else if (value <= 97)
                    {
                        GetTrash(4, value2);
                    }
                    else if (value <= 100)
                    {
                        GetTrash(5, value2);
                    }

                }
                
                break;
            case 3:
                for (int i = 0; i < Random.Range(6, 9); i++)
                {
                    value = Random.Range(1, 101);
                    value2 = Random.Range(1, 4);
                    if (value <= 25)
                    {
                        GetTrash(1, value2);
                    }
                    else if (value <= 50)
                    {
                        GetTrash(2, value2);
                    }
                    else if (value <= 75)
                    {
                        GetTrash(3, value2);
                    }
                    else if (value <= 92)
                    {
                        GetTrash(4, value2);
                    }
                    else if (value <= 1100)
                    {
                        GetTrash(5, value2);
                    }

                }
                break;
                
            case 4:
                for (int i = 0; i < Random.Range(7, 10); i++)
                {
                    value = Random.Range(1, 101);
                    value2 = Random.Range(1, 4);
                    if (value <= 15)
                    {
                        GetTrash(1, value2);
                    }
                    else if (value <= 30)
                    {
                        GetTrash(2, value2);
                    }
                    else if (value <= 65)
                    {
                        GetTrash(3, value2);
                    }
                    else if (value <= 85)
                    {
                        GetTrash(4, value2);
                    }
                    else if (value <= 97)
                    {
                        GetTrash(5, value2);
                    }
                    else if (value <= 100)
                    {
                        GetTrash(6, value2);
                    }

                }
                
                break;
            case 5:
                for (int i = 0; i < Random.Range(8, 11); i++)
                {
                    value = Random.Range(1, 101);
                    value2 = Random.Range(1, 4);
                    if (value <= 10)
                    {
                        GetTrash(1, value2);
                    }
                    else if (value <= 20)
                    {
                        GetTrash(2, value2);
                    }
                    else if (value <= 50)
                    {
                        GetTrash(3, value2);
                    }
                    else if (value <= 75)
                    {
                        GetTrash(4, value2);
                    }
                    else if (value <= 91)
                    {
                        GetTrash(5, value2);
                    }
                    else if (value <= 100)
                    {
                        GetTrash(6, value2);
                    }

                }

                
                break;
                

            default:
                break;
        }
    }

    public void GetTrash(int _TrashTier,int value2)
    {
        switch (_TrashTier)
        {
            case 1:
                
                switch (value2)
                {
                    case 1:
                        AddItem.S.SearchItem("퇴비 자루");
                        Archive.S.PlusMaterialStack(0);
                        break;
                    case 2:
                        AddItem.S.SearchItem("고철 자루");
                        Archive.S.PlusMaterialStack(0);
                        break;
                    case 3:
                        AddItem.S.SearchItem("석탄 자루");
                        Archive.S.PlusMaterialStack(0);
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                
                switch (value2)
                {
                    case 1:
                        AddItem.S.SearchItem("톱밥 상자");
                        Archive.S.PlusMaterialStack(1);
                        break;
                    case 2:
                        AddItem.S.SearchItem("재활용품 상자");
                        Archive.S.PlusMaterialStack(1);
                        break;
                    case 3:
                        AddItem.S.SearchItem("연료 상자");
                        Archive.S.PlusMaterialStack(1);
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                
                switch (value2)
                {
                    case 1:
                        AddItem.S.SearchItem("비료 상자");
                        Archive.S.PlusMaterialStack(2);
                        break;
                    case 2:
                        AddItem.S.SearchItem("부품 상자");
                        Archive.S.PlusMaterialStack(2);

                        break;
                    case 3:
                        AddItem.S.SearchItem("화합물 상자");
                        Archive.S.PlusMaterialStack(2);
                        break;
                    default:
                        break;
                }
                break;
            case 4:
                
                switch (value2)
                {
                    case 1:
                        AddItem.S.SearchItem("단백질 캔");
                        Archive.S.PlusMaterialStack(3);
                        break;
                    case 2:
                        AddItem.S.SearchItem("초합금 캔");
                        Archive.S.PlusMaterialStack(3);

                        break;
                    case 3:
                        AddItem.S.SearchItem("성장제 캔");
                        Archive.S.PlusMaterialStack(3);
                        break;
                    default:
                        break;
                }
                break;
            case 5:
                
                switch (value2)
                {
                    case 1:
                        AddItem.S.SearchItem("상아");
                        Archive.S.PlusMaterialStack(4);
                        break;
                    case 2:
                        AddItem.S.SearchItem("첨단 기계");
                        Archive.S.PlusMaterialStack(4);
                        break;
                    case 3:
                        AddItem.S.SearchItem("핵연료");
                        Archive.S.PlusMaterialStack(4);
                        break;
                    default:
                        break;
                }
                break;
            case 6:
               
                switch (value2)
                {
                    case 1:
                        AddItem.S.SearchItem("보석 더미");
                        Archive.S.PlusMaterialStack(5);
                        break;
                    case 2:
                        AddItem.S.SearchItem("보석 더미");
                        Archive.S.PlusMaterialStack(5);
                        break;
                    case 3:
                        AddItem.S.SearchItem("보석 더미");
                        Archive.S.PlusMaterialStack(5);
                        break;
                    default:
                        break;
                }
                break;
        }
    }
   
    public string GetSlimeTable(Item _item)
    {
        int value;
        value = Random.Range(1, 101);
        switch (_item.Tier)
        {
            case 1://1티어쓰레기
                if (value <= 20)
                {
                 
                    return "애쉬 슬라임";
                }
                else
                {
                    value = Random.Range(1, 101);
                }
               if (value <= 60)
                {
                   return GetSlime(_item.trashType, 1);
                }
                else if (value <= 90)
                {
                    return GetSlime(_item.trashType, 2);
                }
                else if (value <= 100)
                {
                    return GetSlime(_item.trashType, 3);
                }
                break;
            case 2:
                if (value <= 16)
                {
                  
                    return "애쉬 슬라임";
                }
                else
                {
                    value = Random.Range(1, 101);
                }
                if (value <= 30)
                {
                    return GetSlime(_item.trashType, 1);
                }
                else if (value <= 75)
                {
                    return GetSlime(_item.trashType, 2);
                }
                else if (value <= 95)
                {
                    return GetSlime(_item.trashType, 3);
                }
                else if (value <= 100)
                {
                    return GetSlime(_item.trashType, 4);
                }
                break;
            case 3:
                if (value <= 12)
                {
                   
                    return "애쉬 슬라임";
                }
                else
                {
                    value = Random.Range(1, 101);
                }
                if (value <= 20)
                {
                    return GetSlime(_item.trashType, 1);
                }
                else if (value <= 55)
                {
                    return GetSlime(_item.trashType, 2);
                }
                else if (value <= 85)
                {
                    return GetSlime(_item.trashType, 3);
                }
                else if (value <= 98)
                {
                    return GetSlime(_item.trashType, 4);
                }
                else if (value <= 100)
                {
                    return GetSlime(_item.trashType, 5);
                }
                break;
            case 4:
                if (value <= 8)
                {
                  
                    return "애쉬 슬라임";
                }
                else
                {
                    value = Random.Range(1, 101);
                }
                 if (value <= 10)
                {
                    return GetSlime(_item.trashType, 1);
                }
                else if (value <= 35)
                {
                    return GetSlime(_item.trashType, 2);
                }
                else if (value <= 75)
                {
                    return GetSlime(_item.trashType, 3);
                }
                else if (value <= 95)
                {
                    return GetSlime(_item.trashType, 4);
                }
                else if (value <= 100)
                {
                    return GetSlime(_item.trashType, 5);
                }
                break;
            case 5:
                if (value <= 4)
                {
                    
                    return "애쉬 슬라임";
                }
                else
                {
                    value = Random.Range(1, 101);
                }
                if (value <= 5)
                {
                    return GetSlime(_item.trashType, 1);
                }
                else if (value <= 23)
                {
                    return GetSlime(_item.trashType, 2);
                }
                else if (value <= 58)
                {
                    return GetSlime(_item.trashType, 3);
                }
                else if (value <= 88)
                {
                    return GetSlime(_item.trashType, 4);
                }
                else if (value <= 100)
                {
                    return GetSlime(_item.trashType, 5);
                }
                break;
            case 6:
                if (value <= 1)
                {
                    
                    return "애쉬 슬라임";
                }
                else
                {
                    return GetSlime(_item.trashType, 6);
                }
            default:
                break;
        }
        return null;
    }
    public string GetSlime(Item.TrashType _Type, int _SlimeTier)
    {
        float value;
        value = Random.Range(1, 100);


        switch (_Type)
        {
            case Item.TrashType.Fertilizer:
                green = 50f;
                blue = 15f;
                yellow = 25f;
                red = 10f;
                break;
            case Item.TrashType.ScrapMetal:
                green = 10f;
                blue = 50f;
                yellow = 25f;
                red = 15f;
                break;
            case Item.TrashType.WasteWater:
                green = 15;
                blue = 10f;
                yellow = 25f;
                red = 50f;
                break;
            case Item.TrashType.Jewel:
                green = 25f;
                blue = 25f;
                yellow = 25f;
                red = 25f;
                break;
            default:
                break;
        }
        switch (_SlimeTier)
        {
            case 1:

                if (value <= green)
                    return "그린 슬라임";
                else if (value <= green + blue)
                    return "블루 슬라임";
                else if (value <= green + blue + yellow)
                    return "옐로우 슬라임";
                else if (value <= green + blue + yellow + red)
                    return "레드 슬라임";
                break;
            case 2:
               
                if (value <= green)
                    return "쏜 슬라임";  
                else if (value <= green + blue)
                    return "스노우 슬라임";
                else if (value <= green + blue + yellow)
                    return "샌드 슬라임";   
                else if (value <= green + blue + yellow + red)
                    return "라디언트 슬라임";
                break;
            case 3:
                
                if (value <= green)
                    return "부쉬 슬라임";
                else if (value <= green + blue)
                    return "슬러시 슬라임"; 
                else if (value <= green + blue + yellow)
                    return "젬 슬라임";
                else if (value <= green + blue + yellow + red)
                    return "라바 슬라임";
                break;
            case 4:
                
                if (value <= green)
                    return "베놈 슬라임";
                else if (value <= green + blue)
                    return "윈터 슬라임";
                else if (value <= green + blue + yellow)
                    return "스타 슬라임";
                else if (value <= green + blue + yellow + red)
                     return "마그네틱 슬라임";
                break;
            case 5:
                
                if (value <= green)
                    return "정글 슬라임";
                else if (value <= green + blue)
                    return "툰트라 슬라임";
                else if (value <= green + blue + yellow)
                     return "어스 슬라임";
                else if (value <= green + blue + yellow + red)
                    return "썬 슬라임";
                break;
            case 6:
                Archive.S.PlusSlimeStack(6);
                return "킹 슬라임";
            default:
                break;
        }
        return null;
    }
}
