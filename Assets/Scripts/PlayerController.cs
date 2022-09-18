using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public class SpaceShips
    {
        public string tag;
        public int poolNumber;
        public float speed;
        public GameObject laserPrefab;
        public GameObject laserOrigin;
        public float canFire;
        public float fireRate;
    }

    public List<SpaceShips> spaceShipsList;
    public List<GameObject> activeSpaceShips; 

    public int poolNumber;
    public float shipSpeed;
    public GameObject playerLaserPrefab;
    public GameObject playerLaserOrigin;
    public float canFire;
    public float fireRate;

    private SpawnPooler spawnPooler;

    private readonly string hor = "Horizontal";
    private readonly string ver = "Vertical";
    private readonly string vFPV = "FPVCam";
    private readonly string vTopV = "TopViewCam";

    public int currentShip;
    private readonly int firstShip = 0;
    private readonly int lastShip = 3;

    public GameObject spaceShip;
    private readonly Vector3 center;

    private readonly float tiltSpeed = .4f;
    private readonly int tiltDegree = 45;
    private readonly float _xClamp = 12;
    private readonly float _yClamp = 5;
    private float tiltDirection = 45f;
    private float canSwitch = -.1f;
    private float switchRate = .5f;
    public bool shipMoving = false;

    [SerializeField]
    private Animator controllerAnim;
    private bool topViewCamOn = true;
    private float camSwitch = -.2f;
    private float camRate = .4f;

    private void Start()
    {
        spawnPooler = SpawnPooler.spawnPooler;
        shipMoving = false;
    }

    private void FixedUpdate()
    {
        MoveSpaceShip();
        FireLaser();
        NewSpaceShip();
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
                spaceShip.transform.rotation = Quaternion.RotateTowards(spaceShip.transform.rotation,
                    shipTiltRight, tiltDegree);
            }
            else if (horizontalInput == -1)
            {
                spaceShip.transform.rotation = Quaternion.RotateTowards(spaceShip.transform.rotation,
                    shipTiltLeft, tiltDegree);
            }
            else
            {
                spaceShip.transform.rotation = Quaternion.Slerp(spaceShip.transform.rotation,
                    shipCenter, tiltSpeed);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xClamp, _xClamp),
                Mathf.Clamp(transform.position.y, -_yClamp, _yClamp), 0);
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

    public void SwitchCamera()
    {
        if (Time.time > camSwitch && shipMoving == true)
        {
            canSwitch = Time.time + camRate;

            if (topViewCamOn)
            {
                controllerAnim.SetTrigger(vFPV);
            }
            else
            {
                controllerAnim.SetTrigger(vTopV);
            }
            topViewCamOn = !topViewCamOn;
        }
    }


    public void NewSpaceShip()
    {
        if (shipMoving == true && Time.time > canSwitch)
        {
            canSwitch = Time.time + switchRate;

            if (Input.GetKey(KeyCode.Tab))
            {
                SwitchSpaceShip(currentShip += 1);

                if (currentShip >= lastShip)
                {
                    currentShip = firstShip;
                    SwitchSpaceShip(currentShip);
                }
            }
        }
    }

    public void SwitchSpaceShip(int selectedShip)
    {
        switch (selectedShip)
        {
            case 0:
                for (int i = 0; i < activeSpaceShips.Capacity; i++)
                {
                    activeSpaceShips[i].SetActive(false);
                }
                activeSpaceShips[0].SetActive(true);
                poolNumber = spaceShipsList[0].poolNumber;
                shipSpeed = spaceShipsList[0].speed;
                playerLaserPrefab = spaceShipsList[0].laserPrefab;
                playerLaserOrigin = spaceShipsList[0].laserOrigin;
                canFire = spaceShipsList[0].canFire;
                fireRate = spaceShipsList[0].fireRate;
                currentShip = 0;
                break;
            case 1:
                for (int i = 0; i < activeSpaceShips.Capacity; i++)
                {
                    activeSpaceShips[i].SetActive(false);
                }
                activeSpaceShips[1].SetActive(true);
                poolNumber = spaceShipsList[1].poolNumber;
                shipSpeed = spaceShipsList[1].speed;
                playerLaserPrefab = spaceShipsList[1].laserPrefab;
                playerLaserOrigin = spaceShipsList[1].laserOrigin;
                canFire = spaceShipsList[1].canFire;
                fireRate = spaceShipsList[1].fireRate;
                currentShip = 1;
                break;
            case 2:
                for (int i = 0; i < activeSpaceShips.Capacity; i++)
                {
                    activeSpaceShips[i].SetActive(false);
                }
                activeSpaceShips[2].SetActive(true);
                poolNumber = spaceShipsList[2].poolNumber;
                shipSpeed = spaceShipsList[2].speed;
                playerLaserPrefab = spaceShipsList[2].laserPrefab;
                playerLaserOrigin = spaceShipsList[2].laserOrigin;
                canFire = spaceShipsList[2].canFire;
                fireRate = spaceShipsList[2].fireRate;
                currentShip = 2;
                break;
            default:
                break;
        }
    }
}