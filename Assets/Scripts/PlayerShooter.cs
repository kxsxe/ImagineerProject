using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [Header("발사 설정")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private float fireTimer;

    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (Mouse.current.leftButton.isPressed && fireTimer <= 0)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab이 연결되지 않았습니다. Player의 PlayerShooter 컴포넌트에 Bullet 프리팹을 넣어주세요.");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("Fire Point가 연결되지 않았습니다. Player의 PlayerShooter 컴포넌트에 FirePoint를 넣어주세요.");
            return;
        }

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript == null)
        {
            Debug.LogError("Bullet 프리팹에 Bullet.cs가 붙어있지 않습니다.");
            return;
        }

        Vector2 shootDirection = firePoint.right;
        bulletScript.SetDirection(shootDirection);
    }
}