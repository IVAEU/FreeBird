using UnityEngine;

public class PlayerMovement : BaseMovement
{
    public override void Move(Vector2 inputVec)
    {
        rb.linearVelocity = inputVec * moveSpeed;
    }
}
