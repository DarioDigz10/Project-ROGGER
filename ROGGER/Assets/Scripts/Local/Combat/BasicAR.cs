using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAR : Shooter
{
    public override void Fire()
    {
        base.Fire();
        if (canFire)
        {
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = shotSpeed;
        }
    }
}
