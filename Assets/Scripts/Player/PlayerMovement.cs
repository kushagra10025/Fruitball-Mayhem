using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    public float movSpeed;
    private Rigidbody2D _rb;
   
    [SerializeField] private Transform charAssembly;
    
    [SerializeField] private bool isVerticalMovementAllowed = false;
    public GameObject burstingParticle;

    public HealthSystem healthSystem;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        healthSystem = new HealthSystem(100f);
        
        
        UISetup.Instance.Setup(healthSystem);
    }

    private void Update()
    {
      
        float horMov = Input.GetAxisRaw("Horizontal"); 
        float verMov = Input.GetAxisRaw("Vertical");
        
        
//        Vector3 lS = transform.localScale;
        if (horMov < 0f)
        {
            PlayerBodyRot(180f);
            //lS.x = -1;
        }if (horMov > 0f)
        {
            PlayerBodyRot(0f);
            //lS.x = 1;
        }
//
//        transform.localScale = lS;

        if (healthSystem.GetHealth() <= 0f)
        {
            GameObject go = Instantiate(burstingParticle, transform.position, Quaternion.identity);
            Destroy(go,1.8f);
            StartCoroutine("PlayerDied");
            horMov = verMov = 0f;
            _rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        
        Move(horMov, verMov);

    }

    IEnumerator PlayerDied()
    {
        yield return new WaitForSeconds(1.8f);
        UISetup.Instance.GameOverReady();
        Time.timeScale = 0f;
    }

    void Move(float _horMov, float _verMov)
    {
        Vector2 vel = new Vector2(_horMov,_verMov) * movSpeed;
        if (!isVerticalMovementAllowed)
        {
            vel.y = 0f;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        _rb.velocity = vel;
    }

    public void PlayerBodyRot(float rotAmt)
    {
        Quaternion charAssemblyRotation = charAssembly.rotation;
        charAssemblyRotation.y = rotAmt;
        charAssembly.rotation = charAssemblyRotation;
    }
}
