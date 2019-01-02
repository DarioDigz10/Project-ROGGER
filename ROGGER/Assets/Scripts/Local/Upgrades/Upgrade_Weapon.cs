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
        Debug.Log(bullet.damage);
    }
    void Update()
    {
        bullet.damage = 2;
        Debug.Log(bullet.damage);
        if (Input.GetKeyDown("q") && prueba==false)
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
        Debug.Log(bullet.damage);
    }
}


