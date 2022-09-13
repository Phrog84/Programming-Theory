using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private UIManager uIManager;
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
    }

    public void GameStarted()
    {
        gameStarted = true;
        uIManager.GameStarted();
        playerController.GameStarted();
    }
}
