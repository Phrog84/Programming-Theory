using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed = 10f;

    [SerializeField]
    private GameObject enemyShape;

    private readonly string enemyReset = "EnemyReset";
    private readonly string laser = "Laser";

    private Vector3 direction = new Vector3(0, -1, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void EnemyMove()
    {
        transform.Translate(direction * enemySpeed * Time.fixedDeltaTime);

        enemyShape.transform.rotation = Quaternion.Euler(45, 0, 45);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyReset))
        {
            gameObject.SetActive(false);
        }
        if (other.CompareTag(laser))
        {
            gameObject.SetActive(false);
        }
    }

}
