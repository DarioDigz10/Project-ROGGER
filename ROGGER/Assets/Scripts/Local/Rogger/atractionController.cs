using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atractionController : MonoBehaviour
{
	private GameObject[] traps;
	private GameObject[] enemies;

    void Start()
    {
		traps = GameObject.FindGameObjectsWithTag ("Trap");
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		foreach(GameObject trap in traps){
			Debug.Log ("trampa");
		}

		foreach(GameObject enemy in enemies){
			Debug.Log ("enemigo");
		}
    }
}
