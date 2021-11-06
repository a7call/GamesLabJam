using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : Singleton<ArrowSpawner>
{
    [Header("ArrowPrefabs")]
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject lefttArrow;
    [SerializeField] GameObject DowntArrow;
    [SerializeField] GameObject UpArrow;

    [Header("Spawner Positions")]
    [SerializeField] Transform leftSpawner;
    [SerializeField] Transform rightSpawner;

    public bool shouldSpawnDoubleArrow = false;
    public bool shouldUpBear { get; set; } = false;


    public void SpawnArrow()
    {
        if (rightArrow == null || lefttArrow == null || rightSpawner == null || leftSpawner == null)
        {
            Debug.LogError("Arrow prefabs or spawner are not set up");
            return;
        }

        if (shouldUpBear)
        {
            GameObject arrow = Instantiate(UpArrow, leftSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(leftSpawner);
            GameObject arrow2 = Instantiate(UpArrow, rightSpawner.position, Quaternion.identity);
            arrow2.transform.SetParent(rightSpawner);
            shouldUpBear = false;
            return;
        }

        if (shouldSpawnDoubleArrow)
        {
            GameObject arrow = Instantiate(DowntArrow, leftSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(leftSpawner);
            GameObject arrow2 = Instantiate(DowntArrow, rightSpawner.position, Quaternion.identity);
            arrow2.transform.SetParent(rightSpawner);
            shouldSpawnDoubleArrow = false;
            shouldUpBear = true;
            return;
        }

        var rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameObject arrow = Instantiate(lefttArrow, leftSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(leftSpawner);
        }
        else
        {
            GameObject arrow = Instantiate(rightArrow, rightSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(rightSpawner);
        }
    }
        
}

