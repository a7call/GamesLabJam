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
                StartCoroutine(BeatableCo());
                Destroy(gameObject, 0.3f);                 
        });
    }
    IEnumerator BeatableCo()
    {
        yield return new WaitForSeconds(0.03f);
        SetBeatableFalse();
        if (!isHit)
        {
            if (arrowType == ArrowType.Down || arrowType == ArrowType.Up)
            {
                MissedInput();
            }
        }   
        image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 0), 0.2f);
    }

    void MissedInput()
    {
        ArrowSpawner.Instance.shouldUpBear = false;
        UfoClaw.Instance.GFX.DOMove(UfoClaw.Instance.UpPos.position, UfoClaw.Instance.moveDuration);
        ToyManager.Instance.ShuffleToys();
        ToyManager.Instance.SetRandomToyType();

        // LOOSELIFE 
        //NOT WORKING on perd deux pv dans le cas des arrow down et zéro dans l'autre ?????
        
        // BPMController.Instance.looseALife();

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
