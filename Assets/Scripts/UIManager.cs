using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("체력 텍스트")]
    public TextMeshProUGUI hpText;

    [Header("코인 텍스트")]
    public TextMeshProUGUI coinText;

    [Header("게임오버 텍스트")]
    public GameObject gameOverText;

    public void UpdateHP(int currentHP, int maxHP)
    {
        if (hpText == null)
        {
            Debug.LogError("HPText 연결 안 됨");
            return;
        }

        hpText.text = "HP: " + currentHP + " / " + maxHP;
    }

    public void UpdateCoin(int coin)
    {
        if (coinText == null)
        {
            Debug.LogError("CoinText 연결 안 됨");
            return;
        }

        coinText.text = "Coin: " + coin;
    }

    public void ShowGameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }
}