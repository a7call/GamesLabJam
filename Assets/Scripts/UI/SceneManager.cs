using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    public string playSceneName;
    public string winSceneName;
    public string looseSceneName;
    public string homeSceneName;

    public void PlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(playSceneName);
    }
    
    public void WinScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(winSceneName);
    }
    
    public void LooseScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(looseSceneName);
    }
    
    public void HomeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(homeSceneName);
    }
}