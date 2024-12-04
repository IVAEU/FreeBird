using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "BulletPattern/Straight")]
public class StraightPattern : BulletPattern
{
    enum ExpendDirection
    {
        Horizontal,
        Vertical,
        Right,
        Left,
        Up,
        Down
    }

    [SerializeField] private Vector2 spawnOffset;
    [SerializeField] private ExpendDirection expendDir;
    [SerializeField] private float expendDistance;
    [SerializeField] private int bulletAmount = 1;

    public override List<Vector2> GetPatternInfo()
    {
        List<Vector2> bulletPos = new List<Vector2>();
        for(int i = 0; i < bulletAmount; i++)
        {
            Vector2 spawnPos = Vector2.zero;
            
            switch (expendDir)
            {
                case ExpendDirection.Horizontal:
                    if (bulletAmount % 2.0f == 0)
                    {//Even
                        spawnPos = 
                            ((spawnOffset + Vector2.right * (expendDistance / 2)) + Vector2.left * (expendDistance * bulletAmount / 2)) 
                            + Vector2.right * (expendDistance * i);
                    }
                    else
                    {//Odd
                        spawnPos = 
                            (spawnOffset + Vector2.left * (expendDistance * (bulletAmount / 2))) 
                            + Vector2.right * (expendDistance * i);
                    }
                    break;
                case ExpendDirection.Vertical:
                    if (bulletAmount % 2.0f == 0)
                    {//Even
                        spawnPos = 
                            ((spawnOffset + Vector2.up * (expendDistance / 2)) + Vector2.down * (expendDistance * bulletAmount / 2)) 
                            + Vector2.up * (expendDistance * i);
                    }
                    else
                    {//Odd
                        spawnPos = 
                            (spawnOffset + Vector2.down * (expendDistance * (bulletAmount / 2))) 
                            + Vector2.up * (expendDistance * i);
                    }
                    break;
                case ExpendDirection.Right:
                    spawnPos = spawnOffset + Vector2.right * (expendDistance * i);
                    break;
                case ExpendDirection.Left:
                    spawnPos = spawnOffset + Vector2.left * (expendDistance * i);
                    break;
                case ExpendDirection.Up:
                    spawnPos = spawnOffset + Vector2.up * (expendDistance * i);
                    break;
                case ExpendDirection.Down:
                    spawnPos = spawnOffset + Vector2.down * (expendDistance * i);
                    break;
            }
            bulletPos.Add(spawnPos);
        }

        return bulletPos;
    }
}
