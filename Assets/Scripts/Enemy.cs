using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if  botton of screen
        // respawn at top with a new randow x position

        if (transform.position.y < -5f)
        {
            float randowX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randowX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // if other is player
        // destroy us
        // damage the player

        // if other is laser
        // destroy us
        // laser
        Debug.Log("Hit: " + other.transform.name);
    }
}
