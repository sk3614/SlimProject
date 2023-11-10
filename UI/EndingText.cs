using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndingText : MonoBehaviour
{
    string scriptText;
    string scriptText2;
    public GameObject goText2;
    public GameObject goGame;
    char[] pieceArr; //분해해서 담을 조각들의 배열
    char[] pieceArr2;
    string msg; // 출력할 메세지
    public Text text;


    // Use this for initialization
    void Start()
    {
        if (Time.timeScale==0)
        {
            Time.timeScale = 1.0f;
        }
        scriptText = "우리는 시험에 통과했다.\n" +
            "슬라임이 현재 가장 효과적인 대체자원임을 증명했다.\n" +
            "슬라임 제품은 전국적인 인기를 끌었다.\n" +
            "그러나 모든 자원을 대체할 순 없었다.\n" +
            "모든 사람들에게 지지를 얻을 순 없었다.\n" +
            "그럼에도 슬라임은 인류에 많은 도움을 주었다.\n";
        scriptText2 = "세계 곳곳에 슬라임이 필요하다.\n" +
            "불러만 준다면 어디든 달려가 공장을 세우고\n" +
            "제품을 만들어 낼 것이다.\n" +
            "모든 것은 인류의 번영을 위해서.\n" +
            "슬라임 프로젝트는 이제 막 시작된 것이다.\n";

        pieceArr = scriptText.ToCharArray();
        pieceArr2= scriptText2.ToCharArray();
        StartCoroutine("TextIntro");
       
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TextIntro()
    {
        for (int i = 0; i < pieceArr.Length; i++) //0부터 배열의 길이만큼 ++
        {
            msg += pieceArr[i]; // 출력할 메세지는 배열에 하나씩 더한다
            text.text = msg; // 출력
            yield return new WaitForSeconds(0.025f); // 0.1초간격으로 출력
        }
        goText2.SetActive(true);
    }
    IEnumerator TextIntro2()
    {
        StopCoroutine("TextIntro");
        msg = "";
        for (int i = 0; i < pieceArr2.Length; i++) //0부터 배열의 길이만큼 ++
        {
            msg += pieceArr2[i]; // 출력할 메세지는 배열에 하나씩 더한다
            text.text = msg; // 출력
            yield return new WaitForSeconds(0.025f); // 0.1초간격으로 출력
        }
        goText2.SetActive(true);
        goText2.GetComponent<Text>().text = "";
        goGame.SetActive(true);
        goGame.GetComponent<Text>().text = "아무 화면이나 누르십시오";
    }
    public void GoTitle()
    {
        SceneManager.LoadScene(0);
    }


    public void Skip()
    {
        if(!goText2.activeInHierarchy&&!goGame.activeInHierarchy)
        {
            StopCoroutine("TextIntro");
            text.text = scriptText;
            goText2.SetActive(true);
        }
        else if(goText2.activeInHierarchy&&!goGame.activeInHierarchy)
        {
            
            StartCoroutine("TextIntro2");
            goText2.SetActive(false);
            goText2.GetComponent<Text>().text = "";
            goGame.SetActive(true);
            goGame.GetComponent<Text>().text = "";
            
        }
        else if(!goText2.activeInHierarchy && goGame.activeInHierarchy)
        {
            StopCoroutine("TextIntro2");
            text.text = scriptText2;
            goGame.GetComponent<Text>().text = "아무 화면이나 누르십시오";
            goText2.SetActive(true);
        }
        else if (goText2.activeInHierarchy && goGame.activeInHierarchy)
        {
            GoTitle();
        }
    }
    
}
