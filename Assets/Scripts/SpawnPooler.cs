using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPooler : MonoBehaviour
{
    public static SpawnPooler spawnPooler;

    [SerializeField]
    private GameObject laserContainer;
    [SerializeField]
    private int laserAmount;
    private List<GameObject> laserPoolDefault;
    private List<GameObject> laserPoolAgile;
    private List<GameObject> laserPoolCharge;
    [SerializeField]
    private GameObject defalutLaserPrefab;
    [SerializeField]
    private GameObject agileLaserPrefab;
    [SerializeField]
    private GameObject chargeLaserPrefab;

    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private int enemyAmount;
    private List<GameObject> enemyPoolAsteroid;
    [SerializeField]
    private GameObject prefabEnemyAsteroid;
    private List<GameObject> enemyPoolAttacker;
    [SerializeField]
    private GameObject prefabEnemyAttacker;

    private void Awake()
    {
        if (spawnPooler == null)
        {
            spawnPooler = this;
        }
    }

    private void Start()
    {
        LaserPool();
        EnemyPool();
    }

    private void LaserPool()
    {
        PoolDefalutLaser();
        PoolAgileLaser();
        PoolChargeLaser();
    }

    private void EnemyPool()
    {
        PoolEnemyAsteroid();
        PoolEnemyAttacker();
    }

    private void PoolDefalutLaser()
    {
        laserPoolDefault = new List<GameObject>();

        for (int i = 0; i < laserAmount; i++)
        {
            GameObject obj = Instantiate(defalutLaserPrefab);
            obj.SetActive(false);
            laserPoolDefault.Add(obj);
            obj.transform.SetParent(laserContainer.transform);
        }
    }

    private void PoolAgileLaser()
    {
        laserPoolAgile = new List<GameObject>();

        for (int i = 0; i < laserAmount; i++)
        {
            GameObject obj = Instantiate(agileLaserPrefab);
            obj.SetActive(false);
            laserPoolAgile.Add(obj);
            obj.transform.SetParent(laserContainer.transform);
        }
    }

    private void PoolChargeLaser()
    {
        laserPoolCharge = new List<GameObject>();

        for (int i = 0; i < laserAmount; i++)
        {
            GameObject obj = Instantiate(chargeLaserPrefab);
            obj.SetActive(false);
            laserPoolCharge.Add(obj);
            obj.transform.SetParent(laserContainer.transform);
        }
    }

    private void PoolEnemyAsteroid()
    {
        enemyPoolAsteroid = new List<GameObject>();

        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject obj = Instantiate(prefabEnemyAsteroid);
            obj.SetActive(false);
            enemyPoolAsteroid.Add(obj);
            obj.transform.SetParent(enemyContainer.transform);
        }
    }

    private void PoolEnemyAttacker()
    {
        enemyPoolAttacker = new List<GameObject>();

        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject obj = Instantiate(prefabEnemyAttacker);
            obj.SetActive(false);
            enemyPoolAttacker.Add(obj);
            obj.transform.SetParent(enemyContainer.transform);
        }
    }

    public GameObject GetPooledLaser(int poolNumber)
    {
        switch (poolNumber)
        {
            case 0:
                for (int i = 0; i < laserPoolDefault.Count; i++)
                {
                    if (!laserPoolDefault[i].activeInHierarchy)
                    {
                        return laserPoolDefault[i];
                    }
                }
                break;
            case 1:
                for (int i = 0; i < laserPoolAgile.Count; i++)
                {
                    if (!laserPoolAgile[i].activeInHierarchy)
                    {
                        return laserPoolAgile[i];
                    }
                }
                break;
            case 2:
                for (int i = 0; i < laserPoolCharge.Count; i++)
                {
                    if (!laserPoolCharge[i].activeInHierarchy)
                    {
                        return laserPoolCharge[i];
                    }
                }
                break;

        }

        return null;
    }

    public GameObject PooledEnemy(int poolNumber)
    {
        switch (poolNumber)
        {
            case 0:
                for (int i = 0; i < enemyPoolAsteroid.Count; i++)
                {
                    if (!enemyPoolAsteroid[i].activeInHierarchy)
                    {
                        return enemyPoolAsteroid[i];
                    }
                }
                break;
            case 1:
                for (int i = 0; i < enemyPoolAttacker.Count; i++)
                {
                    if (!enemyPoolAttacker[i].activeInHierarchy)
                    {
                        return enemyPoolAttacker[i];
                    }
                }
                break;
            default:
                break;
        }

        return null;
    }

}
