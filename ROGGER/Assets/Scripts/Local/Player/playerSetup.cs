using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSetup : Destructible
{
	public float totalHealth;
	[SerializeField] private float actualHealth;
	[SerializeField] float regen; 

	void Start(){
		this.hitPoints = totalHealth;
		this.actualHealth = totalHealth;

	}

	void Update(){
		if(actualHealth < totalHealth){
			regeneration ();
		}
	
	}

	void regeneration(){
		actualHealth = actualHealth + regen*Time.deltaTime;
	}
}
