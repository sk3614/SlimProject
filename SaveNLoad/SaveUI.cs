using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveUI : MonoBehaviour
{
    public static SaveUI S;

    public SaveData saveData;
    public SaveNLoad saveNLoad;
    public SaveSlot[] slots;
    public GameObject SelectUI;
    public GameObject OKUI;

    public Sprite easyImage;
    public Sprite normalImage;
    public Sprite hardImage;
    public Sprite EndlessImage;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveUIOpen()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            saveData = saveNLoad.LoadDataInTitle(i + 1);
            if (saveData != null)
            {
                slots[i].DayText.text = saveData.year.ToString() + "년" + saveData.month.ToString() + "분기" + saveData.day.ToString() + "일";
                slots[i].MoneyText.text = "Money : " + saveData.money.ToString();
                switch (saveData.gameDifficult)
                {
                    case 0:
                        slots[i].difficultText.text = "쉬움";//난이도 나오면 수정
                        slots[i].SlotImage.sprite = easyImage; //이미지 나오면 수정
                        break;
                    case 1:
                        slots[i].difficultText.text = "보통";//난이도 나오면 수정
                        slots[i].SlotImage.sprite = normalImage; //이미지 나오면 수정
                        break;
                    case 2:
                        slots[i].difficultText.text = "어려움";//난이도 나오면 수정
                        slots[i].SlotImage.sprite = hardImage; //이미지 나오면 수정
                        break;
                    case 3:
                        slots[i].difficultText.text = "무한모드";//난이도 나오면 수정
                        slots[i].SlotImage.sprite = EndlessImage; //이미지 나오면 수정
                        break;
                    default:
                        break;
                }//난이도텍스트
            }
            else
            {
                slots[i].DayText.text = "";
                slots[i].MoneyText.text = "";
                slots[i].SlotImage = null; //이미지 나오면 수정
                slots[i].difficultText.text = "데이터가 없습니다";
            }
        }
    }
    public void SelectSave(int _num)
    {
        SaveNLoad.SaveNum = _num;
        SelectUI.SetActive(true);
    }

}
