using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private void Update()
    {
  

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
        else if (Input.anyKeyDown && !BPMController.Instance.isBeatable)
        {
            Debug.Log("OFF BEAT");
            //DO OFFBEAT CODE HERE
        }
       
    }
}
