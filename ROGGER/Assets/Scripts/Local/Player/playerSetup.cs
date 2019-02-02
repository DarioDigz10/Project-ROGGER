using UnityEngine;

public class PlayerSetup : Destructible
{
    [SerializeField] float TotalMana;
    public float actualHealth;
    public float actualMana;
    [SerializeField] float HPRegen;

    public float totalMana
    {
        get {
            return TotalMana;
        }
    }

    void Start() {
        actualHealth = totalHP;
        actualMana = TotalMana;
    }

    void Update() {
        if (actualHealth < totalHP) {
            regeneration();
        }
    }

    void regeneration() {
        actualHealth += HPRegen * Time.deltaTime;
        if (actualHealth > 100) {
            actualHealth = 100;
        }
    }
}
