using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInputManager : Singleton<PlayerInputManager>
{

    private bool firstInput=false;

    [Header("Hand Animator")]
    public Animator HandR;
    public Animator HandL;

    [Header("ToReact")]
    public List<RectTransform> toReactUI;
    public List<Transform> toReact;

    [Header("ShakeAnimationSucces")]
    public float duration = 1;
    public float strenght = 1;
    public int vibrato = 10;
    public bool fadeout = true;

    [Header("ShakeAnimationFail")]
    public float durationFail = 1;
    public float strenghtFail = 1;
    public int vibratoFail = 10;




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
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandL.SetTrigger("Slap");

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandR.SetTrigger("Slap");
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
            MoveMachineFail();
            BPMController.Instance.looseALife();
        }
       
    }

    public void MoveMachineSucess()
    {
        foreach (var obj in toReactUI)
        {
            obj.DOShakeScale(duration, strenght, vibrato, 0, fadeout);
        }
        foreach (var obj in toReact)
        {
            obj.DOShakeScale(duration, strenght, vibrato, 0, fadeout);
        }

    }
    public void MoveMachineFail()
    {
        foreach (var obj in toReactUI)
        {
            obj.DOShakeScale(durationFail, strenghtFail, vibratoFail, 0, fadeout);
        }
        foreach (var obj in toReact)
        {
            obj.DOShakeScale(durationFail, strenghtFail, vibratoFail, 0, fadeout);
        }
    }

}
