using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MySceneManager : Singleton<MySceneManager>
{
    public string playSceneName;
    public string winSceneName;
    public string looseSceneName;
    public string homeSceneName;


    public GameObject ControlWindow;
    public GameObject GameOverWindow;
    
    public void PlayScene()
    {
        SceneManager.LoadScene(playSceneName);
    }
    
    public void WinScene()
    {
        SceneManager.LoadScene(winSceneName);
    }
    
    public void LooseScene()
    {
        SceneManager.LoadScene(looseSceneName);
    }
    
    public void HomeScene()
    {
        SceneManager.LoadScene(homeSceneName);
    }

    public void SetActiveControlWindow()
    {
        ControlWindow.SetActive(true);
    }
    
    public void ReStart()
    {
        DOTween.KillAll();
        Time.timeScale = 1;
        GameOverWindow.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}