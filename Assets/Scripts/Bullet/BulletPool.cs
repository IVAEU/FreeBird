using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialPoolSize = 30; // 초기 풀 크기 설정

    private readonly Queue<Bullet> _bulletPool = new Queue<Bullet>();

    private void Awake()
    {
        // 싱글톤 패턴 유지
        if (Instance == null)
        {
            Instance = this;
            InitializePool();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializePool()
    {
        // 초기 풀 생성
        for (int i = 0; i < initialPoolSize; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform);
            bullet.gameObject.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }

    public Bullet SpawnBullet(Vector2 pos, Vector2 dir, float spd, int dmg, string tag)
    {
        // 풀에서 총알 가져오기
        Bullet bullet;
        if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool.Dequeue();
            bullet.transform.position = pos;
        }
        else
        {
            // 풀이 비어있다면 새 총알 생성
            bullet = Instantiate(bulletPrefab, transform);
        }

        // 총알 활성화 및 초기화
        bullet.gameObject.SetActive(true);
        bullet.Init(this);
        bullet.SetBulletData(dir, spd, dmg, tag);

        return bullet;
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        // 총알 비활성화 및 풀로 반환
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}
