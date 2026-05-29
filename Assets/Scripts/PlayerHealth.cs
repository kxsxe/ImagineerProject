using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("체력 설정")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("무적 시간")]
    public float invincibleTime = 1f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;
    private UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();

        uiManager = FindAnyObjectByType<UIManager>();

        if (uiManager != null)
        {
            uiManager.UpdateHP(currentHealth, maxHealth);
        }

        Debug.Log("플레이어 체력: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        Debug.Log("플레이어 현재 체력: " + currentHealth);

        if (uiManager != null)
        {
            uiManager.UpdateHP(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(InvincibleCoroutine());
    }

    System.Collections.IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;

        float timer = 0f;

        while (timer < invincibleTime)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }

            timer += 0.1f;

            yield return new WaitForSeconds(0.1f);
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("플레이어 사망");

        if (uiManager != null)
        {
            uiManager.ShowGameOver();
        }

        GameManager gameManager =
            FindAnyObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.GameOver();
        }

        gameObject.SetActive(false);
    }
}