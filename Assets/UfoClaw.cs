using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UfoClaw : Singleton<UfoClaw>
{
    [Header("Claw")]
    public Transform GFX;
    public Transform downPos;
    public Transform UpPos;

    [Header("Animation")]
    public float moveDuration = 1f;

    [Header("Arrows")]
    [SerializeField] ArrowSpawner arrowSpawner;

    [SerializeField] DisplayToyToCatch displayToy;

    private Toy pickedToy;

    private bool catchable = false;
    public void TryGetToy()
    {
        // MOVE DOWN
        GFX.DOMove(downPos.position, moveDuration).OnComplete(() =>
        {
            catchable = true;
            ScoreToy();
        });
        
    }

    public void ScoreToy()
    {
        GFX.DOMove(UpPos.position, moveDuration).OnComplete(() =>
        {   
            Destroy(pickedToy.gameObject);

        });  
    }

    public void OnCollideWithToy(Collider2D collision)
    {
        if (collision.CompareTag("Toy") && catchable)
        {
            catchable = false;
            pickedToy = collision.GetComponent<Toy>();
            collision.transform.SetParent(GFX);
        }
        
    }
}
