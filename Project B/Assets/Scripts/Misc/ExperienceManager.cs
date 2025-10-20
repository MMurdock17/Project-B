using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    //variaables
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthMultiplier = 1.2f;
    public Slider expSlider;
    public TMP_Text currentLevelText;

    private void Start()
    {
        UpdateUI();
    }

    //tester for experience -- feel free to comment out
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainExperience(2);
        }
    }

    //player gains XP on enemy death
    private void OnEnable()
    {
        EnemyHealth.OnEnemyDefeated += GainExperience;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDefeated -= GainExperience;
    }

    //amount of XP gained
    public void GainExperience(int amount)
    {
        currentExp += amount;
        if(currentExp >= expToLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    //player levels up at certain XP number
    private void LevelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
    }

    //updates UI to display to player
    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
        UpdateUI();
    }

}
