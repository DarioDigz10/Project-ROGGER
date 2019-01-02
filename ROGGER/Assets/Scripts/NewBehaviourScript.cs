using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(objeto.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
