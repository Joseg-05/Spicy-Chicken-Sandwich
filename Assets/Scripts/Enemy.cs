using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private MeshRenderer render;
    
    // Start is called before the first frame update
    void Start()
    {
        
        render = gameObject.GetComponent<MeshRenderer>();
        render.material.SetColor("_Color", Color.red);
    }


   
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            render.material.color = Color.green;
            

        }
    }
}
