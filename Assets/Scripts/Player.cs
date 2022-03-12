using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference
    // data type (int, float, bool, string)
    // every variable has a name
    // optional value assigned
    // public float speed = 3.5f;

    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultiplier = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = -3.96f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;


    // variable for _isTripleShotActive
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isSpeedBoostActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;



    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position(0,0,0)
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>(); //find the object. Get the component

        if (_spawnManager == null)
        {
            Debug.LogError("The spawn manager is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            // Debug.Log("Space Key Pressed");
            FireLaser();
        }

    }

    // class to calculate movement of player
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // new Vector(1,0,0) * -1 - 3.5f - real time
        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        // is the same but only in one line
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        // if speedboostactive  is false
        // else speedbost multipliers
        // (if and else )it is not necesary because on SpeedBoostPowerDownRoutine and SpeedBoostActive _speed value is modified there
        /*         if (_isSpeedBoostActive == false)
                {
                    transform.Translate(direction * _speed * Time.deltaTime);

                }
                else
                { 
                    transform.Translate(direction * (_speed * _speedMultiplier) * Time.deltaTime);

                } */
        transform.Translate(direction * _speed * Time.deltaTime);

        // if player position on the y is greater than 0
        // y position = 0
        // if (transform.position.y >= 0) {
        //     transform.position = new Vector3(transform.position.x, 0, 0);
        // } else if (transform.position.y <= -3.8f) {
        //     transform.position = new Vector3(transform.position.x, -3.8f, 0);
        // }
        // only a code line
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);


        // if player on the x > 11
        // x pos = -11
        // else if player on the x  is less than -11
        // x pos = 11


        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {

        // if i hit the space key
        // spawn gameObject

        _canFire = Time.time + _fireRate;


        // if space key press, fire 1 laser
        // if tripleshot active is true
        // fire 3 lasers (triple shot prefab)
        // else fire 1 laser
        if (_isTripleShotActive == true)
        {
            // instanteate for the triple shot
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0.001f, -0.075f, 0), Quaternion.identity);

        }


        // instantiate 3 lasers ( 3 shot prefab)

    }

    public void Damage()
    {
        // _lives--;
        _lives = _lives - 1;

        // check if dead
        //destroy us

        if (_lives < 1)
        {
            // Comunicate with Spawn Manager
            _spawnManager.OnPlayerDeath();
            // Let them know to stop spawning

            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        // tripleshotactive becomes true
        // start the power down coroutine for triple shot
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());

    }
    // ienumerator triple shot powerdownroutine
    //wait 5 seconds
    // set the triple shot to false
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }
    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
    }
}
