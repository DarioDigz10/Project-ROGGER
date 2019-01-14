using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atractionController : MonoBehaviour
{
	private GameObject[] traps;
	private GameObject[] enemies;
	private GameObject ROGGER;
	private RoggerController rCtrl;

	private int eAtractionValue;
	private int tAtractionValue;

	private float targetTime;
	private float timeA;

    void Start()
    {
		rCtrl = new RoggerController ();
		ROGGER = GameObject.FindGameObjectWithTag ("ROGGER");
		timeA = rCtrl.time;
		targetTime = timeA;

		traps = GameObject.FindGameObjectsWithTag ("Trap");
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		foreach(GameObject trap in traps){
			Debug.Log ("trampa");
			tAtractionValue = trap.GetComponent<TrapSetup> ().AtractionValue;
			Debug.Log ("Trap: " + tAtractionValue);
			areaDetection (trap);
		}

		foreach(GameObject enemy in enemies){
			Debug.Log ("enemigo");
			eAtractionValue = enemy.GetComponent<EnemySetup> ().AtractionValue;
			Debug.Log ("Enemy: " + eAtractionValue);
		}
    }

	void Update(){

		if (targetTime <= 0) {
			for (int i = 0; i < traps.Length; i++) {
				areaDetection (traps[i]);
			}
			for (int j = 0; j < enemies.Length; j++) {
				areaDetection (enemies[j]);
			}
		} else {
			targetTime -= Time.deltaTime;
		}
	}

	void areaDetection(GameObject obj){
		if (obj != null) {
			
		
		float auxX = obj.transform.position.x - ROGGER.transform.position.x;
		float auxZ = obj.transform.position.z - ROGGER.transform.position.z;

		if(auxX <= rCtrl.radioSearch || auxZ <= rCtrl.radioSearch){
			rCtrl.atractiblePath (obj.transform.position);
		}
	}
	}
}
