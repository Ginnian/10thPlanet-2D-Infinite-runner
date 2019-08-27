using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public Animator anim;
    public float fireDelay;

    private void Start()
    {
        InvokeRepeating("fireBullet", 1f, fireDelay);  
    }

    public void fireBullet()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        anim.SetTrigger("Fire");
    }
}
