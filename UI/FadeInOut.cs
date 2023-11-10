using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {
    public static FadeInOut S;
    public Color color;
    private float a;//알파값

    private void Awake()
    {
        S = this;
    }
    void Start () {
        a = .0f;
        color = Color.black;
       
    }
	
	// Update is called once per frame
	void Update () {
        if(a>=0.1)
        {
            a -= 1 * Time.unscaledDeltaTime;//deltaTime;
            color = new Color(0, 0, 0, a);
            gameObject.GetComponent<Image>().color = color;
        }
        else
        {
            a = 0;
            color = new Color(0, 0, 0, a);
            gameObject.GetComponent<Image>().color = color;
        }
        
        
	}
    public void FadeStart()
    {
        a = 1.0f;
    }
}
