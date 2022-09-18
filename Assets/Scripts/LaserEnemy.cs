using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    [SerializeField]
    private float laserSpeed = 10f;

    private readonly string enemyReset = "EnemyReset";

    private readonly Vector3 direction = new Vector3(0, -1, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(laserSpeed * Time.fixedDeltaTime * direction);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyReset))
        {
            gameObject.SetActive(false);
        }
    }
}
