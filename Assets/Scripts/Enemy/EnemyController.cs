using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyInputSystem _inputSystem;
    private EnemyMovement _enemyMovement;
    private HealthSystem _healthSystem;
    
    private void Awake()
    {
        _inputSystem = GetComponent<EnemyInputSystem>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        _healthSystem.OnDeath += DeathSequence;
    }
    
    private void Update()
    {
        _enemyMovement.Move(_inputSystem.GetInputVec());
    }
    
    private void DeathSequence()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _healthSystem.OnDeath -= DeathSequence;
    }
}
