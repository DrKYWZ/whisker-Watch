using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public float spawnInterval = 2f;

    private GameObject cat;

    void Start()
    {
        cat = GameObject.FindGameObjectWithTag("Cat"); // Pastikan kucing punya tag "Cat"
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Pilih sisi kiri atau kanan secara acak
        bool spawnLeft = Random.value > 0.5f;
        Transform spawnPoint = spawnLeft ? leftSpawnPoint : rightSpawnPoint;

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Atur arah hadap enemy
        Vector3 scale = enemy.transform.localScale;
        scale.x = spawnLeft ? 1 : -1;
        enemy.transform.localScale = scale;
    }
}