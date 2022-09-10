using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string hor = "Horizontal";
    private string ver = "Vertical";

    public float speed = 8f;
    /*public float Speed
    {
        get { return Speed; }
        set { Speed = value; }
    }*/

    private float _xClamp = 9;
    private float _yClamp = 5;

    private void FixedUpdate()
    {
        MoveSpaceShip();
    }

    private void MoveSpaceShip()
    {
        float horizontalInput = Input.GetAxisRaw(hor);
        float verticalInput = Input.GetAxisRaw(ver);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.fixedDeltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xClamp, _xClamp), Mathf.Clamp(transform.position.y, -_yClamp, _yClamp), 0);
    }

    /*public void ShipSpeed(float speed)
    {
        Speed = speed;
    }*/
}
