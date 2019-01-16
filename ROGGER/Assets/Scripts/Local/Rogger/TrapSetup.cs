using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSetup : MonoBehaviour
{
	public int AtractionValue;
	public bool visitado;

	void Awake(){
		visitado = false;
	}
}
