using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public string nameGameScene;
    
    public void PlayScene()
    {
        SceneManager.LoadScene(nameGameScene);
    }
}
