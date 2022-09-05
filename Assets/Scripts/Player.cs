using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8;
    private float _speedMulti = 2f;
    private Vector3 _startPos;

    public GameObject _laserPrefab;
    public GameObject _tripShotPrefab;
    public GameObject _sheild;

    
    private float _fireRate = .5f;
    private float _canFire = -1f;

    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int _shotsRemaining = 3;

    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    private GameManager _gameManager;

    public bool _isTripActive = false;
    public bool isSpeedActive = false;
    public bool _isSheildActive = false;

    public int _enemiesDefeated;

    private AudioSource _audioSource;
    public AudioClip _laserClip;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = new Vector3(0f, -2f, 0f);

        transform.position = Vector3.Slerp(transform.position, _startPos, 1f);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL");
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is NULL");
        }

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is NULL");
        }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is NULL");
        }
        else
        {
            _audioSource.clip = _laserClip;
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire && _shotsRemaining > 0)
        {
            FireLaser();

            _shotsRemaining -= 1;

            _uiManager.UpdateShots(_shotsRemaining);
        }

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.fixedDeltaTime);
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5), 0);
      
        if (transform.position.x >= 11.25f)
        {
            transform.position = new Vector3(-11.25f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.25f)
        {
            transform.position = new Vector3(11.25f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        if (_isTripActive == true)
            {
                Instantiate(_tripShotPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
            }
        if (_shotsRemaining <= 0)
            {
                return;
            }

        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
        _audioSource.Play();
    }


    public void Damage()
    {
        if (_isSheildActive == true)
        {
            _isSheildActive = false;
            _sheild.SetActive(false);
            return;
        }

        _lives -= 1;

        _uiManager.UpdateLives(_lives);

        if (_lives < 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        _spawnManager.OnPlayerDead();
        _uiManager.GameOverText();
        _gameManager.GameOver();
        Destroy(this.gameObject);
    }


    public void LaserRefill()
    {
        if (_shotsRemaining == 3f)
        {
            return;
        }
        else
        {
            _shotsRemaining += 1;

            _uiManager.UpdateShots(_shotsRemaining);
        }
    }

    public void TripShotActive()
    {
        _isTripActive = true;

        if (_shotsRemaining < 3)
        {
            _shotsRemaining += 1;

            _uiManager.UpdateShots(_shotsRemaining);
        }
        
        StartCoroutine(TripShotPowerRoutine());
        StartCoroutine(TripShotPowerDownRoutine());
    }

    IEnumerator TripShotPowerRoutine()
    {
        while (_isTripActive == true)
        {
            yield return new WaitForSeconds(1f);

            if (_shotsRemaining < 3)
            {
                _shotsRemaining += 1;

                _uiManager.UpdateShots(_shotsRemaining);
            }
        }
    }

    IEnumerator TripShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        _isTripActive = false;
    }

    public void SpeedBoostActive()
    {
        isSpeedActive = true;

        _speed *= _speedMulti;

        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(8);

        isSpeedActive = false;

        _speed /= _speedMulti;
    }

    public void SheildActive()
    {
        _isSheildActive = true;

        _sheild.SetActive(true);
    }

    public void EnemiesDefeated(int points)
    {
        _enemiesDefeated += points;

        _uiManager.UpdateEneimesDefeated(_enemiesDefeated);
    }
}
