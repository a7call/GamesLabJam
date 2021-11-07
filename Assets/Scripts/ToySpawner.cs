using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToySpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public List<GameObject> toys;
    public static int previousRand;

    public GameObject SpawnToy()
    {
        var rand = Random.Range(0, toys.Count);
      
        //while (rand == previousRand)
        //{
        //    rand = Random.Range(0, toys.Count);
        //}
        //previousRand = rand;
        var prefabToSpawn = toys[rand];    
        GameObject spawnedToy = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        return spawnedToy;
    }
}
