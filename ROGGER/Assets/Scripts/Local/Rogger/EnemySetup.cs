using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetup : MonoBehaviour
{
	public int AtractionValue;
	public bool visitado;

	void Awake(){
		visitado = false;
	}
}
