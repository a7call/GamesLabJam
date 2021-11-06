using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMController : Singleton<BPMController>
{

    public float bpm;

    //Interval de temps entre un beat et un autre;
    private float beatInterval;
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



    void Update(){
        BeatDetection();    
    }
    void BeatDetection()
    {
        //Beat count 
        beatFull = false;
        beatInterval = 60/bpm; 
        beatTimer += Time.deltaTime;

        if(beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;

            //On a passé un beat entier
            beatFull = true; 
            beatCountFull++;
        }

        // 8th of a beat count 
        beatD8 = false;
        beatIntervalD8 = beatInterval / 8;
        beatTimerD8 += Time.deltaTime;

        if (beatTimerD8 >= beatIntervalD8)
        {
            beatTimerD8 -= beatIntervalD8;
            beatD8 = true;
            beatCountD8++; 
        }

    }


    
}
