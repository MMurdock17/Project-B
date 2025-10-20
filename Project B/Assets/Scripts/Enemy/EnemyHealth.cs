using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //getting variables set up
    public int expReward = 3;
    public delegate void EnemyDefeated(int exp);
    public static event EnemyDefeated OnEnemyDefeated;

    public int currentHealth;
    public int maxHealth;

    private void Start()
    {
        //starting health is set to max (20)
        currentHealth = maxHealth;
    }

    //allowing health to go down once hit; player gains experience upon enemy death
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
            OnEnemyDefeated(expReward);
            
        }
    }

}
