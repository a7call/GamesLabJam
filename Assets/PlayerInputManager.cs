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
    public RectTransform machine;
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
            BPMController.Instance.looseALife();
        }
       
    }

}
