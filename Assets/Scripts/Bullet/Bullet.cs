using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private BulletPool _pool;
    private int _bulletDamage;
    private string _senderTag;

    public void Init(BulletPool bulletPool)
    {
        _pool = bulletPool;
    }
    
    public void SetBulletData(Vector2 dir, float spd, int damage, string tag)
    {
        rb.linearVelocity = dir.normalized * spd;
        _bulletDamage = damage;
        _senderTag = tag;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(_senderTag)) return;
        
        if (other.gameObject.TryGetComponent<HealthSystem>(out HealthSystem health))
        {
            health.TakeDamage(_bulletDamage);
        }
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        _pool.ReturnBulletToPool(this);
    }
}
