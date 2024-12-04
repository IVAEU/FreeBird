using UnityEngine;

public class PatternAutoExcuter : BulletPatternExecutor
{
    protected float PreviousSpawnTime = 0;
    
    public override void Init(BulletPool pool)
    {
        base.Init(pool);
        PreviousSpawnTime = Time.time;
    }

    protected void Update()
    {
        if (Time.time > PreviousSpawnTime + timeBtwSpawn)
        {
            ExecuteRandomPattern();
            PreviousSpawnTime = Time.time;
        }
    }
}
