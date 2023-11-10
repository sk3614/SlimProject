using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBasic : MonoBehaviour {


    public void UIExit()
    {
        if(this.gameObject.activeInHierarchy)
        {
            SoundManager.S.PlaySE("닫기2");
            this.gameObject.SetActive(false);
            LocationManager.openUI = false;
        }
    }
    
}
