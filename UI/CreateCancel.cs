using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CreateCancel : MonoBehaviour
{
    private Cell cell=null;
    public GameObject UIBase;

    public void CancelUIOn(Cell _cell)
    {
        UIBase.gameObject.SetActive(true);
        cell = _cell;
        LocationManager.openUI = true;
    }
    public void Cancel()
    {
        if(cell!=null)
        {
            cell.MakeCancel();
            cell = null;
            UIBase.gameObject.SetActive(false);
            LocationManager.openUI = false;
        }
    }
}
