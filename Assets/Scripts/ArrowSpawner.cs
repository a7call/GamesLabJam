using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [Header("ArrowPrefabs")]
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject lefttArrow;
    [SerializeField] GameObject DowntArrow;

    [Header("Spawner Positions")]
    [SerializeField] Transform leftSpawner;
    [SerializeField] Transform rightSpawner;


    public void SpawnArrow()
    {
        if (rightArrow == null || lefttArrow == null || rightSpawner == null || leftSpawner == null)
        {
            Debug.LogError("Arrow prefabs or spawner are not set up");
            return;
        }

        var rand = Random.Range(0, 3);
        if (rand == 0)
        {
            GameObject arrow = Instantiate(lefttArrow, leftSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(leftSpawner);
        }
        else if(rand == 1)
        {
            GameObject arrow = Instantiate(rightArrow, rightSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(rightSpawner);
        }
        else
        {
            GameObject arrow = Instantiate(DowntArrow, leftSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(leftSpawner);
            GameObject arrow2 = Instantiate(DowntArrow, rightSpawner.position, Quaternion.identity);
            arrow2.transform.SetParent(rightSpawner);
        }

    }
}
