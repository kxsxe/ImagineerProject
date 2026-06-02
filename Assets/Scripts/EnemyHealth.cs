using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("체력")]
    public int maxHealth = 3;

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
        if (roomManager != null)
        {
            roomManager.OnEnemyDead();
        }

        Destroy(gameObject);
    }
}