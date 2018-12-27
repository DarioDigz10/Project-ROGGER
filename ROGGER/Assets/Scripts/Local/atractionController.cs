using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atractionController : MonoBehaviour
{
	public GameObject[] obstaculos;
	public int tamanio;

	public class Obstaculo
	{
		int atraccion = 0;

		public Obstaculo (int a){
			atraccion = a;
		}

		public int getAtraccion(){
			return atraccion;
		}
	}



    void Start()
    {
        //ALEJANDRO HIJO, NECESITO EJECUTAR
		/*obstaculos = new GameObject[tamanio];
		for (int i = 0; i < tamanio; i++) {

			if (obstaculos [i].tag == "Enemy") {
				obstaculos [i] = new Obstaculo (1);

			} else if (obstaculos [i].tag == "Trap") {
				obstaculos [i] = new Obstaculo (2);
			}
		}*/
    }

    void Update()
    {
        
    }
}
