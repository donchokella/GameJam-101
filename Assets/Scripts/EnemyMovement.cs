
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

    private float timer = 0;
    [SerializeField] private float changeInterval = 5f;

    public Vector2 direction = Vector2.up;
    [SerializeField] private float filterModifier;

    private void Awake()
    {
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

        EnemyMoveAnimation(); // ???
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
        EnemyDeathAnimation();  // ???

        KilledEnemy++;

        filterAlphaController.IncreaseAlpha(filterModifier);

        Destroy(gameObject);
    }

   

    private void GetDamage()
    {
        enemyHealth -= bulletDamage;
    }

    void EnemyDeathAnimation ()
    {
        // ???
    }

    void EnemyMoveAnimation()
    {
        // ???
    }
}
