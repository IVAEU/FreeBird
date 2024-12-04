using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int curHealth;
    [SerializeField] private int maxHealth;
    public Action<int> HealthDamaged;
    public Action OnDeath;

    public void Init()
    {
        maxHealth = curHealth;
    }
    
    public void Init(int health)
    {
        maxHealth = health;
        curHealth = health;
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        
        if (curHealth > 0)
        {
            HealthDamaged?.Invoke(curHealth);
        }
        else
        {
            OnDeath?.Invoke();
        }
    }
}
