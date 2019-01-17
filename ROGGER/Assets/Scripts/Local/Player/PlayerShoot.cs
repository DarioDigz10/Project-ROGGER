using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float SpellSwitchTime;
    Transform gunHolder;
    Shooter[] spells;
    Shooter activeSpell;

    int currentSpellIndex;
    bool canFire;

    public Shooter ActiveWeapon
    {
        get
        {
            return activeSpell;
        }
    }

    private void Awake()
    {
        canFire = true;
        gunHolder = transform.Find("Gun Holder");
        spells = gunHolder.GetComponentsInChildren<Shooter>();

        if (spells.Length > 0)
            EquipSpell(0);
    }

    void DeactivateSpells()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i].gameObject.SetActive(false);
            spells[i].transform.SetParent(gunHolder);
        }
    }

    void SwitchSpell(int direction)
    {
        canFire = false;
        currentSpellIndex += direction;
        if (currentSpellIndex > spells.Length - 1) currentSpellIndex = 0;
        if (currentSpellIndex < 0) currentSpellIndex = spells.Length - 1;
        GameManager.Instance.Timer.Add(() =>
        {
            EquipSpell(currentSpellIndex);

        }, SpellSwitchTime);
    }

    void EquipSpell(int index)
    {
        DeactivateSpells();
        canFire = true;
        activeSpell = spells[index];
        activeSpell.Equip();
        spells[index].gameObject.SetActive(true);
    }

    void Update()
    {
        if (GameManager.Instance.InputController.MouseWheelDown) SwitchSpell(1);
        if (GameManager.Instance.InputController.MouseWheelUp) SwitchSpell(-1);
        //We can't fire if we are switching spells
        if (!canFire) return;
        if (GameManager.Instance.InputController.Fire)
        {
            activeSpell.Fire();
        }
    }
}