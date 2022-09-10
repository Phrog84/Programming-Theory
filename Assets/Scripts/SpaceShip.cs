using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _laserOrigin;

    [SerializeField]
    private float _canFire = -.5f;
    [SerializeField]
    private float _fireRate = .5f;
    
    public virtual void FireLaser()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            LaserDamage();
        }
    }

    public virtual void LaserDamage()
    {
        Instantiate(_laserPrefab, _laserOrigin.transform.position, Quaternion.identity);
        _canFire = Time.time + _fireRate;
    }

    /*public virtual void SetShipSpeed()
    {
        GetComponent<PlayerController>().ShipSpeed(speed);
    }*/
}
