using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgileSpaceShip : SpaceShip
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
