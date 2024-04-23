using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    public Transform goal;
    private Animator animator;
    private NavMeshAgent agent;
    public Transform sphere;

    // Start is called before the first frame update               
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = sphere.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.hasPath)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if it is the right object
        if (collision.gameObject.CompareTag("cilectiblion"))
        {
            Destroy(collision.gameObject);
            agent.destination = goal.position;
        }
        // delete it
    }
}
