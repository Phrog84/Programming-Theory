using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public PlayerController playerController;

    public float speed;

    public GameObject laserPrefab;
    public GameObject laserOrigin;

    public float canFire;
    public float fireRate;

    public int poolNumber;

    public virtual void SetShipSpeed()
    {
        playerController.ShipSpeed(speed);
    }

    public virtual void SetShipLaserPrefab()
    {
        playerController.ShipLaser(laserPrefab);
    }

    public virtual void SetShipLaserOrgin()
    {
        playerController.ShipLaserOrgiin(laserOrigin);
    }

    public virtual void SetPoolNumber()
    {
        playerController.ShipLaserPool(poolNumber);
    }

    public virtual void SetShipCanFire()
    {
        playerController.ShipCanFire(canFire);
    }

    public virtual void SetShipFireRate()
    {
        playerController.ShipFireRate(fireRate);
    }
}
