using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float enemySpinSpeed;

    public GameObject enemyShape;

    private readonly string enemyReset = "EnemyReset";
    private readonly string laser = "Laser";

    public Vector3 direction = new Vector3(0, -1, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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
