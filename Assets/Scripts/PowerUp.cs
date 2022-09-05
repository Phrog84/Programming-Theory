using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private float _speedPowerUp;

    public int _powerUPID;

    public AudioClip _clip;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(6, 7), 0);

        _speedPowerUp = Random.Range(1, 3);

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speedPowerUp * Time.deltaTime);

        if (gameObject.transform.position.y <= -8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if (player != null)
            {
                switch (_powerUPID)
                {
                    case 0:
                        player.TripShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.SheildActive();
                        break;
                    case 3:
                        player.LaserRefill();
                        break;
                    default:
                        Debug.Log("null");
                        break;
                }
            }

            Destroy(gameObject);
        }
    }
}
