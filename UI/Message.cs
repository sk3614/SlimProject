using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Message : MonoBehaviour
{
    public static Message S;

    public List<string> messageList;
    public GameObject messageBase;
    public float showTime;
    public List<GameObject> messageBoxList;
    public Sprite[] messageTypeSprite;

    public enum MessageType
    {
        farm,
        factory,
        shop,
        company
    }


    private void Awake()
    {
        if(S==null)
        {
            S = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void AddMessage(string message,MessageType messageType)
    {
        //messageList.Add(message);
        MakeMessageBox(message, messageType);
    }

    public void ShowMessage()
    {
        if (messageList.Count > 0)
        {
            messageBase.gameObject.SetActive(true);
            if(showTime>=2.0f)
            {
                messageList.RemoveAt(0);
                showTime = 0;
            }
        }else
        {
            messageBase.gameObject.SetActive(false);
        }
        

    }

    public void MakeMessageBox(string message,MessageType messageType)
    {
        for (int i = 0; i < messageBoxList.Count; i++)
        {
            messageBoxList[i].GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
            messageBoxList[i].GetComponent<RectTransform>().transform.position = new Vector3(messageBoxList[i].GetComponent<RectTransform>().transform.position.x, messageBoxList[i].GetComponent<RectTransform>().position.y + messageBoxList[i].GetComponent<RectTransform>().position.y, 0);

        }
        GameObject Box = messageBase;
        Box = Instantiate(Box);
        Box.transform.SetParent(gameObject.transform);
        Box.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
        Box.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        Box.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        Box.GetComponent<MessageBox>().str = message;
        switch (messageType)
        {
            case MessageType.farm:
                Box.GetComponent<MessageBox>().messageTypeImage.sprite = messageTypeSprite[0];
                break;
            case MessageType.factory:
                Box.GetComponent<MessageBox>().messageTypeImage.sprite = messageTypeSprite[1];
                break;
            case MessageType.shop:
                Box.GetComponent<MessageBox>().messageTypeImage.sprite = messageTypeSprite[2];
                break;
            case MessageType.company:
                Box.GetComponent<MessageBox>().messageTypeImage.sprite = messageTypeSprite[3];
                break;
            default:
                break;
        }
        messageBoxList.Add(Box);


    }
}
