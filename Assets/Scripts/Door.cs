using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("이동 설정")]
    public Transform targetPoint;

    private Collider2D doorCollider;
    private SpriteRenderer spriteRenderer;

    private bool isOpen = false;

    void Awake()
    {
        doorCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CloseDoor()
    {
        isOpen = false;

        if (doorCollider != null)
        {
            doorCollider.isTrigger = false;
            doorCollider.enabled = true;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
        }

        Debug.Log("문 닫힘");
    }

    public void OpenDoor()
    {
        isOpen = true;

        if (doorCollider != null)
        {
            doorCollider.isTrigger = true;
            doorCollider.enabled = true;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.green;
        }

        Debug.Log("문 열림");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen) return;

        if (collision.CompareTag("Player"))
        {
            if (targetPoint != null)
            {
                collision.transform.position = targetPoint.position;
            }
            else
            {
                Debug.LogWarning("Door의 Target Point가 연결되지 않았습니다.");
            }
        }
    }
}