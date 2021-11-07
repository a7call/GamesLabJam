using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [HideInInspector]
    public int score;


    public int comboCount;
    int lastScore;
    [Header("Combo parameters")]
    [SerializeField] float multiplicator = 1.8f;
    [SerializeField] float scoreAddToy = 1000;
    [SerializeField] float scoreAddFleche= 10;

    [SerializeField] float comboScoreBase = 15;



    void Start(){
        lastScore = 0;
    }
    void Update()
    {
           // Debug.Log("SCORE : " + score );
            changeBPM();
    }
    public void UpScoreToy()
    {
        this.score += (int) (scoreAddToy + comboCount * multiplicator * comboScoreBase);
        comboCountUp();
    }

    public void UpScoreLR()
    {   
        if(comboCount > 0)
        this.score += (int) (scoreAddFleche + Mathf.Log10(comboCount * multiplicator * comboScoreBase));
        else
        this.score += (int) (scoreAddFleche + Mathf.Log10(multiplicator * comboScoreBase));
        comboCountUp();
    }

    public void comboCountUp()
    {
        comboCount++;
    }

    public void stopCombo()
    {
        comboCount = 0;
    }


    void changeBPM(){
        if (score > (lastScore + 20000) && score < 140000){
            BPMController.Instance.bpm += 10 ;
            lastScore = score;
        }
    }
}
