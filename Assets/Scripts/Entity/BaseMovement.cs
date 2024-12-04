using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float moveSpeed;
    
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public abstract void Move(Vector2 inputVec);
}
