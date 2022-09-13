using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;

    public bool gameStarted = false;

    private void Start()
    {
        gameStarted = false;
    }

    public void GameStarted()
    {
        gameStarted = true;
    }
}
