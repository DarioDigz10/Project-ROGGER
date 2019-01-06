using UnityEngine;

public class Upgrade_Weapon : MonoBehaviour
{
    BulletController bullet;
    public GameObject bala;
    private float targetTime=2;
    public float time;
    private bool prueba=false;

    private void Start()
    {
        bullet = bala.GetComponent<BulletController>();
    }

    void Update()
    {
        bullet.damage = 2;
        if (GameManager.Instance.InputController.MejorarArma && prueba==false)
        {
            targetTime = time;
            bullet.damage *= 5;
            prueba = true;
        }
        
        if (targetTime > 1 && prueba==true)
        {
            bullet.damage *= 5;
            targetTime -= Time.deltaTime;
        }
        if(targetTime <= 1 && prueba==true)
        {
            bullet.damage /= 5;
            prueba = false;
        }
    }
}


