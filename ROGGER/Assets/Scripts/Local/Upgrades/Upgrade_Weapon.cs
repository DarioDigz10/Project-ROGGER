using UnityEngine;

public class Upgrade_Weapon : MonoBehaviour
{
    BulletController bullet;
    public GameObject bala;
    private float targetTime;
    public float time;
    private bool prueba=false;

    private void Start()
    {
        bullet = bala.GetComponent<BulletController>();
    }
    void Update()
    {
       if (Input.GetKeyDown("q") && prueba)
       {
         prueba = true;
         bullet.damage *= 5;
            Debug.Log("arriba españa");
         targetTime = time;
       }
        if (targetTime >= 0 && !prueba)
        {
            targetTime -= Time.deltaTime;
        }
        else
        {
            prueba = false;
            bullet.damage /= 5;
            Debug.Log("abajo andorra");
        }


    }
}

    
