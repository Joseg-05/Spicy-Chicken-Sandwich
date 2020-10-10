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
    float jumpForce = 7;
    private Rigidbody rb;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("Running");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, verticalInput) * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("Running");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, verticalInput) * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            anim.SetTrigger("Running");
            float HorizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(HorizontalInput, 0, 0) * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            anim.SetTrigger("Running");
            float HorizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(HorizontalInput, 0, 0) * _speed * Time.deltaTime);
        }

        if (transform.position.y <= 0.5f && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Running");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }



}
