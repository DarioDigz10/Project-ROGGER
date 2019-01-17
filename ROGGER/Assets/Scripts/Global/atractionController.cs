using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atractionController : MonoBehaviour
{
	private RoggerController rCtrl;

	private int eAtractionValue;
	private int tAtractionValue;

	private float valorAtraccionObjetivo;
	private Transform objetivo;

    void Start()
    {
		rCtrl = GameObject.FindGameObjectWithTag ("ROGGER").GetComponent<RoggerController>();
		valorAtraccionObjetivo = 0;
    }

	public void Search(){

		//Debug.Log ("SEARCH EN AC: " + rCtrl.search);

		//if (rCtrl.search == true) {
			areaDetection ();
			//rCtrl.busqueda = false;
		//}

	}

	void areaDetection(){
		//Debug.Log ("EFECTIVAMENTE SE COMPRUEBA EL AREA");

		Collider[] atraibles = Physics.OverlapSphere (rCtrl.gameObject.transform.position, rCtrl.radioSearch);

		foreach (Collider matame in atraibles) {
			if (matame.CompareTag ("Trap")) {
				//Debug.Log ("EL OBJETO ES UNA TRAMPA");
				tAtractionValue = matame.GetComponent<TrapSetup> ().AtractionValue;

				if (valorAtraccionObjetivo <= tAtractionValue && matame.gameObject.GetComponent<TrapSetup> ().visitado == false) {
					
					valorAtraccionObjetivo = tAtractionValue;
					objetivo = matame.transform;
				}
			} else if (matame.CompareTag ("Enemy")) {
				//Debug.Log ("EL OBJETO ES UN ENEMIGO");
				eAtractionValue = matame.GetComponent<EnemySetup> ().AtractionValue;

				if (valorAtraccionObjetivo <= eAtractionValue && matame.gameObject.GetComponent<EnemySetup> ().visitado == false) {
					
					valorAtraccionObjetivo = eAtractionValue;
					objetivo = matame.transform;
				}
			}
		}

		if (objetivo != null) {			
			if (objetivo.gameObject.CompareTag ("Enemy") /*&& objetivo.gameObject.GetComponent<EnemySetup> ().visitado == false*/) {
				rCtrl.atractiblePath (objetivo.position);
				objetivo.gameObject.GetComponent<EnemySetup> ().visitado = true;
			} else if (objetivo.gameObject.CompareTag ("Trap")/* && objetivo.gameObject.GetComponent<TrapSetup> ().visitado == false*/) {
				rCtrl.atractiblePath (objetivo.position);
				objetivo.gameObject.GetComponent<TrapSetup> ().visitado = true;
			}
		}
		objetivo = null;
		valorAtraccionObjetivo = 0;
			
	}

}
