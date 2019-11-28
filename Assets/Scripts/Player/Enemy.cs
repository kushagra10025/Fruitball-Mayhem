using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public HealthSystem healthSystem;
    public GameObject burstParticle;

    public float damageAmount = 12f;
    
    public Transform healthDisplay;

    public AudioClip enemyDieClip;
    public AudioClip playerHurtClip;

    private bool _isCollidingWithPlayer;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthSystem = new HealthSystem(100f);
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        //Enemy Default should face right direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        
        healthDisplay.GetChild(0).localScale = new Vector3(healthSystem.GetHealthPercent(),1f,1f);
        
        healthDisplay.rotation = Quaternion.identity;

        if (healthSystem.GetHealth() <= 0f)
        {
            GameObject go = Instantiate(burstParticle, transform.position, Quaternion.identity);
            AudioPlay.clip = enemyDieClip;
            AudioPlay.isPlaying = true;
                Destroy(go, 1.8f);
            if (SlowTimeAbility.isStateChanging)
            {
                ScoreSystem.currentScore += 4;
            }
            else
            {
                ScoreSystem.currentScore += 10;
            }
            Destroy(gameObject);
        }

        if (_isCollidingWithPlayer)
        {
            player.GetComponent<PlayerMovement>().healthSystem.Damage(damageAmount);
            _isCollidingWithPlayer = false;
        }

    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }


    void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * dir));
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other == null)
            return;

        if (other.gameObject.CompareTag("Player"))
        {
            _isCollidingWithPlayer = true;
            AudioPlay.clip = playerHurtClip;
            AudioPlay.isPlaying = true;
        }
        else
        {
            _isCollidingWithPlayer = false;
        }
    }
}
