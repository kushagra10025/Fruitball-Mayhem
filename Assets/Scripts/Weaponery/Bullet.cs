using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpactEffectPrefab;

    private CameraShake _cameraShake;

    public static float damageAmount=20f;

    private void Awake()
    {
        _cameraShake = FindObjectOfType<CameraShake>();
    }

    private void Start()
    {
        Destroy(gameObject,2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other == null) 
            return;
        
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.healthSystem.Damage(damageAmount);
            
            CompFunc();
        }
        
        CompFunc();
        
    }

    void CompFunc()
    {
        _cameraShake.ShakeCamera(0.3f,0.35f,1.2f);
        GameObject eff = Instantiate(bulletImpactEffectPrefab, transform.position, Quaternion.identity);
        Destroy(eff,0.8f);
        Destroy(gameObject);
    }
}
