using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunController : MonoBehaviour
{
    InputController playerInput;
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots = 1f;
    protected float shotCounter;

    public Transform firePoint;

    public virtual void Awake()
    {
        playerInput = GameManager.Instance.InputController;
    }

    void Update()
    {
        //GUN CONTROLLER:
        if (playerInput.mLeftClicked) isFiring = true;
        if (playerInput.mLeftUp) isFiring = false;

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Shoot();
            }
            else shotCounter = 0;
        }
    }

    public abstract void Shoot();
}
