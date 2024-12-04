using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private List<GameObject> enemyObjs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPos = new List<Transform>();

    public void SpawnEnemy(int enemyID, int spawnIndex)
    {
        GameObject eObj = Instantiate(enemyObjs[enemyID], spawnPos[spawnIndex].position, Quaternion.identity);
        BulletPatternExecutor executor = eObj.GetComponent<BulletPatternExecutor>();
        executor.Init(bulletPool);
    }
    
    public void SpawnFullRandom()
    {
        int enemyID = UnityEngine.Random.Range(0, enemyObjs.Count);
        int spawnIndex = UnityEngine.Random.Range(0, spawnPos.Count);
        SpawnEnemy(enemyID, spawnIndex);
    }
    
    public void SpawnEnemyInRandomPosition(int enemyID)
    {
        int spawnIndex = UnityEngine.Random.Range(0, spawnPos.Count);
        SpawnEnemy(enemyID, spawnIndex);
    }
    
    public void SpawnRandomEnemy(int spawnIndex)
    {
        int enemyID = UnityEngine.Random.Range(0, enemyObjs.Count);
        SpawnEnemy(enemyID, spawnIndex);
    }
    
    public void SpawnEnemyByRange(int min, int max)
    {
        int enemyID = UnityEngine.Random.Range(Mathf.Clamp(min, 0, enemyObjs.Count), Mathf.Clamp(max, 0, enemyObjs.Count));
        int spawnIndex = UnityEngine.Random.Range(0, spawnPos.Count);
        SpawnEnemy(enemyID, spawnIndex);
    }
}
