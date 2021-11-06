using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText, comboText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.Instance.score.ToString();
        comboText.text = ScoreManager.Instance.comboCount.ToString();
    }
}
