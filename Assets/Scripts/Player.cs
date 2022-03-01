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
    [SerializeField]
    private GameObject _laserPrefab;


    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position(0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        
        // if i hit the space key
        // spawn gameObject

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Space Key Pressed");
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }

    // class to calculate movement of player
    void CalculateMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // new Vector(1,0,0) * -1 - 3.5f - real time
        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        // is the same but only in one line
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
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

        
        if (transform.position.x > 11.3f) {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        } else if (transform.position.x < -11.3f) {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
