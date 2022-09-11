using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpaceShip : SpaceShip
{
    private void Awake()
    {
        SetShipSpeed();
        SetShipLaserPrefab();
        SetShipLaserOrgin();
        SetPoolNumber();
        SetShipCanFire();
        SetShipFireRate();
    }

}
