using System.Collections;
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

    private void Awake()
    {
        firePoint = transform.Find("Fire Point");
    }

    public virtual void Fire()
    {
        canFire = false;
        if (Time.time < nextFireAllowed) return;
        nextFireAllowed = Time.time + rateOfFire;
        canFire = true;
    }

    void Update()
    {
    }
}
