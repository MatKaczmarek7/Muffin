using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GUICanvas canvas;
    public ScoreManager scoreManager;
    public InputDetector inputDetector;

    public Text timeLeftText;
    public Image progressBar;

    private float timerCount = 0;
    private float timerLeft = 0;

    private bool enabledTimerCount = false;
    private bool enabledTimerLeft = false;

    private const float gameDuration = 10;
    private const float startTimerCount = 3;
    private const float endTimerCount = -1;
    private const string goText = "GO!";

    private void Awake()
    {
        scoreManager.SetHighScore();
    }

    public void StartGame()
    {
        scoreManager.ResetScore();
        canvas.ChangeToGameWindow();
        InitializeTimerCount();
        InitializeTimerLeft();
    }

    private void InitializeTimerCount()
    {
        timerCount = startTimerCount;
        enabledTimerCount = !enabledTimerCount;
    }

    private void InitializeTimerLeft()
    {
        timerLeft = gameDuration;
        SetTimeLeftText();
        progressBar.fillAmount = 1;
    }

    public void EndGame()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Muffin"))
        {
            Destroy(g);
        }
        inputDetector.SetActiveInputDetector(false);
        scoreManager.LoadEndScore();
        canvas.ChangeToEndWindow();
    }

    public void RepeatGame()
    {
        StartGame();
    }

    public void GoToMenu()
    {
        canvas.ChangeToMenuWindow();
        scoreManager.SetHighScore();
    }

    private void FixedUpdate()
    {
        if (enabledTimerCount)
        {
            UpdateTimerCount();
        }

        if (enabledTimerLeft)
        {
            UpdateTimerLeft();
        }
    }

    private void UpdateTimerCount()
    {
        timerCount -= Time.fixedDeltaTime;

        if (timerCount <= endTimerCount)
        {
            canvas.SetTimerCount("");
            enabledTimerCount = !enabledTimerCount;
            enabledTimerLeft = !enabledTimerLeft;
            inputDetector.SetActiveInputDetector(true);
        }
        else if (timerCount <= 0)
        {
            canvas.SetTimerCount(goText);
        }
        else
        {
            canvas.SetTimerCount(Mathf.CeilToInt(timerCount).ToString());
        }
    }

    private void UpdateTimerLeft()
    {
        timerLeft -= Time.fixedDeltaTime;
        progressBar.fillAmount = timerLeft / gameDuration;
        SetTimeLeftText();

        if (timerLeft <= 0)
        {
            enabledTimerLeft = !enabledTimerLeft;
            EndGame();
        }
    }

    private void SetTimeLeftText()
    {
        timeLeftText.text = Mathf.CeilToInt(timerLeft).ToString();

    }
}
