using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText, comboText, lifePlayertext;

    public List<Image> heartList;
    public Sprite brokenHeart;
    public TextMeshProUGUI newTextScore;
    
    private int _indexHeart = 0;
    // Start is called before the first frame update
    void Start()
    {
        newTextScore.text = ScoreManager.Instance.score.ToString();
        scoreText.text = ScoreManager.Instance.score.ToString();
        comboText.text = ScoreManager.Instance.comboCount.ToString();
        lifePlayertext.text = ScoreManager.Instance.lifePlayer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        newTextScore.text = ScoreManager.Instance.score.ToString();        scoreText.text = ScoreManager.Instance.score.ToString();
        comboText.text = ScoreManager.Instance.comboCount.ToString();
        lifePlayertext.text = ScoreManager.Instance.lifePlayer.ToString();
    }

    public void handleLifePlayerUI()
    {
        this.transform.GetChild(2).transform.GetChild(ScoreManager.Instance.lifePlayer).gameObject.SetActive(false);
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
