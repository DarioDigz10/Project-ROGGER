using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : GunController
{
    public int pelletCount;
    public float spreadAngle;
    List<Quaternion> pellets;

    public override void Awake()
    {
        base.Awake();
        timeBetweenShots = 1f;
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    public override void Shoot()
    {
        print("HOLA");
        int i = 0;
        foreach (Quaternion quat in pellets)
        {
            pellets[i] = Random.rotationUniform;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.transform.rotation = Quaternion.RotateTowards(newBullet.transform.rotation, pellets[i], spreadAngle);
            newBullet.speed = bulletSpeed;
            i++;
        }
    }
}
