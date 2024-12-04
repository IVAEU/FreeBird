using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPattern : ScriptableObject
{
    public enum TrackMode
    {
        TrackPlayer,
        Straight
    }
    
    protected enum ShootDir
    {
        Right,
        Left,
        Up,
        Down,
        None
    }
    
    public TrackMode BulletTrackMode;
    [SerializeField] protected ShootDir ShootDirection;
    public abstract List<Vector2> GetPatternInfo();
    
    public Vector2 GetShootDirection()
    {
        switch (ShootDirection)
        {
            case ShootDir.Right:
                return Vector2.right;
            case ShootDir.Left:
                return Vector2.left;
            case ShootDir.Up:
                return Vector2.up;
            case ShootDir.Down:
                return Vector2.down;
        }

        return Vector2.zero;
    }
}
