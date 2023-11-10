using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaffManagement : MonoBehaviour {
    private Staff staff;
    public Staff[] ShopStaffs;
    public Staff[] FactoryStaffs;
    
    [SerializeField]
    private Image staffImage;
    [SerializeField]
    private Text staffName;
    [SerializeField]
    private Text staffLoyalty;
    [SerializeField]
    private Text staffSalary;


    public void UIOn(Staff stap)
    {
        staff = stap;
        staffImage.sprite= staff.GetComponent<SpriteRenderer>().sprite;
        staffName.text = "이름:"+staff.GetStaffName();
        staffLoyalty.text = "충성도:"+staff.GetStaffLoyalty().ToString();
        staffSalary.text = "급료:" + staff.GetStaffSalary().ToString();
    }
    public void Fire()
    {
        staff.FireStaff();
        
        if (this.gameObject.activeInHierarchy)
        {
            LocationManager.openUI = false;
            staff = null;
        }
        
    }

}
