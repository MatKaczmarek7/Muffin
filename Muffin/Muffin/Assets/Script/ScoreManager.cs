using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreMenuText;
    public Text scoreGameText;

    public Text endPlayerScore;
    public Text endHighScore;

    private const int gainScored = 10;

    private const string prefsHighScoreKey = "High score";
    private const string highScore = "High score: ";
    private const string gameScoreText = "Score: ";
    private const string endPlayerScoreText = "Players score: ";

    private void OnEnable()
    {
        InputDetector.OnDetectTap += GetScore;
    }

    private void OnDisable()
    {
        InputDetector.OnDetectTap -= GetScore;
    }

    public float SavedScore
    {
        get
        {
            return PlayerPrefs.GetFloat(prefsHighScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetFloat(prefsHighScoreKey, value);
        }
    }

    private float score;
    public float GameScore {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreGameText.text = gameScoreText + value;
        }
       }

    public void ResetScore()
    {
        GameScore = 0;
    }

    public void SetHighScore()
    {
        scoreMenuText.text = highScore + SavedScore.ToString();
    }

    public void GetScore()
    {
        GameScore += gainScored;
    }

    public void TryToSaveScore()
    {
        if (GameScore >= SavedScore)
        {
            SavedScore = GameScore;
        }
    }

    public void LoadEndScore()
    {
        TryToSaveScore();
        endPlayerScore.text = endPlayerScoreText + GameScore.ToString();
        endHighScore.text = highScore + SavedScore.ToString();
    }


}
