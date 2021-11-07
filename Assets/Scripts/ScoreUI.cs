using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText, comboText, lifePlayertext;

    public HeartsBar heartsBar;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreManager.Instance.score.ToString();
        comboText.text = ScoreManager.Instance.comboCount.ToString();
        lifePlayertext.text = ScoreManager.Instance.lifePlayer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.Instance.score.ToString();
        comboText.text = ScoreManager.Instance.comboCount.ToString();
        lifePlayertext.text = ScoreManager.Instance.lifePlayer.ToString();
    }

    public void handleLifePlayerUI()
    {
        this.transform.GetChild(2).transform.GetChild(ScoreManager.Instance.lifePlayer).gameObject.SetActive(false);
        heartsBar.LooseHeart();
    }
}
