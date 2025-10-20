using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //variables
    public float speed;
    public float attackRange = 2;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private float attackCooldownTimer;
    private Rigidbody2D rb;
    private Transform player;
    private int facingDirection = 1;
    private Animator anim;
    private EnemyState enemyState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //calling variables
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        //allowing for cooldown between enemy attacks
        if (enemyState != EnemyState.Knockback)
        {
         CheckForPlayer();

          if (attackCooldownTimer > 0)
          {
               attackCooldownTimer -= Time.deltaTime;
           }

           if (enemyState == EnemyState.Chasing)
           {
              Chase();
           }
           else if (enemyState == EnemyState.Attacking)
          {
             rb.linearVelocity = Vector2.zero;
         }
        }
    }

    void Chase()
    {

        
        //setting position of enemy; allowing them to chase the player
        if (player.position.x > transform.position.x && facingDirection == 1 || player.position.x < transform.position.x && facingDirection == -1)
            {
                Flip();
            }
            
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        //flips enemy sprite
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    //checks whether the player is in collider; prompts chase and attack
    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            if (Vector2.Distance(transform.position, player.transform.position) < attackRange && attackCooldownTimer <= 0)
        {
            attackCooldownTimer = attackCooldown;
            ChangeState(EnemyState.Attacking);
        }
            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }

        
    }

    
    //changing states of enemy based on circumstances
    public void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", false);
        }

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", true);
        }

    }

}
//adding enumerations
public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockback
}
