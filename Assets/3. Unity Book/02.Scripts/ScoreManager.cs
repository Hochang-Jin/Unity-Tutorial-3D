using System;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "현재 점수: " +currentScore.ToString();

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고 점수: " + bestScore.ToString();
            
                PlayerPrefs.SetInt("bestScore", bestScore);
            }
        }
    }
    private int currentScore;
    private int bestScore;

    private void Start()
    {
        if(PlayerPrefs.GetInt("bestScore") != null)
        {
            bestScore = PlayerPrefs.GetInt("bestScore");
            bestScoreUI.text = "최고 점수 : " + bestScore.ToString();
        }
    }
}
