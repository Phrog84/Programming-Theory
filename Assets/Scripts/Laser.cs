using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 20f;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (gameObject.transform.position.y >= 6.5f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
