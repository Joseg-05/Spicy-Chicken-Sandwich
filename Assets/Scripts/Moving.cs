using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float period = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (period > 2)
        {
           
            Vector3 random = new Vector3(Random.Range(0, 7), Random.Range(0, 5), Random.Range(0, 7));
            transform.localScale = random;
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }

}
