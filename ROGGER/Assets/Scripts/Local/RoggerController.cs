using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoggerController : MonoBehaviour
{
	private NavMeshAgent agent; 
	private Vector3 target;
	private float targetTime;
	public float time;


    void Start()
    {
		agent = this.GetComponent<NavMeshAgent> ();
		targetTime = time;
    }

    void Update()
    {
		if (targetTime >= time) {
			newPath ();
		} else {
			targetTime += Time.deltaTime;
		}
    }

	void newPath(){
		float newX = Random.Range (this.transform.position.x + 5, this.transform.position.x - 5);
		float newZ = Random.Range (this.transform.position.z + 5, this.transform.position.z - 5);
		target = new Vector3 (newX, this.transform.position.y, newZ);

		agent.SetDestination (target);
		if (agent.remainingDistance <= 0.5) {
			targetTime = 0;
		}
	}
}
