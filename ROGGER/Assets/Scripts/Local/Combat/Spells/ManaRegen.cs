using UnityEngine;

public class ManaRegen : MonoBehaviour
{
    Player player;
    [SerializeField] float regen;

    void Start()
    {
        player = GameManager.Instance.Player;
    }

    private void OnTriggerEnter(Collider enemy)
    { 
        if (enemy.CompareTag("Enemy")){
            playerSetup mana = player.GetComponent<playerSetup>();
            if (mana.actualMana < mana.totalMana) {
                mana.actualMana += regen;
            }
        }
    }
}
