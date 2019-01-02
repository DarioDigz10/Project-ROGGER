using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] Shooter Weapon;

    void Update()
    {
        if (GameManager.Instance.InputController.FIre1)
        {
            Weapon.Fire();
        }
    }
}