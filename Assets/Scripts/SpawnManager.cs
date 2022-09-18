using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(100)]
public class SpawnManager : MonoBehaviour
{
    private SpawnPooler spawnPooler;

    public static SpawnManager spawnManager;

    public bool gameStarted = false;

    private int enemyAsteriodNumber = 0;
    private int enemyAttackerNumber = 1;
    private float enemySpawnPosY = 15f;
    private float canAsteriodSpawn = -1f;
    private float canSpawnAttacker = 10f;
    private float spawnAttackerRate = 7f;
    private float spawnAsteriodRate = .5f;

    private GameObject enemyPrefabAsteriod;
    private GameObject enemyPrefabAttacker;

    public bool attackerSpawn;

    private void Awake()
    {
        if (spawnManager == null)
        {
            spawnManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPooler = SpawnPooler.spawnPooler;
        gameStarted = false;
        attackerSpawn = true;
    }

    private void FixedUpdate()
    {
        StartAsteriodSpawns();
        StartAttackerSpawn();
    }

    public void GameStarted()
    {
        gameStarted = true;
    }

    private void StartAsteriodSpawns()
    {
        if (gameStarted == true && Time.time > canAsteriodSpawn)
        {
            canAsteriodSpawn = Time.time + spawnAsteriodRate;

            enemyPrefabAsteriod = SpawnPooler.spawnPooler.PooledEnemy(enemyAsteriodNumber);
            enemyPrefabAsteriod.transform.position = new Vector3(Random.Range(-13, 13), enemySpawnPosY, 0);
            enemyPrefabAsteriod.SetActive(true);
        }
    }

    private void StartAttackerSpawn()
    {
        if (gameStarted == true)
        {
            if (Time.time > canSpawnAttacker)
            {
                canSpawnAttacker = Time.time + spawnAttackerRate;

                if (attackerSpawn == true)
                {
                    attackerSpawn = false;
                    enemyPrefabAttacker = SpawnPooler.spawnPooler.PooledEnemy(enemyAttackerNumber);
                    enemyPrefabAttacker.transform.position = new Vector3(Random.Range(-12, 12), enemySpawnPosY, 0);
                    enemyPrefabAttacker.SetActive(true);
                }
                else if (attackerSpawn == false)
                {
                    return;
                }
            }
        }
    }

    public void AttackerSpawned(bool canSpawn)
    {
        attackerSpawn = canSpawn;
    }
}
