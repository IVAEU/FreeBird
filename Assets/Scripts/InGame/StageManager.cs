using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    [SerializeField] private Transform spawnPos;
    [SerializeField] private List<GameObject> playerObj = new List<GameObject>();
    private Transform _createdPlayer;
    [SerializeField] private EnemySpawner enemySpawner;
    private int _stageNum = 0;
    [SerializeField] private TextMeshProUGUI stageText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        CreatePlayer();
        StartCoroutine(GamePlay());
    }

    private void CreatePlayer()
    {
        int playerType = PlayerPrefs.GetInt("PlayerType");
        _createdPlayer = Instantiate(playerObj[playerType], spawnPos.position, Quaternion.identity).transform;
        BulletPatternExecutor executor = _createdPlayer.GetComponent<BulletPatternExecutor>();
        executor.Init(PoolManager.Instance.Bullet);
    }

    public Transform GetPlayerTransform()
    {
        return _createdPlayer;
    }

    private IEnumerator GamePlay()
    {
        _stageNum = 0;
        stageText.text = $"Stage: {_stageNum + 1}";
        
        for (int i = 0; i < 40; ++i)
        {
            yield return SpawnStage();
            yield return new WaitForSeconds(5f);
            _stageNum++;
            stageText.text = $"Stage: {_stageNum + 1}";
            if (_stageNum == 40)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    private IEnumerator SpawnStage()
    {
        for (int i = 0; i < 5; ++i)
        {
            enemySpawner.SpawnEnemyByRange(0, _stageNum/2 + 1);
            yield return new WaitForSeconds(1f);
        }
    }
}
