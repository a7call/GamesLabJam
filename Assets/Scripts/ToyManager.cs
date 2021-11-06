using System.Collections;
using DG.Tweening;
using UnityEngine;
using System;

public class ToyManager : Singleton<ToyManager>
{
    Toy currentSpawnedToy;
    

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
    [SerializeField] ToyType typeToGet;
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
        var goToDestroy = currentSpawnedToy.gameObject;
        goToDestroy.transform.DOShakeScale(duration, strenght, vibrato, randomness, fadeOut);
        goToDestroy.transform.DOMove(spawner.transform.position, duration).OnComplete(() => Destroy(goToDestroy));

    }


    void SpawnToy()
    {
        currentSpawnedToy = spawner.SpawnToy().GetComponent<Toy>();
        currentSpawnedToy.transform.DOShakeScale(duration, strenght, vibrato, randomness, fadeOut);
        currentSpawnedToy.transform.DOMove(machinePos.position, duration);
        if (currentSpawnedToy.type == typeToGet)
        {
            arrowSpawner.shouldSpawnDoubleArrow = true;
            return;
        }
    }


    public void SetRandomToyType()
    {
        var value = Enum.GetValues(typeof(ToyType));
        int random = UnityEngine.Random.Range(0, value.Length);
        typeToGet = (ToyType)value.GetValue(random);
        displayToy.SetDisplayToyToCatch(typeToGet);
    }
}
