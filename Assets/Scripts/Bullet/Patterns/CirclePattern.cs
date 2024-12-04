using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/Circle")]
public class CirclePattern : BulletPattern
{
    [Tooltip("Default set to Zero(right)")]
    [SerializeField] protected float offsetDegree = 0;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected int bulletAmount = 0;

    public override List<Vector2> GetPatternInfo()
    {
        List<Vector2> bulletPos = new List<Vector2>();
        Vector2 playerPos = Vector2.zero; //중앙 기준 생성
        float degreeInterval = 360.0f / bulletAmount;
        for(int i = 0; i < bulletAmount; i++)
        {
            float degree = offsetDegree + i * degreeInterval;
            float xPos = Mathf.Cos(degree * Mathf.Deg2Rad);
            float yPos = Mathf.Sin(degree * Mathf.Deg2Rad);
            bulletPos.Add(new Vector2(xPos, yPos) * distance + playerPos);
        }

        return bulletPos;
    }
}
