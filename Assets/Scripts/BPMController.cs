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


    //Interval de temps entre un beat et un autre;
    public float beatInterval { get; private set; }
    private float beatTimer;

    //  1/8 de beat 
    private float beatIntervalD8; 
    private float beatTimerD8;
    
    //Defini si on a passé un temps entier
    //A chaque fois qu'il passe à true, on est pile sur un temps
    public static bool beatFull;
    //Compte le nombre total de temps depuis le début
    public static int beatCountFull;

    //Comme beatFull, mais sur un 8eme de temps
    public static bool beatD8;
    public static int beatCountD8;

    public  bool isBeatable = false;
    public List<Arrow> currentArrows;

    private void Awake()
    {
        currentArrows = new List<Arrow>();
    }


    private void FixedUpdate()
    {
        BeatDetection();
    }
    void BeatDetection()
    {
        //Beat count 
        beatFull = false;
        beatInterval = 60/bpm; 
        beatTimer += Time.fixedDeltaTime;

        if(beatTimer >= beatInterval)
        {
            spawner.SpawnArrow();
            beatTimer -= beatInterval;
           
            //On a passé un beat entier
            beatFull = true; 
            beatCountFull++;
        }

        // 8th of a beat count 
        beatD8 = false;
        beatIntervalD8 = beatInterval / 8;
        beatTimerD8 += Time.fixedDeltaTime;

        if (beatTimerD8 >= beatIntervalD8)
        {
            beatTimerD8 -= beatIntervalD8;
            beatD8 = true;
            beatCountD8++; 
        }

    }
    public void ProcessInput(string input)
    {
        if (currentArrows.Count <= 0)
            return;
        
        var matchingArrow = currentArrows.FirstOrDefault(a => a.arrowType.ToString() == input);

        if (matchingArrow)
        {
            Debug.Log("Win");
            currentArrows.Clear();
        }
        else
        {
            currentArrows.Clear();
            Debug.Log("Loose");
        }
    }




}