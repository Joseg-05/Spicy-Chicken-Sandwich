using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Trash : MonoBehaviour
{
<<<<<<< HEAD
    Animator anim;
=======

>>>>>>> master
    private NavMeshAgent Mob;

    public GameObject Coco;

<<<<<<< HEAD
    public float MobDistanceRun = 63.0f;
=======
    public float MobDistanceRun = 10.0f;
>>>>>>> master

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Coco.transform.position);

<<<<<<< HEAD
        if(distance < MobDistanceRun)
        {
            
            Vector3 dirToPlayer = transform.position - Coco.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;
            //anim.SetTrigger("Running");
            Mob.SetDestination(newPos);

=======
        if (distance < MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Coco.transform.position;
           
            Vector3 newPos = transform.position - dirToPlayer;
           

            Mob.SetDestination(newPos);

            
>>>>>>> master
        }
    }
}
