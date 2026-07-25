using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("방 클리어 UI")]
    public GameObject roomClearText;

    [Header("적 설정")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemyCount = 3;

    [Header("문 설정")]
    public Door door;

    [Header("보상 설정")]
    public GameObject rewardChestPrefab;
    public Transform rewardSpawnPoint;

    private int aliveEnemyCount;
    private bool roomCleared = false;
    private bool hasStarted = false;
    private bool rewardSpawned = false;

    void Start()
    {
        CloseDoor();
    }

    public void ActivateRoom()
    {
        if (hasStarted)
        {
            return;
        }

        hasStarted = true;
        roomCleared = false;

        if (roomClearText != null)
        {
            roomClearText.SetActive(false);
        }

        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError(
                gameObject.name
                + ": Enemy Prefab이 연결되지 않았습니다."
            );

            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError(
                gameObject.name
                + ": Spawn Points가 연결되지 않았습니다."
            );

            return;
        }

        aliveEnemyCount = enemyCount;

        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawnPoint =
                spawnPoints[i % spawnPoints.Length];

            GameObject enemy = Instantiate(
                enemyPrefab,
                spawnPoint.position,
                Quaternion.identity
            );

            EnemyHealth enemyHealth =
                enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.SetRoomManager(this);
            }
            else
            {
                Debug.LogError(
                    "생성된 Enemy에 EnemyHealth가 없습니다."
                );
            }
        }

        Debug.Log(
            gameObject.name
            + " 적 생성 완료: "
            + aliveEnemyCount
        );
    }

    public void OnEnemyDead()
    {
        aliveEnemyCount--;

        Debug.Log(
            gameObject.name
            + " 남은 적 수: "
            + aliveEnemyCount
        );

        if (aliveEnemyCount <= 0 && !roomCleared)
        {
            RoomClear();
        }
    }

    void RoomClear()
    {
        roomCleared = true;

        Debug.Log(gameObject.name + " ROOM CLEAR!");

        if (roomClearText != null)
        {
            roomClearText.SetActive(true);
        }

        SpawnReward();
        OpenDoor();
    }

    void SpawnReward()
    {
        if (rewardSpawned)
        {
            return;
        }

        if (rewardChestPrefab == null)
        {
            Debug.LogWarning(
                gameObject.name
                + ": Reward Chest Prefab이 연결되지 않았습니다."
            );

            return;
        }

        if (rewardSpawnPoint == null)
        {
            Debug.LogWarning(
                gameObject.name
                + ": Reward Spawn Point가 연결되지 않았습니다."
            );

            return;
        }

        rewardSpawned = true;

        Instantiate(
            rewardChestPrefab,
            rewardSpawnPoint.position,
            Quaternion.identity
        );

        Debug.Log(gameObject.name + " 보상 상자 생성!");
    }

    void CloseDoor()
    {
        if (door != null)
        {
            door.CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.OpenDoor();
        }
    }
}