using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string hor = "Horizontal";
    private string ver = "Vertical";

    //private Rigidbody rb;

    public GameObject spaceShip;
    private Vector3 center;

    public float speed = 8f;
<<<<<<< Updated upstream
    /*public float Speed
    {
        get { return Speed; }
        set { Speed = value; }
    }*/
=======
    public float tiltDirection = 45f;
>>>>>>> Stashed changes

    private float _xClamp = 9;
    private float _yClamp = 5;

<<<<<<< Updated upstream
=======
    public GameObject playerLaserPrefab;
    public GameObject playerLaserOrigin;
    public int poolNumber;

    public float canFire = -.5f;
    public float fireRate = .5f;

    private void Start()
    {
        spawnPooler = SpawnPooler.spawnPooler;
        // rb = GetComponent<Rigidbody>();
    }

>>>>>>> Stashed changes
    private void FixedUpdate()
    {
        MoveSpaceShip();
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

    /*public void ShipSpeed(float speed)
    {
        Speed = speed;
    }*/
}
