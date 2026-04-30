using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public AnimationCurve levelGoal;
    public TextMeshProUGUI currentLevelText, nextLevelText, clearedLevelText;
    public Image levelBarImage;
    public int maxLevels = 200;

    private int tempScore = 0, tempGoal, tempLevel;

    void Start()
    {
        tempLevel = PlayerPrefs.GetInt("Level", 1);
        tempGoal = Mathf.FloorToInt(levelGoal.Evaluate((float)tempLevel / maxLevels));      //Calculates the goal for this level based on the values of the curve

        //Updates level texts
        currentLevelText.text = tempLevel.ToString();
        nextLevelText.text = (tempLevel + 1).ToString();
        clearedLevelText.text = "LEVEL " + tempLevel.ToString() + "\nCLEARED";
    }

    public void UpdateGoalFillAmout()
    {
        tempScore++;
        levelBarImage.fillAmount = ((float)tempScore / tempGoal);       //Calculates the amount of the bar

        if (levelBarImage.fillAmount >= 1f)     //If the bar fills
            FindObjectOfType<Spawner>().scoreReached = true;
    }
}
