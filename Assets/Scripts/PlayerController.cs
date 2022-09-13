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

    public float shipSpeed = 8f;
    private readonly float tiltSpeed = .4f;
    private readonly int tiltDegree = 45;

    private readonly float _xClamp = 9;
    private readonly float _yClamp = 5;

    public float tiltDirection = 45f;
    public bool shipMoving = false;


    public GameObject playerLaserPrefab;
    public GameObject playerLaserOrigin;
    public int poolNumber;

    public float canFire = -.5f;
    public float fireRate = .5f;

    private void Start()
    {
        spawnPooler = SpawnPooler.spawnPooler;
        shipMoving = false;
    }

    private void FixedUpdate()
    {
        MoveSpaceShip();
        FireLaser();
    }

    public void GameStarted()
    {
        shipMoving = true;
    }

    private void MoveSpaceShip()
    {
        if (shipMoving == true)
        {
            float horizontalInput = Input.GetAxisRaw(hor);
            float verticalInput = Input.GetAxisRaw(ver);

            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
            Quaternion shipCenter = Quaternion.Euler(0, 0, 0);
            Quaternion shipTiltRight = Quaternion.Euler(0, -tiltDirection, 0);
            Quaternion shipTiltLeft = Quaternion.Euler(0, tiltDirection, 0);

            transform.Translate(shipSpeed * Time.deltaTime * direction);

            if (horizontalInput == 1)
            {
                spaceShip.transform.rotation = Quaternion.RotateTowards(spaceShip.transform.rotation, shipTiltRight, tiltDegree);
            }
            else if (horizontalInput == -1)
            {
                spaceShip.transform.rotation = Quaternion.RotateTowards(spaceShip.transform.rotation, shipTiltLeft, tiltDegree);
            }
            else
            {
                spaceShip.transform.rotation = Quaternion.Slerp(spaceShip.transform.rotation, shipCenter, tiltSpeed);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xClamp, _xClamp), Mathf.Clamp(transform.position.y, -_yClamp, _yClamp), 0);
        }
    }

    private void FireLaser()
    {
        if (shipMoving == true)
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > canFire)
            {
                LaserDamage();
            }
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
        shipSpeed = newSpeed;
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
