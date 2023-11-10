using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffHire : MonoBehaviour {
    private Staff staff;

    public void UIOn(Staff stap)
    {
        SoundManager.S.PlaySE("닫기");
        staff = stap;
    }
    public void OK()
    {
        staff.NewStaff();
        if (this.gameObject.activeInHierarchy)
        {
            LocationManager.openUI = false;
            staff = null;
        }
    }
}
