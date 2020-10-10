using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-5, 0.5f, 7);
        var render = this.gameObject.GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var render = this.gameObject.GetComponent<Renderer>();
            render.material.SetColor("_Color", Color.green);
        }
    }
}
