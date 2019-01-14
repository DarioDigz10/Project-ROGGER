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

	void FixedUpdate(){

		if (rCtrl.search == true) {
			areaDetection ();
		}

	}

	void areaDetection(){
		Debug.Log ("EFECTIVAMENTE SE COMPRUEBA EL AREA");

		Collider[] atraibles = Physics.OverlapSphere (rCtrl.gameObject.transform.position, rCtrl.radioSearch);

		foreach (Collider matame in atraibles) {
			if (matame.CompareTag ("Trap")) {
				Debug.Log ("EL OBJETO ES UNA TRAMPA");
				tAtractionValue = matame.GetComponent<TrapSetup> ().AtractionValue;

				if (valorAtraccionObjetivo <= tAtractionValue) {
					
					valorAtraccionObjetivo = tAtractionValue;
					objetivo = matame.transform;
				}
			} else if (matame.CompareTag ("Enemy")) {
				Debug.Log ("EL OBJETO ES UN ENEMIGO");
				eAtractionValue = matame.GetComponent<EnemySetup> ().AtractionValue;

				if (valorAtraccionObjetivo <= eAtractionValue) {
					
					valorAtraccionObjetivo = eAtractionValue;
					objetivo = matame.transform;
				}
			}
		}

		if (objetivo != null) {
			rCtrl.atractiblePath (objetivo.position);
			valorAtraccionObjetivo = 0;
		}

	}

}
