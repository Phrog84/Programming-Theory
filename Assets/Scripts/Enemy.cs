using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed;

    private Player _player;

    /*public GameObject _laserPrefab;

    private float _fireRate = 3f;
    private float _canFire = -1f;

    [SerializeField]
    private float _rotationSpeed = 5f;*/

    [SerializeField]
    private int _point = 1;

    // Start is called before the first frame update
    void Start()
    {
        _enemySpeed = Random.Range(2.5f, 10.5f);

        _player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            return;
        }

        /*if (Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 5f);
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Debug.Break();
        }*/
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        //transform.Rotate(Vector3.down * _rotationSpeed * Time.deltaTime);

        float randomX = Random.Range(-9f, 9f);

        if (transform.position.y < -6.5f)
        {
            transform.position = new Vector3(randomX, 7.5f, 0);
            _enemySpeed = Random.Range(2.5f, 10.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            if (_player != null)
            {
                _player.EnemiesDefeated(_point);

                //Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            if (_player != null)
            {
                _player.Damage();

                _player.EnemiesDefeated(_point);
            }
            Destroy(this.gameObject);
        }
    }
}
