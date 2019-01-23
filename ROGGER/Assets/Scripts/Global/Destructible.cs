using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
	[SerializeField] [HideInInspector] public float hitPoints;
    public event System.Action OnDeath;
    public event System.Action OnDamageRecived;
    float damageTaken;

    public float hitPointsRemaining
    {
        get
        {
            return hitPoints - damageTaken;
        }
    }

    public bool isAlive
    {
        get
        {
            return hitPointsRemaining > 0;
        }
    }

    public virtual void Die()
    {
        if (!isAlive) return; //If it is already dead, return;
        if (OnDeath != null) OnDeath();
    }

    public virtual void takeDamage(float amount)
    {
        damageTaken += amount;
        if (OnDamageRecived != null) OnDamageRecived();
        if (hitPointsRemaining <= 0) Die();
        
    }

    public void Reset()
    {
        damageTaken = 0;
    }
}
