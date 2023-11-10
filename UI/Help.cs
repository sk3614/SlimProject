using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    // Start is called before the first frame update
    private int nowNum;

    public GameObject bgClose;
    public GameObject[] help_Images;
    void Start()
    {
        help_Images[nowNum].SetActive(true);
    }

    // Update is called once per frame
    public void NextPage()
    {
        SoundManager.S.PlaySE("닫기");
        if (nowNum==8)
        {
            help_Images[nowNum].SetActive(false);
            bgClose.SetActive(false);
            nowNum = 0;
            help_Images[nowNum].SetActive(true);
        }
        else
        {
            help_Images[nowNum].SetActive(false);
            nowNum += 1;
            help_Images[nowNum].SetActive(true);
        }
        
    }

    public void PrePage()
    {
        SoundManager.S.PlaySE("닫기");
        if (nowNum!=0)
        {
            help_Images[nowNum].SetActive(false);
            nowNum -= 1;
            help_Images[nowNum].SetActive(true);
        }
        
    }
}
