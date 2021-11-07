using System.Collections;
using DG.Tweening;
using UnityEngine;
using System;

public class ToyManager : Singleton<ToyManager>
{
    public Toy currentSpawnedToy;
    

    [Header("Spawner")]
    public ToySpawner spawner;
    public Transform machinePos;

    [Header("Shuffle Animation")]
    [SerializeField] float duration = 0.8f;
    [SerializeField] float strenght = 1;
    [SerializeField] int vibrato = 10;
    [SerializeField] float randomness = 90;
    [SerializeField] bool fadeOut = true;


    [Header("To Catch")]
    public ToyType typeToGet;
    [SerializeField] ArrowSpawner arrowSpawner;
    [SerializeField] DisplayToyToCatch displayToy;

    private void Start()
    {
        SetRandomToyType();
        SpawnToy();
    }

    public void ShuffleToys()
    {
        ReplaceToy();
        SpawnToy();
    }

    void ReplaceToy()
    {
      
       
        if (currentSpawnedToy != null)
        {
            if (currentSpawnedToy.isPicked)
            {
                currentSpawnedToy = null;
                return;
            }
            var goToDestroy = currentSpawnedToy.gameObject;
            goToDestroy.transform.DOShakeScale(duration, strenght, vibrato, randomness, fadeOut);
            goToDestroy.transform.DOMove(spawner.transform.position, duration).OnComplete(() => Destroy(goToDestroy, 0.5f));

        }
            
    }


    void SpawnToy()
    {
        currentSpawnedToy = spawner.SpawnToy().GetComponent<Toy>();
        currentSpawnedToy.transform.DOShakeScale(duration, strenght, vibrato, randomness, fadeOut);
        currentSpawnedToy.transform.DOMove(machinePos.position, duration);
    }

    public void ScorePickedToy()
    {
        currentSpawnedToy = null;
    }


    public void SetRandomToyType()
    {
        var value = Enum.GetValues(typeof(ToyType));
        int random = UnityEngine.Random.Range(0, value.Length);
        typeToGet = (ToyType)value.GetValue(random);
        displayToy.SetDisplayToyToCatch(typeToGet);
    }
}
