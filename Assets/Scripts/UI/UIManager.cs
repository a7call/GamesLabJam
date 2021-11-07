using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string playSceneName;
    public string winSceneName;
    public string looseSceneName;
    public string homeSceneName;
    private static UIManager _instance;

    public static UIManager Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

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