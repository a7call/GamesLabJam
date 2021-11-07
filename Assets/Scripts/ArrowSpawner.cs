using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : Singleton<ArrowSpawner>
{
    [Header("ArrowPrefabs")]
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject lefttArrow;
    [SerializeField] GameObject DowntArrow;

    [Header("Spawner Positions")]
    [SerializeField] RectTransform leftSpawner;
    [SerializeField] RectTransform rightSpawner;

    public bool shouldSpawnDoubleArrow { get; set; }
    public bool shouldUpBear { get; set; } = false;


    public IEnumerator SpawnArrow()
    {
        if (rightArrow == null || lefttArrow == null || rightSpawner == null || leftSpawner == null)
        {
            Debug.LogError("Arrow prefabs or spawner are not set up");
            yield break ;
        }

        //if (shouldUpBear)
        //{
        //    GameObject arrow = Instantiate(UpArrow, leftSpawner.position, Quaternion.identity);
        //    arrow.transform.SetParent(leftSpawner);
        //    GameObject arrow2 = Instantiate(UpArrow, rightSpawner.position, Quaternion.identity);
        //    arrow2.transform.SetParent(rightSpawner);
        //    shouldUpBear = false;
        //    return;
        //}
        yield return new WaitForSeconds(0.05f);
        var currentSpawnedToy = ToyManager.Instance.currentSpawnedToy;
        if (currentSpawnedToy != null)
        {
            if (ToyManager.Instance.currentSpawnedToy.type == ToyManager.Instance.typeToGet)
            {
                shouldSpawnDoubleArrow = true;
            }
        }
        

        if (shouldSpawnDoubleArrow)
        {
            GameObject arrow = Instantiate(DowntArrow, leftSpawner.position, Quaternion.identity);
            arrow.transform.SetParent(leftSpawner);
            var mRect = arrow.GetComponent<RectTransform>();
            mRect.anchorMin = new Vector2(0, 0);
            mRect.anchorMax = new Vector2(1, 1);
            mRect.pivot = new Vector2(0.5f, 0.5f);
            mRect.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            GameObject arrow2 = Instantiate(DowntArrow, rightSpawner.position, Quaternion.identity);
            arrow2.transform.SetParent(rightSpawner);
            var mRect2 = arrow2.GetComponent<RectTransform>();
            mRect2.anchorMin = new Vector2(0, 0);
            mRect2.anchorMax = new Vector2(1, 1);
            mRect2.pivot = new Vector2(0.5f, 0.5f);
            mRect2.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            arrow2.GetComponent<Arrow>().isActivated = false;
            shouldSpawnDoubleArrow = false;
            yield break;
        }

        var rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameObject arrow = Instantiate(lefttArrow, leftSpawner.position, lefttArrow.transform.rotation);
            arrow.transform.SetParent(leftSpawner);
            var mRect = arrow.GetComponent<RectTransform>();
            mRect.anchorMin = new Vector2(0, 0);
            mRect.anchorMax = new Vector2(1, 1);
            mRect.pivot = new Vector2(0.5f, 0.5f);
            mRect.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            GameObject arrow = Instantiate(rightArrow, rightSpawner.position, rightArrow.transform.rotation);
            arrow.transform.SetParent(rightSpawner);
            var mRect = arrow.GetComponent<RectTransform>();
            mRect.anchorMin = new Vector2(0, 0);
            mRect.anchorMax = new Vector2(1, 1);
            mRect.pivot = new Vector2(0.5f, 0.5f);
            mRect.localScale = new Vector3(1, 1, 1);
        }
    }
        
}

