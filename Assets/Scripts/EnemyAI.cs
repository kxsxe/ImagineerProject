using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("추적 속도")]
    public float moveSpeed = 2.5f;

    private Transform player;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj == null)
        {
            Debug.LogError("Player 태그가 붙은 오브젝트를 찾지 못했습니다.");
            return;
        }

        player = playerObj.transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = player.position - transform.position;
        direction = direction.normalized;

        rb.linearVelocity = direction * moveSpeed;
    }
}