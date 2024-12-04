using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerInputSystem _inputSystem;
    private PlayerMovement _playerMovement;
    private BulletPatternExecutor _patternExecutor;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _inputSystem = GetComponent<PlayerInputSystem>();
        _playerMovement = GetComponent<PlayerMovement>();
        _patternExecutor = GetComponent<BulletPatternExecutor>();
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        _healthSystem.OnDeath += DeathSequence;
    }

    public void Update()
    {
        _playerMovement.Move(_inputSystem.GetMoveInput());

        if (_inputSystem.GetAttackInput())
        {
            _patternExecutor.ExecutePattern(0); 
        }
    }

    private void DeathSequence()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void OnDestroy()
    {
        _healthSystem.OnDeath -= DeathSequence;
    }
}
