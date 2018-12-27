using UnityEngine;

public class Healh : Destructible
{
    public override void takeDamage(float amount)
    {
        base.takeDamage(amount);
        print(hitPointsRemaining);
    }

    public override void Die()
    {
        base.Die();
        print("Ah se murió cabron");
    }
}
