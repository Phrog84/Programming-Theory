using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpawnPooler spawnPooler;

    private readonly string hor = "Horizontal";
    private readonly string ver = "Vertical";


    public GameObject spaceShip;
    private Vector3 center;

    public float speed = 8f;
    
    private float _xClamp = 9;
    private float _yClamp = 5;

    public float tiltDirection = 45f;


    public GameObject playerLaserPrefab;
    public GameObject playerLaserOrigin;
    public int poolNumber;

    public float canFire = -.5f;
    public float fireRate = .5f;

    private void Start()
    {
        spawnPooler = SpawnPooler.spawnPooler;
    }

    private void FixedUpdate()
    {
        MoveSpaceShip();
        FireLaser();
    }

    private void MoveSpaceShip()
    {
        float horizontalInput = Input.GetAxisRaw(hor);
        float verticalInput = Input.GetAxisRaw(ver);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        Quaternion shipCenter = Quaternion.Euler(0, 0, 0);
        Quaternion shipTiltRight = Quaternion.Euler(0, 0, tiltDirection);
        Quaternion shipTiltLeft = Quaternion.Euler(0, 0, -tiltDirection);

        transform.Translate(speed * Time.deltaTime * direction);
        // spaceShip.transform.rotation = Quaternion.Slerp(shipCenter, (shipTiltRight * horizontalInput), 1));

        if (horizontalInput == 1)
        {
            spaceShip.transform.rotation = Quaternion.Lerp(shipCenter, shipTiltRight, 1);
        }
        else if (horizontalInput == -1)
        {
            spaceShip.transform.rotation = Quaternion.Slerp(shipCenter, shipTiltLeft, 1);
        }
        else
        {
            spaceShip.transform.rotation = shipCenter;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xClamp, _xClamp), Mathf.Clamp(transform.position.y, -_yClamp, _yClamp), 0);
    }

    private void FireLaser()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > canFire)
        {
            LaserDamage();
        }
    }

    private void LaserDamage()
    {
        canFire = Time.time + fireRate;
        playerLaserPrefab = spawnPooler.GetPooledLaser(poolNumber);
        playerLaserPrefab.transform.position = playerLaserOrigin.transform.position;
        playerLaserPrefab.SetActive(true);
    }

    public void ShipSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ShipLaser(GameObject laserPrefab)
    {
        playerLaserPrefab = laserPrefab;
    }

    public void ShipLaserOrgiin(GameObject laserOrigin)
    {
        playerLaserOrigin = laserOrigin;
    }

    public void ShipLaserPool(int laserNumber)
    {
        poolNumber = laserNumber;
    }

    public void ShipCanFire(float newCanfire)
    {
        canFire = newCanfire;
    }

    public void ShipFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }
}
