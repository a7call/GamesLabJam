using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ArrowType
{
    Left,
    Right,
    Down,
    Up
}
public class Arrow : MonoBehaviour
{
    BPMController BPMControllerInstance;
    Transform beatCounterUI;
    Image image;
    public ArrowType arrowType;
    public bool isHit = false;
    public bool isActivated = true;

    public Material glowMat;
    private void Awake()
    {
        DOTween.Init();
        BPMControllerInstance = BPMController.Instance;
        image = GetComponent<Image>();
        beatCounterUI = GameObject.FindGameObjectWithTag("BeatCounterUI").transform;
    }
    void Start()
    {
        transform.DOMove(beatCounterUI.position,BPMControllerInstance.beatInterval - BPMControllerInstance.beatTimer).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (isActivated)
            {
                StartCoroutine(BeatableCo());              
            }
            image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 0), 0.2f);
            Destroy(gameObject, 0.3f);
        });
    }
    IEnumerator BeatableCo()
    {
        yield return new WaitForSeconds(0.03f);
        SetBeatableFalse();
        if (!isHit)
        {
            if (arrowType == ArrowType.Down)
            {
                MissedInput();
            }
        }   

    }

    void MissedInput()
    {
        UfoClaw.Instance.GFX.DOMove(UfoClaw.Instance.UpPos.position, UfoClaw.Instance.moveDuration);
        ToyManager.Instance.ShuffleToys();
        // LOOSELIFE
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
        GetComponent<Image>().material = glowMat;
    }

}
