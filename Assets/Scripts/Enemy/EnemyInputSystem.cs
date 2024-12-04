using System;
using UnityEngine;

public class EnemyInputSystem : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    
    public Vector2 GetInputVec()
    {
        return moveDirection.normalized;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            moveDirection = new Vector2(moveDirection.x, -moveDirection.y);
        }
    }
}
