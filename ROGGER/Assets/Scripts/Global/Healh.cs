using UnityEngine;

public class Healh : Destructible
{
    [SerializeField] float timeToRespawn;

    public override void takeDamage(float amount) {
        base.takeDamage(amount);
        print("HP Remaining:" + hitPointsRemaining);
    }

    private void OnEnable() {
        Reset();
    }

    public override void Die() {
        base.Die();
        GameManager.Instance.Respawner.Despawn(gameObject, timeToRespawn);
    }
}
