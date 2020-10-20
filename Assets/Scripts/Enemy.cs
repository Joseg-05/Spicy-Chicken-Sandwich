using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.gameObject.name == "Rabbit Player")
        {

            render.material.color = Color.green;
            

        }
    }
}
