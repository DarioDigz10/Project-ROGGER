using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoggerController : MonoBehaviour
{
	private NavMeshAgent agent; 


    void Start()
    {
		agent = this.GetComponent<NavMeshAgent> ();
    }

    void Update()
    {
		
    }
}
