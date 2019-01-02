using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoggerController : MonoBehaviour
{
	public GameObject floor;
	private NavMeshAgent agent; 
	private Vector3 target;
	private float targetTime;

	public float time;
	public float radioPath;



	//navMeshAgent propierties
	public float speed;
	public float angSpeed;
	public float stopDistance;

	private float dimX;
	private float dimZ;

    void Start()
    {
		agent = this.GetComponent<NavMeshAgent> ();
		agent.speed = speed;
		agent.angularSpeed = angSpeed;
		agent.stoppingDistance = stopDistance;

		dimX = floor.GetComponent<MeshRenderer> ().bounds.size.x / 2;
		dimZ = floor.GetComponent<MeshRenderer> ().bounds.size.z / 2;

		Debug.Log ("x: "+dimX);
		Debug.Log ("z: "+dimZ);

		targetTime = time;
    }

    void FixedUpdate()
    {
		if (agent.remainingDistance <= 0.5) {
			newPath ();
		}

		/*
		if (targetTime <= 0) {
			newPath ();
			Debug.Log ("nuevo Path");
		} else {
			targetTime -= Time.deltaTime;
		}

		//Debug.Log (agent.remainingDistance + " distance");
		*/
    }

	void newPath(){
		float newX = Random.Range (this.transform.position.x + radioPath, this.transform.position.x - radioPath);
		float newZ = Random.Range (this.transform.position.z + radioPath, this.transform.position.z - radioPath);
		target = new Vector3 (newX, this.transform.position.y, newZ);

		if (target.x > dimX || target.x < (dimX * -1) || target.z > dimZ || target.z < (dimZ * -1)) {
			Debug.Log ("reiniciado");
			newPath ();
			//agent.SetDestination (Vector3.zero);
		} else {
			agent.SetDestination (target);
		}

		Debug.Log (target);
		targetTime = time;
	}
}
