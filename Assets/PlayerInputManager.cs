using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInputManager : MonoBehaviour
{

    private bool firstInput=false;

    [Header("Hand Animator")]
    public Animator HandR;
    public Animator HandL;

    [Header("ToReact")]
    public List<RectTransform> toReact;

    [Header("ShakeAnimation")]
    public float duration = 1;
    public float strenght = 1;
    public int vibrato = 10;
    public float randomness = 90;
    public bool fadeout = true;
    

    private void Update()
    {
        if(Input.anyKeyDown && !firstInput)
        {
            //start the game
            firstInput = true;
            BPMController.Instance.setStartGame();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) )
        {
            HandR.SetTrigger("Slap");
            HandL.SetTrigger("Slap");
            MoveMachine();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandL.SetTrigger("Slap");
            MoveMachine();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandR.SetTrigger("Slap");
            MoveMachine();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && BPMController.Instance.isBeatable)
        {
            BPMController.Instance.ProcessInput("Down");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && BPMController.Instance.isBeatable)
        {
            BPMController.Instance.ProcessInput("Left");
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && BPMController.Instance.isBeatable)
        {
            BPMController.Instance.ProcessInput("Right");
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && !BPMController.Instance.isBeatable)
        {
            BPMController.Instance.looseALife();
        }
       
    }

    void MoveMachine()
    {
        foreach(var obj in toReact)
        {
            obj.DOShakeScale(duration, strenght, vibrato, 0, fadeout); 
        }
       
    }

}
