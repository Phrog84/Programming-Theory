using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _enemyPrefab;

    public GameObject _enemyLargePrefab;

    public GameObject _enemyContainer;

    public bool _stopSpawning = false;

    public GameObject[] powerUps;

    public GameObject[] enemys;

    public GameObject _light;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        //StartCoroutine(RotateLight());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9, 9), 7, 0);
            int randomEnemy = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(enemys[randomEnemy], posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(5f);
            Vector3 posToSpawn = new Vector3(Random.Range(-9, 9), 7, 0);
            int randomPowerUp = Random.Range(0, 4);
            Instantiate(powerUps[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 7));
        }
    }

    /*IEnumerator RotateLight()
    {
        yield return new WaitForSeconds(2f);

        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(1f);
            {
                _light.transform.rotation = Quaternion.Euler(0f, Random.Range(90f, 360f) * 200 * Time.deltaTime, 0f);
            }
        }
    }*/

    public void OnPlayerDead()
    {
        _stopSpawning = true;

        Time.timeScale = 0.25f;
    }
}
