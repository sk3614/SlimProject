using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageBox : MonoBehaviour
{
    public Text text;
    public string str;
    private float ShowTime;
    public Image messageTypeImage;
    public Message message;


    // Start is called before the first frame update
    void Start()
    {
        ShowTime = 1.5f;
        message = GameObject.Find("Message").GetComponent<Message>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = str;
        ShowTime -= 1.0f * Time.deltaTime;
        if(ShowTime<0)
        {
            Destroy(gameObject);
            message.messageBoxList.RemoveAt(0);
        }
    }
}
