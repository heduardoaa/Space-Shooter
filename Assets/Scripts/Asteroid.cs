using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

[SerializeField]
    private float _rotateSpeed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate object on the zed axis!
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    // check for LASER collision ()Trigger
    // instantiate explosion at the position of the astroid (us)
    // destroy the explosion after 3 seconds
}