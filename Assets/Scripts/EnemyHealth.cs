using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("체력")]
    public int maxHealth = 3;

    [Header("드롭 설정")]
    public GameObject coinPrefab;
    public float coinDropChance = 1f;

    private int currentHealth;
    private RoomManager roomManager;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetRoomManager(RoomManager manager)
    {
        roomManager = manager;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy 현재 체력: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DropCoin();

        if (roomManager != null)
        {
            roomManager.OnEnemyDead();
        }

        Destroy(gameObject);
    }

    void DropCoin()
    {
        if (coinPrefab == null)
        {
            Debug.LogWarning("EnemyHealth에 Coin Prefab이 연결되지 않았습니다.");
            return;
        }

        if (Random.value <= coinDropChance)
        {
            Instantiate(
                coinPrefab,
                transform.position,
                Quaternion.identity
            );
        }
    }
}