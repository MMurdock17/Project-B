using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //variables
public Rigidbody2D rb;
public Animator anim;
public int facingDirection = 1;

private bool isKnockedBack;

public PlayerCombat playerCombat;

//player attacks when certain button pressed
private void Update()
{
    if (Input.GetButtonDown("Attack") && playerCombat.enabled == true)
    {
        playerCombat.Attack();
    }
}


    // Update is called 50x per frame
    void FixedUpdate()
    {
        //handles player standard movement
        if (isKnockedBack == false)
        {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
    }

    //flips player based on facing direction
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    //handles knockback and stun time when hit
    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }

}
