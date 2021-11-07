using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    public string playSceneName;
    public string winSceneName;
    public string looseSceneName;
    public string homeSceneName;
    
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
}