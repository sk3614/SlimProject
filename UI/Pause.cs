using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static Pause S;
    public GameObject B_pause;
    // Start is called before the first frame update
    void Awake()
    {
     if(S==null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void PauseGame()
    {
        if(Time.timeScale>0)
        {
            Time.timeScale = 0;
            B_pause.GetComponent<Image>().color = Color.red;
        }
        else
        {
            Time.timeScale = 1.0f;
            B_pause.GetComponent<Image>().color = Color.black;
        }
        
    }

    
}
