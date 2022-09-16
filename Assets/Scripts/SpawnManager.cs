using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private SpawnPooler spawnPooler;

    public bool gameStarted = false;

    private int enemyAsteriodNumber = 0;
    private int enemyAttackerNumber = 1;
    private float enemySpawnPosY = 10f;
    private float canSpawn = -1f;
    private float spawnRate = .5f;

    private GameObject enemyPrefabAsteriod;
    private GameObject enemyPrefabAttacker;

    // Start is called before the first frame update
    void Awake()
    {
        spawnPooler = SpawnPooler.spawnPooler;
        gameStarted = false;
    }

    private void FixedUpdate()
    {
        StartAsteriodSpawns();
        StartAttackerSpawn();
    }

    private void StartAsteriodSpawns()
    {
        if (gameStarted == true && Time.time > canSpawn)
        {
            canSpawn = Time.time + spawnRate;

            enemyPrefabAsteriod = SpawnPooler.spawnPooler.PooledEnemy(enemyAsteriodNumber);
            enemyPrefabAsteriod.transform.position = new Vector3(Random.Range(-9, 9), enemySpawnPosY, 0);
            enemyPrefabAsteriod.SetActive(true);
        }
    }

    private void StartAttackerSpawn()
    {
        if (gameStarted == true) // !attacker
        {
            enemyPrefabAttacker = SpawnPooler.spawnPooler.PooledEnemy(enemyAttackerNumber);
            enemyPrefabAttacker.transform.position = new Vector3(Random.Range(-9, 9), enemySpawnPosY, 0);
            enemyPrefabAttacker.SetActive(true);
        }
    }

    public void GameStarted()
    {
        gameStarted = true;
    }

}
