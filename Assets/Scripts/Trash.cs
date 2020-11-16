using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Trash : MonoBehaviour
{
    Animator anim;
    private NavMeshAgent Mob;

    public GameObject Coco;

    public float MobDistanceRun = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Coco.transform.position);

        if(distance < MobDistanceRun)
        {
            
            Vector3 dirToPlayer = transform.position - Coco.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;
            //anim.SetTrigger("Running");
            Mob.SetDestination(newPos);

        }
    }
}
