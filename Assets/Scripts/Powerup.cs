using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    // ID for Powerups
    // 0 = triple shot
    // 1 = speed
    // 2 = shields
    [SerializeField] // 0 = triple shot | = speed 2 = shields
    private int _powerupID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // mode down at a speed of 3
        // when we leave the screen, destrpy this object
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }
    // on trigercollition
    // Only be collectable by the player (Hint: use tags)
    // on collected, destroy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // communicate with the player script
            // handle to the component i want
            // assing the handle to the component
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                // if powerUP is 0
                // else if powerUp is 1
                // play speed powerup
                // esle if powerup is 2
                // shields powerup


                switch (_powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        Debug.Log("Collected Speed Boost");
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        Debug.Log("Shields Collected");
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;

                }


            }
            Destroy(this.gameObject);
        }

    }
}
