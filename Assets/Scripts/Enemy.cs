using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float enemySpinSpeed;
    public float canFire = -7f;
    public float fireRate = 2f;

    public GameObject enemyShape;
    public GameObject enemyLaserPrefab;
    public GameObject enemyLaserOrigin;

    private readonly string enemyReset = "EnemyReset";
    private readonly string laser = "Laser";

    public Vector3 direction = new Vector3(0, -1, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        EnemyAttack();
    }

    public virtual void Move()
    {
        transform.Translate(direction * enemySpeed * Time.fixedDeltaTime);
    }

    public virtual void EnemyAttack()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyReset))
        {
            gameObject.SetActive(false);
        }
        if (other.CompareTag(laser))
        {
            EnemyHit();
        }
    }

    public virtual void EnemyHit()
    {
        gameObject.SetActive(false);
    }

}
