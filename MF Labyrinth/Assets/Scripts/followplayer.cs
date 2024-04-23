using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followplayer : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    public Transform sphere;

    // Start is called before the first frame update               
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = sphere.position;
    }

    // Update is called once per frame

}
