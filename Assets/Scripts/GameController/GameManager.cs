using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] guns;
    public Sprite[] gunsS;
    private int timePerGun;
    private int _tPG;
    private int _tPGT;
    private CameraShake cameraShake;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        cameraShake = FindObjectOfType<CameraShake>();
        timePerGun = CountdownTimer.TIMELEFT;
    }

    private void Start()
    {
        _tPG = _tPGT = timePerGun / 3;
    }

    private void Update()
    {
        GunChange();
    }

    private void FixedUpdate()
    {
        GunProperties();
    }

    private void GunChange()
    {
        int instanceTimeLeft = CountdownTimer.Instance.timeLeft;
        
        
        if (instanceTimeLeft <= (timePerGun - _tPG))
        {
            guns[0].SetActive(false);
            cameraShake.ShakeCamera(0.3f,1.2f,2f);
            UISetup.Instance.SetupGunBarSprite(gunsS[1]);
            guns[1].SetActive(true);
        }
        if (instanceTimeLeft <= (timePerGun - 2*_tPG ))
        {
            guns[1].SetActive(false);
            cameraShake.ShakeCamera(0.3f,1.2f,2f);
            UISetup.Instance.SetupGunBarSprite(gunsS[2]);
            guns[2].SetActive(true);    
        }
    }


    
    private void GunProperties()
    {
        foreach (var t in guns)
        {
            if (t.activeSelf)
            {
                Shooting.Instance.firePoint = t.transform.GetChild(0).transform;
                Shooting.Instance.muzzleParticle = t.transform.GetChild(0).GetComponent<ParticleSystem>();
            }
            if (t.activeSelf && t.name.Equals("Gun002"))
            {
                Shooting.Instance.fireRate = 3.5f;
                Bullet.damageAmount = 40f;
            }
            if (t.activeSelf && t.name.Equals("Gun003"))
            {
                
                Shooting.Instance.fireRate = 1f;
                Bullet.damageAmount = 100f;
            }
        }
    }
}
