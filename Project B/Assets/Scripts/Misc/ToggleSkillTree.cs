using UnityEngine;

public class ToggleSkillTree : MonoBehaviour
{
   public CanvasGroup statsCanvas;
   private bool skillTreeOpen = false;

    // Update is called once per frame
    void Update()
    {
        //skill tree appears when "1" is pressed; disappears when pressed again
        if (Input.GetButtonDown("ToggleSkillTree"))
        {
            if (skillTreeOpen)
            {
                Time.timeScale = 1;
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;
                skillTreeOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                skillTreeOpen = true;
            }
        }
    }
}
