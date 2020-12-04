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
    public float coins;
    public float rage;
    private float timer;
    public int TotalTime;
    public float changeJump;
    public int count=0;
    public float changeSpeed;
    public float price = 0;
    private Rigidbody rb;
    Animator anim;
    private GameObject triggeringNPC;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject npcText;
    public GameObject howtoplayText;
    public GameObject howtoplayText1;
    public GameObject howtoplayText2;
    public GameObject Ragemodeopentext;
    public GameObject howtoplayTextbackground;
    public GameObject NOT_Enough_CoinsText;
    public GameObject GameoverText;
    public int Health ;
    public float RotateSpeed = 30f;

    private bool triggering;
    private bool NOT_Enough_Coins;
    private bool Buy_items;
    private bool Rage_mode;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-171.9946f,0, 74.4004f);
        //transform.position = new Vector3(-168.344f, 6.439923f, 97.91418f);
       
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
                npcText.SetActive(false);
                howtoplayText.SetActive(true);
                howtoplayTextbackground.SetActive(true);
            }  
            if (Input.GetKeyDown(KeyCode.F))
                {
                    howtoplayText.SetActive(false);
                    howtoplayText1.SetActive(true);
                }
             if (Input.GetKeyDown(KeyCode.G))
                    {
                        howtoplayText1.SetActive(false);
                        howtoplayText2.SetActive(true);
                     }

        }
        else
        {
            npcText.SetActive(false);
            howtoplayText.SetActive(false);
            howtoplayText1.SetActive(false);
            howtoplayText2.SetActive(false);
            howtoplayTextbackground.SetActive(false);
        }//triggering system for npc

        if (Buy_items)
        {
            //Buy_items.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                coins -= price;
                _speed += changeSpeed;//tbd
                jumpForce += changeJump;
                Coins.coinAmount -= price;
                Destroy(triggeringNPC);
                triggering = false;
                changeSpeed=0;
                changeJump = 0;
            }
        }
        else
        {
            //Buy_items.SetActive(false);
        }

        if (NOT_Enough_Coins)
        {
            NOT_Enough_CoinsText.SetActive(true);
            
        }
        else
        {
            NOT_Enough_CoinsText.SetActive(false);
        }


        if (Health > 0) {
            GameoverText.SetActive(false);
        }//healthy heart system

        if(rage >= 100)
        {
            //UnityEngine.Debug.Log("Hello11");
            Rage_mode = true;
            Ragemodeopentext.SetActive(true);
           if(count>= 2)
           {
               rage = 0;
           }
           
    

        }
        else
        {
            Ragemodeopentext.SetActive(false);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {

            triggering = true;
            triggeringNPC = other.gameObject;


        }
        if (other.tag == "Coin")
        {

            coins += 1;
            Coins.coinAmount =coins;
            
        }

        if (other.tag == "rage")
        {

            rage += 100;

        }
        if (other.name == "itemA")
        {
            price = 3;
            if (coins >= 3)
            {

                
                changeSpeed = 1;
                Buy_items = true;
                triggeringNPC = other.gameObject;

            }
            else
            {
                NOT_Enough_Coins = true;
                triggeringNPC = other.gameObject;
            }

        }

        if (other.name == "itemB")
        {
            price = 5;
            changeSpeed = 2;
            if (coins >= 5)
            {

                
                Buy_items = true;
                triggeringNPC = other.gameObject;

            }
            else
            {
                NOT_Enough_Coins = true;
                triggeringNPC = other.gameObject;
            }


        }
        if (other.name == "itemC")
        {
            price = 5;
            changeJump = 2;
            if (coins >= 5)
            {


                Buy_items = true;
                triggeringNPC = other.gameObject;

            }
            else
            {
                NOT_Enough_Coins = true;
                triggeringNPC = other.gameObject;
            }


        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {

            triggering = false;
            triggeringNPC = null;

        }
        if (other.tag == "items")
        {

            NOT_Enough_Coins = false;
            triggeringNPC = null;
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy"& Rage_mode ==false)
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
        if (collision.gameObject.tag == "enemy" & Rage_mode == true)
        {
            Destroy(collision.gameObject);
            count++;
        }
        
        
    }




}
