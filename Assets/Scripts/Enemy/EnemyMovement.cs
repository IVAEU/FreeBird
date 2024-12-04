using System;
using UnityEngine;

public class EnemyMovement : BaseMovement
{
    public override void Move(Vector2 inputVec)
    {
        rb.linearVelocity = inputVec * moveSpeed;
    }
}
