using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item",menuName = "New Item/item")]
public class Item : ScriptableObject {
    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;
    public int Tier;

    public bool Trash________________________________;
    public TrashType trashType;

    public int trashTable;
    public float makeTime;
    public float growTime;

    public bool Slime_________________________________;
    public SlimeType slimeType;
    public int drugs;//비료갯수
    public int ice;//얼음갯수
    public int glass;//유리갯수
    public int fuel;//연료갯수
    [TextArea]
    public string info;
    public enum ItemType
    {
        Slime,
        Trash,
        ETC
    }
    public enum TrashType
    {
        Fertilizer,
        ScrapMetal,
        WasteWater,
        Jewel
    }
    public enum SlimeType
    {
        Green,
        Blue,
        Yellow,
        Red,
        King,
        Ash,
        Trash
    }
    public int MakeDrugs()
    {
        
        return drugs;
    }

    public int MakeIce()
    {
        
        return ice;
    }

    public int MakeGlass()
    {
        
        return glass;
    }

    public int MakeFuel()
    {
        
        return fuel;
    }

}
