using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUICanvas : MonoBehaviour
{

    public GameObject menuWindow;
    public GameObject gameWindow;
    public GameObject endWindow;

    public Text timerCountText;

    public void ChangeToGameWindow()
    {
        endWindow.SetActive(false);
        menuWindow.SetActive(false);
        gameWindow.SetActive(true);
    }

    public void ChangeToMenuWindow()
    {
        menuWindow.SetActive(true);
        endWindow.SetActive(false);
    }

    public void ChangeToEndWindow()
    {
        endWindow.SetActive(true);
        gameWindow.SetActive(false);
    }

    public void SetTimerCount(string value)
    {
        timerCountText.text = value;
    }

}
