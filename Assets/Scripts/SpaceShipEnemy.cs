using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipEnemy : Enemy
{
    void Awake()
    {
        enemySpinSpeed = (Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
