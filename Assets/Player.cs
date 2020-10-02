using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System.Diagnostics;

public class Player : MonoBehaviour
{
    float _speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.50f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            float verticalInput = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(0, 0, verticalInput) * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float verticalInput = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(0, 0, verticalInput) * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float HorizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(HorizontalInput, 0, 0) * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float HorizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(HorizontalInput, 0, 0) * _speed * Time.deltaTime);
        }
    }
}
