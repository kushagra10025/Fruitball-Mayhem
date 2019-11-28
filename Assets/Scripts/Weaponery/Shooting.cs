using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance;
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    //[Header("Slow for Fast")]
    public float fireRate;
    public float waitTilNextFire;

    public AudioClip shootingClip;

    //public GameObject muzzleEffectPrefab;
    
    public float bulletForce = 20f;

    public ParticleSystem muzzleParticle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        muzzleParticle = firePoint.gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (waitTilNextFire <= 0f)
            {
                Shoot();
                waitTilNextFire = 1f;
            }
        }

        waitTilNextFire -= Time.deltaTime * fireRate;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //GameObject muzzEff = Instantiate(muzzleEffectPrefab,firePoint.position,firePoint.rotation);
        AudioPlay.clip = shootingClip;
        AudioPlay.isPlaying = true;
        muzzleParticle.Play();
        //Destroy(muzzEff,0.28f);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
