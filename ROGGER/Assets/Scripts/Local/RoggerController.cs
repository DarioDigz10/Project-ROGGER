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
	public float radioPath;

	//navMeshAgent propierties
	public float speed;
	public float angSpeed;
	public float stopDistance;



    void Start()
    {
		agent = this.GetComponent<NavMeshAgent> ();
		agent.speed = speed;
		agent.angularSpeed = angSpeed;
		agent.stoppingDistance = stopDistance;

		targetTime = time;
    }

    void Update()
    {
		if (targetTime <= 0) {
			newPath ();
			Debug.Log ("nuevo Path");
		} else {
			targetTime -= Time.deltaTime;
		}

		Debug.Log (agent.remainingDistance + "distance");

		if (agent.remainingDistance <= 0.5) {
			agent.speed = 0;
			agent.angularSpeed = 0;
		}
    }

	void newPath(){
		float newX = Random.Range (this.transform.position.x + radioPath, this.transform.position.x - radioPath);
		float newZ = Random.Range (this.transform.position.z + radioPath, this.transform.position.z - radioPath);
		target = new Vector3 (newX, this.transform.position.y, newZ);
		agent.SetDestination (target);
		//Debug.DrawLine (this.transform.position, target);

		if (agent.pathStatus == NavMeshPathStatus.PathInvalid) {
			agent.ResetPath();
		}

		agent.speed = speed;
		agent.angularSpeed = angSpeed;
		targetTime = time;
	}
}
