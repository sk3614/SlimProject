using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Changer : MonoBehaviour {

    public GameObject GotitleUI;
    public GameObject ExitGameUI;
    public GameObject SaveUIBase;
    public GameObject SaveOkUI;
    public GameObject LoadUIBase;
    public GameObject SelectChapterUI;
    public GameObject SelectGameDifficult;
    public GameObject HelpUI;

    [SerializeField]
    private SaveNLoad saveNLoad;

    public void StartGame(int difficult)
    {
        SoundManager.S.PlaySE("닫기");
        DifficultManager.S.SetDifficultValue(difficult);
        SceneManager.LoadScene(2);
    }
    public void StartEndlessGame()
    {
        SoundManager.S.PlaySE("닫기");
        DifficultManager.S.SetDifficultValue(3);
        SceneManager.LoadScene(2);
        
    }
    public void LoadGameStart()
    {
        SoundManager.S.PlaySE("닫기");
        SaveNLoad.IsLoad = true;
        SceneManager.LoadScene(1);
        
    }
   public void GoTitle()
    {
        SoundManager.S.PlaySE("닫기");
        gameObject.SetActive(false);
        SoundManager.S.StopBG();
        SceneManager.LoadScene(0);
        
    }
    public void Gameover()
    {
        LocationManager.openUI = false;
        SoundManager.S.StopBG();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void GoEnding()
    {
        SoundManager.S.StopBG();
        saveNLoad.SaveData(SaveNLoad.SaveNum);
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        SoundManager.S.StopBG();
        Application.Quit();
    }
    public void MenuUIOn()
    {
        if (LocationManager.openUI==false)
        {
            SoundManager.S.PlaySE("닫기");
            this.gameObject.SetActive(true);
        }
      

    }
    public void GoTitleUIOn()
    {
        SoundManager.S.PlaySE("닫기");
        GotitleUI.SetActive(true);
    }
    public void ExitGameUIOn()
    {
        SoundManager.S.PlaySE("닫기");
        ExitGameUI.SetActive(true);
    }
    public void SaveUIOn()
    {
        SoundManager.S.PlaySE("닫기");
        SaveUIBase.SetActive(true);
        SaveUI.S.SaveUIOpen();
    }
    public void Save()
    {
        SaveUI.S.SelectUI.SetActive(false);
        SaveUIBase.SetActive(false);
        saveNLoad.SaveData(SaveNLoad.SaveNum);
        SaveOkUI.SetActive(true);
    }
    public void LoadUIOn()
    {
        SoundManager.S.PlaySE("닫기");
        LoadUIBase.SetActive(true);
        LoadUI.S.LoadUIOpen();
    }
    public void SelectChapterUIOn()
    {
        SoundManager.S.PlaySE("닫기");
        SelectChapterUI.SetActive(true);
    }
    public void SelectDifficultUION()
    {
        SoundManager.S.PlaySE("닫기");
        SelectGameDifficult.SetActive(true);
    }
    public void HelpUiOn()
    {
        SoundManager.S.PlaySE("닫기");
        HelpUI.SetActive(true);
    }
}
