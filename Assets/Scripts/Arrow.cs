using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InputType
{
    Left,
    Right,
    Down,
}
public class Arrow : MonoBehaviour
{
    BPMController BPMControllerInstance;
    Transform beatCounterUI;
    Image image;
    bool isPressable = false;
    public InputType arrowType;
    private void Awake()
    {
        DOTween.Init();
        BPMControllerInstance = BPMController.Instance;
        image = GetComponent<Image>();
        beatCounterUI = GameObject.FindGameObjectWithTag("BeatCounterUI").transform;
    }
    void Start()
    {
        transform.DOMove(beatCounterUI.position,BPMControllerInstance.beatInterval).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (gameObject.activeSelf)
            {
                image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 0), 0.2f).OnComplete(() => SetBeatableFalse());
                Destroy(gameObject, 0.3f);    
            }
            else
            {
                // SUCCESS
                // DO NOTHING
                Destroy(gameObject, 0.3f);
            }
               
        });
    }

    void SetBeatableTrue()
    {
        BPMControllerInstance.isBeatable = true;
        BPMControllerInstance.currentArrows.Add(this);
    }
    void SetBeatableFalse()
    {
        BPMControllerInstance.isBeatable = false;
        BPMControllerInstance.currentArrows.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetBeatableTrue();
    }

}
