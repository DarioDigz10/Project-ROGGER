using UnityEngine;

public class Upgrade_Weapon : MonoBehaviour
{
    [SerializeField] BulletController bullet;
    [SerializeField] GameObject bala;
    [Header("Parametros de mejora")]
    public float upgradeDuration;
    public float damageMultiplier = 5f;

    private float targetTime;
    private bool usado = false;

    private void Start()
    {
        bullet = bala.GetComponent<BulletController>();
        print("DAMAGE: " + bullet.damage);
    }

    void Update()
    {
        if (GameManager.Instance.InputController.MejorarArma && usado == false)
        {
            targetTime = upgradeDuration;
            bullet.damage *= damageMultiplier;
            print("ARMA MEJORADA: " + bullet.damage);
            usado = true;
        }

        if (targetTime > 0) targetTime -= Time.deltaTime;

        if (targetTime <= 0 && usado == true)
        {
            bullet.damage /= damageMultiplier;
            usado = false;
            print("FIN DE MEJORA: " + bullet.damage);
        }
    }
}


