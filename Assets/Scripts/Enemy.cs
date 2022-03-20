using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;
    // handle to animator component

    private Animator _anim;

    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _explosionSoundClip;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
        // null check player
        if (_player == null)
        {
            Debug.LogError("The player is NULL");
        }
        // assign the component
        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("The Animator is NULL");
        }

        if (_audioSource == null)
        {
            Debug.LogError("The Audio Source on the player is NULL");
        }
        else
        {
            _audioSource.clip = _explosionSoundClip;
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    { // For 2D
        // if other is player
        // destroy us
        // damage the player

        // is needed to added a new tag for each item (laser, enemy and player)
        if (other.tag == "Player")
        {
            // damage player
            // other.transform.GetComponent<Player>().Damage(); // to access Damage class
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            // triger animation
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);

        }

        // if other is laser
        // laser
        // destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            // add 10 to score
            if (_player != null)
            {
                _player.AddScore(10);
            }
            // triger animation
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);

        }


        Debug.Log("Hit: " + other.transform.name);
    }
}
