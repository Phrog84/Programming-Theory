using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    private SpawnManager _spawnManager;

    //private float _gameTime;

    /*private void Awake()
    {
        _gameTime = 0f;
    }*/

    private void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1);  // current game scene

            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        /*if (Time.timeScale = 10f)
        {

        }*/
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        _spawnManager._stopSpawning = false;
    }
}
