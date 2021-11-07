using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{


    public List<Image> heartList;
    public Sprite brokenHeart;
    public TextMeshProUGUI newTextScore;
    public TextMeshProUGUI textCombo;
    
    private int _indexHeart = 0;
    // Start is called before the first frame update
    void Start()
    {
        newTextScore.text = ScoreManager.Instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        newTextScore.text = ScoreManager.Instance.score.ToString();
        textCombo.text = "X" + ScoreManager.Instance.comboCount.ToString();
    }

    public void handleLifePlayerUI()
    {
        RemoveHeart();
    }

    private void RemoveHeart()
    {
        if (_indexHeart < heartList.Count)
        {
            heartList[_indexHeart].sprite = brokenHeart;
            _indexHeart++;
        }
    }
}
