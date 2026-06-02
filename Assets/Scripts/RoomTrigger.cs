using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public RoomManager roomManager;

    private bool activated = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            activated = true;

            if (roomManager != null)
            {
                roomManager.ActivateRoom();
            }
            else
            {
                Debug.LogWarning("RoomTrigger에 RoomManager가 연결되지 않았습니다.");
            }
        }
    }
}