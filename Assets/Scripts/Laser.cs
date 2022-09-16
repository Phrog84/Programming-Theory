using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float laserSpeed = 10f;

    private readonly string laserReset = "LaserReset";
    private readonly string enemy = "Enemy";

    private Vector3 direction = new Vector3(0, 1, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(laserSpeed * Time.fixedDeltaTime * direction);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(laserReset))
        {
            gameObject.SetActive(false);
        }
        if (other.CompareTag(enemy))
        {
            gameObject.SetActive(false);
        }
    }
}
