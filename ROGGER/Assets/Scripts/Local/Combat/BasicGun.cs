using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Shooter
{
    public int pelletCount;
    public float spreadAngle;
    List<Quaternion> pellets;

    public void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    public void Update()
    {
        if(GameManager.Instance.InputController.Reload)
        {
            Reload();
        }
    }

    public override void Fire()
    {
        base.Fire();
        if (canFire)
        {
            int i = 0;
            foreach (Quaternion quat in pellets)
            {
                pellets[i] = Random.rotationUniform;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.transform.rotation = Quaternion.RotateTowards(newBullet.transform.rotation, pellets[i], spreadAngle);
                newBullet.speed = shotSpeed;
                i++;
            }
        }
    }
}
