using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextManager : MonoBehaviour
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
        scriptText = "20XX년 인류는 큰 위기에 직면했다.\n" +
            "자원 고갈, 식량 부족, 인간들의 높은 생활수준.\n" +
            "인류는 새로운 형태의 자원을 찾는데 온 힘을 다했다.\n" +
            "그러던 어느 날, 지하의 맨틀 부근.\n" +
            "뜨거운 마그마만이 존재할 것만 같은 곳에\n" +
            "인간의 예측을 뛰어넘는 것이 있었다.\n" +
            "넓은 동굴과 다양한 형태의 지리.\n" +
            "영화 잃어버린 세계를 찾아서처럼 생태계가 펼쳐져 있었다.\n";
        scriptText2 = "허나, 거기에 있던 것은 슬라임이라는 생물 뿐.\n" +
            "많은 과학자와 탐험가들은 실망했다.\n" +
            "그러나 곧 슬라임이 사용하기에 따라\n" +
            "엄청난 자원이 될 수 있다는 걸 발견했다.\n" +
            "우리 정부는 다른 국가들처럼 슬라임을 이용한 상품 개발에 들어갔다.\n" +
            "하지만 어떤 개발이든 사고팔아 돈을 벌어야만 하는 것.\n" +
            "당신과 당신의 회사가 이를 증명해야한다.";

        pieceArr = scriptText.ToCharArray();
        pieceArr2= scriptText2.ToCharArray();
        StartCoroutine("TextIntro");
        if (Time.timeScale==0)
        {
            Time.timeScale = 1.0f;
        }
        
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
    public void GameStart()
    {
        SceneManager.LoadScene(1);
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
            GameStart();
        }
    }
    
}
