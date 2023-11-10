using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PackageLine : MonoBehaviour
{
    public GameObject packageLineUI;
    
    private void Update()
    {
        if (packageLineUI.activeInHierarchy && LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (!LocationManager.openUI && !EventSystem.current.IsPointerOverGameObject())
        {
            SoundManager.S.PlaySE("닫기");
            packageLineUI.SetActive(true);
            LocationManager.openUI = true;
        }
    }
}
