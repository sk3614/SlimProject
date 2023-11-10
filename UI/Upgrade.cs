using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {
    public GameObject upgradeUI;
    public GameObject farmUI;
    public GameObject farmUpgradeUI;
    public GameObject factoryUI;
    public GameObject factoryUpgradeUI;
    public GameObject shopUI;
    public GameObject B_Upgrade;
    public LocationManager locationManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (locationManager.GetLocation() == LocationManager.Location.Company)
        {
            B_Upgrade.SetActive(false);
        }
        else B_Upgrade.SetActive(true);
        if (upgradeUI.activeInHierarchy&& LocationManager.openUI == false)
        {
            LocationManager.openUI = true;
        }
    }

    public void UIOn()
    {   if(LocationManager.openUI==false)
        {
            SoundManager.S.PlaySE("닫기");
            print(locationManager.GetLocation());
            upgradeUI.SetActive(true);
            LocationManager.openUI = true;
            switch (locationManager.GetLocation())
            {
                case LocationManager.Location.Farm:
                    
                    farmUI.SetActive(true);
                    factoryUI.SetActive(false);
                    shopUI.SetActive(false);
                    break;
                case LocationManager.Location.Factory:
                    farmUI.SetActive(false);
                    factoryUI.SetActive(true);
                    shopUI.SetActive(false);
                    break;
                case LocationManager.Location.Shop:
                    farmUI.SetActive(false);
                    factoryUI.SetActive(false);
                    shopUI.SetActive(true);
                    break;
                default:
                   
                    break;
            }
        }
        
    }

    public void ChangeFarmUpgrade()
    {
        farmUpgradeUI.SetActive(true);
    }
    public void ChangeFarmToggleUpgrade()
    {
        farmUpgradeUI.SetActive(false);
    }

    public void ChangeFactoryUpgrade()
    {
        factoryUpgradeUI.SetActive(true);
    }
    public void ChangeFactoryToggleUpgrade()
    {
        factoryUpgradeUI.SetActive(false);
    }
}
