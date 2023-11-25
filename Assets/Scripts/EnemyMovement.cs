using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 10f;
    [SerializeField] private float enemySpeed = 10f;

    [SerializeField] private PlayerMovement player;
    [SerializeField] private float enemyRunAwayRange = 20;
    [SerializeField] private float bulletDamage = 5;
    [SerializeField] private GameObject filter;

    public static int KilledEnemy = 0;

    private FilterAlphaController filterAlphaController;



    private void Start()
    {
        player = PlayerMovement.Instance;
        if (filter == null)
        {
            filter = GameObject.FindWithTag("Filter"); // YourFilterTag'i filter objesinin etiketi ile de�i�tirin
        }
        filterAlphaController = filter.GetComponent<FilterAlphaController>();

    }
    private void Update()
    {
        RunAway();
        
    }

    private void RunAway()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < enemyRunAwayRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            IdleAnimation();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (transform.position - player.transform.position).normalized;
        transform.Translate(direction * enemySpeed * Time.deltaTime);
    }

    private void IdleAnimation()
    {
        
        // TODO 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            GetDamage();
            if (enemyHealth <= 0)
            {
                GetKilled();
            }
        }
    }
   

    private void GetKilled()
    {
        //anim

        KilledEnemy++;

        filterAlphaController.IncreaseAlpha(0.1f); // Diledi�iniz art�� miktar�n� ayarlayabilirsiniz

        Destroy(gameObject);
    }

   

    private void GetDamage()
    {
        enemyHealth -= bulletDamage;
    }
}
