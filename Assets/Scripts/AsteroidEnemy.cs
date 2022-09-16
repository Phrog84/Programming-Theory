using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEnemy : Enemy
{
    public float asteriodSpeedMin = .5f;
    public float asteriodSpeedMax = 2f;

    void Awake()
    {
        enemySpinSpeed = (Random.Range(0, 100));
        enemySpeed = (Random.Range(asteriodSpeedMin, asteriodSpeedMax));
    }

    public override void Move()
    {
        transform.Translate(direction * enemySpeed * Time.fixedDeltaTime);
        enemyShape.transform.Rotate(enemySpinSpeed * Time.deltaTime, enemySpinSpeed * Time.deltaTime,
            enemySpinSpeed * Time.deltaTime, Space.Self);
    }
}
