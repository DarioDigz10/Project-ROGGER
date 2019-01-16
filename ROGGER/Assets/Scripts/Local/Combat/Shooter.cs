﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [HideInInspector] public Transform firePoint;
    [SerializeField] public BulletController bullet;
    [SerializeField] float rateOfFire;
    float nextFireAllowed;
    public float shotSpeed;
    public bool canFire;

    public void Equip()
    {
        //TODO: asignar el transform al hueso adecuado del modelo cuando lo tengamos
    }

    public WeaponReloader reloader;
    public void Reload()
    {
        if (reloader == null) return;
        reloader.Reload();
    }

    private void Awake()
    {
        firePoint = transform.Find("Fire Point");
        reloader = GetComponent<WeaponReloader>();
        if (reloader == null) print("ES NULO");
    }

    public virtual void Fire()
    {
        canFire = false;
        if (Time.time < nextFireAllowed) return;

        if (reloader != null)
        {
            if (reloader.IsReloading) return;
            if (reloader.RoundsRemainingInClip == 0)
            {
                print("RECARGA GENIO (R)");
                return;
            }
            reloader.TakeFromClip(1);
        }

        nextFireAllowed = Time.time + rateOfFire;
        canFire = true;
    }

}