using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumible : MonoBehaviour
{

	[SerializeField] float increaseHealth;
	Player player;
	bool picked;

	public enum TipoPocion
	{
		Vida, Mana
	};
	public TipoPocion tipo;

	void Start(){
		player = GameManager.Instance.Player;	
	}

	void Update(){
	/*	if(player.==){
			
		}*/
	}

	void OnTriggerEnter(){
		
	}
}
