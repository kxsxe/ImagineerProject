using UnityEngine;
using UnityEngine.InputSystem;

public class RewardChest : MonoBehaviour
{
    [Header("보상 설정")]
    public int coinReward = 3;

    private bool playerNearby = false;
    private bool opened = false;

    void Update()
    {
        if (opened)
        {
            return;
        }

        if (!playerNearby)
        {
            return;
        }

        if (Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        if (opened)
        {
            return;
        }

        opened = true;

        GameManager gameManager =
            FindAnyObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.AddCoin(coinReward);

            Debug.Log(
                "보상 상자를 열었습니다. 코인 "
                + coinReward
                + "개 획득!"
            );
        }
        else
        {
            Debug.LogError(
                "Scene에서 GameManager를 찾지 못했습니다."
            );
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;

            Debug.Log("E키를 눌러 보상 상자를 여세요.");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}