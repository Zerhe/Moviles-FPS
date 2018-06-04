using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform objetivo;

	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        objetivo = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update ()
    {
        agent.SetDestination(objetivo.position);
	}
}
