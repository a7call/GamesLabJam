using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMController : Singleton<BPMController>
{
    [Header("BPM")]
    public float bpm;

    [Header("Arrows")]
    [SerializeField] ArrowSpawner spawner;

    [Header("Claw")]
    [SerializeField] UfoClaw claw;


    //Interval de temps entre un beat et un autre;
    public float beatInterval { get; private set; }
    public float beatTimer;

    //  1/8 de beat 
    private float beatIntervalD2; 
    private float beatTimerD2;
    
    //Defini si on a passé un temps entier
    //A chaque fois qu'il passe à true, on est pile sur un temps
    public static bool beatFull;
    //Compte le nombre total de temps depuis le début
    public static int beatCountFull;

    //Comme beatFull, mais sur un 8eme de temps
    public static bool beatD2;
    public static int beatCountD2;

    public  bool isBeatable = false;

    public  bool newSongQueued = false;
    private string songQueued, songPlaying;

    public List<Arrow> currentArrows;

    private int  startGame = 0 ;

    [SerializeField] GameObject LooseCanvas;
    private void Awake()
    {
        currentArrows = new List<Arrow>();
    }


    private void FixedUpdate()
    {
        if(startGame == 1)
        {
            songQueued = "Zakku_100";
            newSongQueued = true;
            BeatDetection();
            
                
                startGame = 2; 
        }
        else if(startGame == 2){
             BeatDetection();
        }
    }
    void BeatDetection()
    {
        //Beat count 
        beatFull = false;
        beatInterval = 60/bpm; 
        beatTimer += Time.fixedDeltaTime;

        if(beatTimer >= beatInterval)
        {
           
            StartCoroutine(spawner.SpawnArrow());
            beatTimer -= beatInterval;
           
            //On a passé un beat entier
            beatFull = true;
            beatCountFull++;
        }

        // 8th of a beat count 
        beatD2 = false;
        beatIntervalD2 = beatInterval / 2;
        beatTimerD2 += Time.fixedDeltaTime;

        if (beatTimerD2 >= beatIntervalD2)
        {
            beatTimerD2 -= beatIntervalD2;
            beatD2 = true;
            beatCountD2++; 

            if(newSongQueued && (beatCountD2 % 2 != 0))
            { 
                AudioManager audioManager = AudioManager.Instance;
                audioManager.Stop(songPlaying);
                audioManager.Play(songQueued, audioManager.gameObject);
                songPlaying = songQueued;
                newSongQueued= false;
            }
        }

    }
    public void ProcessInput(string input)
    {
        if (currentArrows.Count <= 0)
        {
            return;
        } 
        
        var matchingArrow = currentArrows.FirstOrDefault(a => a.arrowType.ToString() == input);

        if (matchingArrow)
        {
            PlayerInputManager.Instance.MoveMachineSucess();
            currentArrows.ForEach(a => a.isHit = true);
            if (matchingArrow.arrowType == ArrowType.Down)
            {
                ToyManager.Instance.SetRandomToyType();
                ScoreManager.Instance.UpScoreToy();
                ToyManager.Instance.currentSpawnedToy.isPicked = true;
                claw.TryGetToy();
                ToyManager.Instance.ScorePickedToy();
                AudioManager.Instance.pointsToy();
                Debug.Log("WIn BEAUCOUP points");     

            }
            else
            {
                ScoreManager.Instance.UpScoreLR();
                AudioManager.Instance.pointsClassic();
                ToyManager.Instance.ShuffleToys();
                Debug.Log("WIn points");
            }
            currentArrows.Clear();       
        }
        else
        {
            currentArrows.Clear();
            looseALife();
        }
    }

    public void looseALife()
    {
        AudioManager.Instance.failedSound();
        if(ScoreManager.Instance.lifePlayer <= 1)
        {
            Time.timeScale = 0;
            LooseCanvas.SetActive(true);
        }
        else
        {
            ScoreManager.Instance.looseLife();
        }
    }

    public void setStartGame(){
        startGame = 1;
    }

    public void askForNewSong(string musicToPlay)
    {
        newSongQueued = true;
        songQueued = musicToPlay;
    }




}
