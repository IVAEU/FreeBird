using System.Collections.Generic;
using UnityEngine;

public class BulletPatternExecutor : MonoBehaviour
{
    protected BulletPool bulletPool;
    
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected int bulletDamage;
    [SerializeField] protected float timeBtwSpawn;
    
    [SerializeField] private List<BulletPattern> patterns = new List<BulletPattern>();

    public virtual void Init(BulletPool pool)
    {
        bulletPool = pool;
    }

    public void SetPattern(List<BulletPattern> newPatterns)
    {
        patterns = new List<BulletPattern>();
        for (int i = 0; i < newPatterns.Count; ++i)
        {
            patterns.Add(newPatterns[i]);
        }
    }
    
    public void ExecuteRandomPattern()
    {
        int randIndex = Random.Range(0, patterns.Count);
        ExecutePattern(randIndex);
    }
    
    public void ExecutePattern(int index)
    {
        List<Vector2> pattern = patterns[index].GetPatternInfo(); //트래킹 정리 포함
        foreach (Vector2 p in pattern)
        {
            Vector2 dir;
            if (patterns[index].BulletTrackMode == BulletPattern.TrackMode.TrackPlayer)
            {
                Vector2 playerPos = StageManager.Instance.GetPlayerTransform().position;
                dir = playerPos - (Vector2)transform.position;
            }
            else
            {
                dir = patterns[index].GetShootDirection();
            }
            bulletPool.SpawnBullet(p + (Vector2)transform.position, dir, bulletSpeed, bulletDamage, gameObject.tag);
        }
    }
}
