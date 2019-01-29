using UnityEngine;

public class Consumible : MonoBehaviour
{

	[SerializeField] float increaseHealth;
	Player player;
	bool picked;
  
	void Start(){
		player = GameManager.Instance.Player;	
	}

	void OnTriggerEnter(Collider player){
        playerSetup ps = player.GetComponent<playerSetup>();
        ps.actualHealth += increaseHealth;
        if (ps.actualHealth>100) {
            ps.actualHealth = 100;
        }
        Destroy(gameObject);
	}
}
