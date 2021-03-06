using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    //Le nombre de vie du joueur est décidé par le nombre de sprites représentant sa vie dans la hierarchie du scoreUI
    [HideInInspector]
    public int score, comboCount, lifePlayer;



    int lastScore;
    [Header("Combo parameters")]
    [SerializeField] float multiplicator = 1.1f;
    [SerializeField] float scoreAddToy = 1000;
    [SerializeField] float scoreAddFleche= 10;

    [SerializeField] float comboScoreBase = 15;

    [Header("UI)")]
    [SerializeField] ScoreUI scoreUI;





    void Start(){
        lastScore = 0;
        //lifePlayer = scoreUI.transform.GetChild(2).childCount;
    }
    void Update()
    {
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
        if ((score > (lastScore + 15000)) && (BPMController.Instance.bpm < 70)){
            Debug.Log("changeBPM");
            BPMController.Instance.bpm += 5 ;
            string musicToPlay = "Zakku_" + BPMController.Instance.bpm*2;
            BPMController.Instance.askForNewSong(musicToPlay);
            lastScore = score;
        }
    }

    public void looseLife()
    {
        lifePlayer --;
        stopCombo();
        scoreUI.handleLifePlayerUI();
    }
}
