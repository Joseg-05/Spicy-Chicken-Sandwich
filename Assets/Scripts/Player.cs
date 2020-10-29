using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System.Diagnostics;

public class Player : MonoBehaviour
{
    public float _speed ;
    public float _speedTwo = 6;
    public float jumpForce ;
    private Rigidbody rb;
    Animator anim;
    private GameObject triggeringNPC;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private bool triggering;
    public GameObject npcText;
    public GameObject GameoverText;
    public int Health ;
    public float RotateSpeed = 30f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-168.344f, 6.439923f, 97.91418f);
       
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
        //Dodging Effect Here, These Two
        if (Input.GetKey(KeyCode.R)) 
        {
            
            transform.Translate(new Vector3(10, 0, 0) * _speedTwo * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.Q))
        {
            
            transform.Translate(new Vector3(-10, 0, 0) * _speedTwo * Time.deltaTime);
            
        }

        

        if (triggering)
        {
            npcText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Destroy(triggeringNPC);
                triggering = false;
            }
        }
        else
        {
            npcText.SetActive(false);
        }
        if (Health > 0) {
            GameoverText.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {

            triggering = true;
            triggeringNPC = other.gameObject;


        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {

            triggering = false;
            triggeringNPC = null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        { 
            Health -= 1;
            if (Health <= 2 && collision.gameObject.tag == "enemy")
            {
                heart3.SetActive(false);
            }
            if (Health <= 1 && collision.gameObject.tag == "enemy")
            {
                heart2.SetActive(false);
            }
            if (Health <= 0 && collision.gameObject.tag == "enemy")
            {
                heart1.SetActive(false);
                GameoverText.SetActive(true);
                FindObjectOfType<GameManger>().EndGame();
                

            }
        }
        
        
    }



}
