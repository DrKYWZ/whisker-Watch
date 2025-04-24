using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnTime = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnTime);
    }

    void SpawnObject()
    {
        float randomSide = Random.Range(0, 2);
        Vector3 spawnPosition = new Vector3(randomSide == 0 ? -10 : 10, Random.Range(-4f, 4f), 0);
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }    
}
