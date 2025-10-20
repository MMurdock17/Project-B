using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
	//variables
	public TMP_Text healthText;
	public Animator healthTextAnim;
	public GameManager gameManager;

	private bool isDead;

	//updates UI for player
	private void Start()
	{
		healthText.text = "HP:" + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;
	}

	//updates UI for player and decreases health
	public void ChangeHealth(int amount)
	{
		StatsManager.Instance.currentHealth += amount;

		healthTextAnim.Play("TextUpdate");

		healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;

		//player dies; game over screen appears
		if (StatsManager.Instance.currentHealth <= 0 && !isDead)
		{
			isDead = true;
			gameObject.SetActive(false);
			gameManager.GameOver();
		}
	}
}
