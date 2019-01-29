using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSetup : Destructible
{
	public float totalHealth;
    public float actualHealth;
	[SerializeField] float regen; 

	void Start(){
		this.totalHP = totalHealth;
		this.actualHealth = totalHealth;

	}

	void Update(){
		if(actualHealth < totalHealth){
			regeneration ();
		}
	
	}

	void regeneration(){
		actualHealth = actualHealth + regen*Time.deltaTime;
        if (actualHealth>100) {
            actualHealth = 100;
        }
	}
}
