
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 10f;
    [SerializeField] private float enemySpeed = 10f;

    private PlayerMovement player;
    [SerializeField] private float enemyRunAwayRange = 20;
    [SerializeField] private float bulletDamage = 5;
    [SerializeField] private GameObject filter;

    public static int KilledEnemy = 0;

    private FilterAlphaController filterAlphaController;

    [SerializeField] private UiScprit cnvs;
    [SerializeField] private GameObject cnvs2;

    private float timer = 0;
    [SerializeField] private float changeInterval = 5f;

    public Vector2 direction = Vector2.up;
    [SerializeField] private float filterModifier;

    private Animator animator;

    private Collider2D collider2D;

    
    private void Start()
    {
        cnvs = FindObjectOfType<Canvas>().GetComponent<UiScprit>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();

        player = PlayerMovement.Instance;
        if (filter == null)
        {
            filter = GameObject.FindWithTag("Filter");
        }
        filterAlphaController = filter.GetComponent<FilterAlphaController>();
    }
    private void Update()
    {
        RunAway();

        timer += Time.deltaTime;

        if(timer > changeInterval )
        {
            timer = 0;
            direction = Random.insideUnitCircle;
        }
    }

    private void RunAway()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < enemyRunAwayRange)
        {
            MoveAwayFromPaayer();
        }
        else
        {
            MoveRandomly();
        }
    }

    private void MoveAwayFromPaayer()
    {
        Vector2 direction = (transform.position - player.transform.position).normalized;
        transform.Translate(direction * enemySpeed * Time.deltaTime);
    }

    private void MoveRandomly()
    {
        transform.Translate(direction * enemySpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            GetDamage();
            if (enemyHealth <= 0)
            {
                GetKilled();
            }

            Destroy(collision.gameObject);
        }
    }
  

    private void GetKilled()
    {   
        collider2D.enabled = false;
        cnvs.IncreaseDeathNumber();
        animator.SetTrigger("isDying");

        Invoke("EnemyDeath", 2f);

        KilledEnemy++;
        
        filterAlphaController.IncreaseAlpha(filterModifier);

        
    }

    private void GetDamage()
    {
        enemyHealth -= bulletDamage;
    }

    void EnemyDeath()
    {
        Destroy(gameObject);
    }

}