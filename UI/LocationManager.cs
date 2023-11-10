using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LocationManager : MonoBehaviour {
    public static LocationManager S;
    public enum Location
    {
        Farm,
        Factory,
        Shop,
        Company
    }
    private Location location;
    [SerializeField]
    public static bool openUI;
    public GameObject Camera;
    public GameObject Fade;
    public GameObject farm;
    public GameObject shop;
    public GameObject factory;
    public GameObject company;

    public GameObject farm_Alarm;
    public GameObject factory_Alarm;
    public GameObject SlimeBookUI;
    private void Awake()
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
void Start()
    {
        openUI = false;
        location = Location.Farm;
        Vector3 pos;
        pos = farm.transform.position;
        pos.z = -10;
        Camera.transform.position = pos;
        farm_Alarm.SetActive(false);
        Gofarm();
    }
   public void Gofarm()
    {
        if(LocationManager.openUI==false)
        {
            location = Location.Farm;

            Vector3 pos;
            pos = farm.transform.position;
            pos.z = -10;
            Camera.transform.position = pos;
            farm_Alarm.SetActive(false);
            SoundManager.S.PlaySE("터치");
            SlimeBookUI.SetActive(true);
            SoundManager.S.PlayBG();
            SoundManager.S.StopSE("공장");
            SoundManager.S.StopSE("포장");

        }
        
        

        FadeInOut.S.FadeStart();
    }

    public void GoFactory()
    {
        if (LocationManager.openUI == false)
        {
            location = Location.Factory;

            Vector3 pos;
            pos = factory.transform.position;
            pos.z = -10;
            Camera.transform.position = pos;
            factory_Alarm.SetActive(false);
            SoundManager.S.PlaySE("터치");
            SlimeBookUI.SetActive(false);
            SoundManager.S.StopBG();
            if (DayManager.S.createLines[0].isCreating || DayManager.S.createLines[1].isCreating || DayManager.S.createLines[2].isCreating)
            {
                SoundManager.S.PlaySE("공장");
            }
            if (DayManager.S.createLines[0].isPacking || DayManager.S.createLines[1].isPacking || DayManager.S.createLines[2].isPacking)
            {
                SoundManager.S.PlaySE("포장");
            }
        }


        FadeInOut.S.FadeStart();
    }
    public void GoShop()
    {
        if (LocationManager.openUI == false)
        {
            location = Location.Shop;

            Vector3 pos;
            pos = shop.transform.position;
            pos.z = -10;
            Camera.transform.position = pos;
            SoundManager.S.PlaySE("터치");
            SlimeBookUI.SetActive(false);
            SoundManager.S.StopBG();
            SoundManager.S.StopSE("공장");
            SoundManager.S.StopSE("포장");
        }


        FadeInOut.S.FadeStart();
    }
    public void GoCompany()
    {
        if (LocationManager.openUI == false)
        {
            location = Location.Company;

            Vector3 pos;
            pos = company.transform.position;
            pos.z = -10;
            Camera.transform.position = pos;
            SoundManager.S.PlaySE("터치");
            SlimeBookUI.SetActive(false);
            SoundManager.S.StopBG();
            SoundManager.S.StopSE("공장");
            SoundManager.S.StopSE("포장");
        }

         FadeInOut.S.FadeStart();
    }
    public Location GetLocation()
    {
        return location;
    }
    public void FarmAlarmOn()
    {
        if(location!=Location.Farm)
        {
            farm_Alarm.SetActive(true);
        }
        
    }
    public void FactoryAlarmOn()
    {
        if (location != Location.Factory)
        {
            factory_Alarm.SetActive(true);
        }

    }
}
