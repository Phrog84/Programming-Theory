using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPooler : MonoBehaviour
{
    public static SpawnPooler spawnPooler;

    [SerializeField]
    private GameObject laserContainer;

    private List<GameObject> laserPoolDefault;
    private List<GameObject> laserPoolAgile;
    private List<GameObject> laserPoolCharge;
    [SerializeField]
    private int laserAmount;
    [SerializeField]
    private GameObject defalutLaserPrefab;
    [SerializeField]
    private GameObject agileLaserPrefab;
    [SerializeField]
    private GameObject chargeLaserPrefab;

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
    }

    private void LaserPool()
    {
        PoolDefalutLaser();
        PoolAgileLaser();
        PoolChargeLaser();
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

}
