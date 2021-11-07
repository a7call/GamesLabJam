using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInputManager : Singleton<PlayerInputManager>
{
    public GameObject textTuto;
    private bool firstInput=false;

    [Header("Hand Animator")]
    public Animator HandR;
    public Animator HandL;

    [Header("ToReact")]
    public List<RectTransform> toReactUI;
    public List<Transform> toReact;

    [Header("ShakeAnimationSucces")]
    public float duration = 1;
    public Vector3 strenght;
    public int vibrato = 10;

    [Header("ShakeAnimationFail")]
    public float durationFail = 1;
    public Vector3 strenghtFail;
    public int vibratoFail = 10;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !firstInput)
        {
            //start the game
            textTuto.SetActive(false);
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
    Tween tween;
    public void MoveMachineSucess()
    {
        
        foreach (var obj in toReactUI)
        {

           obj.DOPunchScale(new Vector3(-0.1f, 0, 0f), duration, vibrato);

        }
        foreach (var obj in toReact)
        {
            obj.DOPunchScale(new Vector3(-0.1f, 0, 0f), duration, vibrato);
        }

    }
    public void MoveMachineFail()
    {
        foreach (var obj in toReactUI)
        {
            obj.DOPunchScale(strenghtFail, durationFail, vibratoFail);
        }
        foreach (var obj in toReact)
        {
            obj.DOPunchScale(strenghtFail, durationFail, vibratoFail);
        }
    }

}
