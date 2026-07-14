using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    private int coin = 0;

    private UIManager uiManager;

    void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();

        if (uiManager != null)
        {
            uiManager.UpdateCoin(coin);
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                RestartGame();
            }
        }
    }

    public void AddCoin(int amount)
    {
        coin += amount;

        if (uiManager != null)
        {
            uiManager.UpdateCoin(coin);
        }

        Debug.Log("현재 코인: " + coin);
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("게임 오버");
    }

    void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}