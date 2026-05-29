using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy 프리팹")]
    public GameObject enemyPrefab;

    [Header("생성 설정")]
    public float spawnInterval = 3f;
    public float spawnRange = 8f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomPosition =
            (Vector2)transform.position +
            Random.insideUnitCircle * spawnRange;

        Instantiate(
            enemyPrefab,
            randomPosition,
            Quaternion.identity
        );
    }
}