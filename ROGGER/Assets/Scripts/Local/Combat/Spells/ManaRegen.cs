using UnityEngine;

public class ManaRegen : MonoBehaviour
{
    [SerializeField] float regen;
    PlayerSetup player;

    void Start() {
        player = GameManager.Instance.Player.GetComponent<PlayerSetup>();
    }

    private void OnTriggerEnter(Collider enemy) {
        if (enemy.CompareTag("Enemy")) {
            if (player.actualMana < player.totalMana) {
                player.actualMana += regen;
            }
        }
    }
}
