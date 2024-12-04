using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    private Vector2 _moveInput;
    
    public Vector2 GetMoveInput()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        return _moveInput;
    }
    
    public bool GetAttackInput()
    {
        return Input.GetButtonDown("Fire1");
    }
}
