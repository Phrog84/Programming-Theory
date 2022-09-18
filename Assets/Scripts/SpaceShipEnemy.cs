using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipEnemy : Enemy
{
    private SpawnManager spawnManager;
    private SpawnPooler spawnPooler;

    private Player player;
    private Vector3 playerPos;
    private readonly string playerTag = "Player";
    private readonly int yClamp = 6;
    private float enemyOffset;
    public float offsetAmount = 1.2f;
    private readonly int laserPoolNumber = 0;

    public bool enemySpanwed;

    private void Awake()
    {
        enemySpanwed = false;
        enemySpeed = Random.Range(.5f, 1.5f);
        enemyOffset = Random.Range(-offsetAmount, offsetAmount);
    }

    void Start()
    {
        spawnManager = SpawnManager.spawnManager;
        spawnPooler = SpawnPooler.spawnPooler;
        player = GameObject.FindWithTag(playerTag).GetComponent<Player>();
        spawnManager.AttackerSpawned(enemySpanwed = false);
    }

    public override void Move()
    {
        playerPos = new Vector3(player.transform.position.x + enemyOffset, Mathf.Abs(yClamp), 0);

        transform.position = Vector3.Lerp(transform.position, playerPos, enemySpeed * Time.deltaTime);
    }

    public override void EnemyAttack()
    {
        if (Time.time > canFire)
        {
            canFire = Time.time + fireRate;
            enemyLaserPrefab = spawnPooler.PooledEnemyLaser(laserPoolNumber);
            enemyLaserPrefab.transform.position = enemyLaserOrigin.transform.position;
            enemyLaserPrefab.SetActive(true);
        }
    }

    public override void EnemyHit()
    {
        spawnManager.AttackerSpawned(enemySpanwed = true);
        gameObject.SetActive(false);
    }
}
