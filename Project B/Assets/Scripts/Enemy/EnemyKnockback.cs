using UnityEngine;
using System.Collections;

public class EnemyKnockback : MonoBehaviour
{
    //variables
    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;

    private void Start()
    {
        //finding variabls
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void Knockback(Transform playerTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        //setting up knockback state
        enemyMovement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        //setting up stun
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.ChangeState(EnemyState.Idle);
    }

}
