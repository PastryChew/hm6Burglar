using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject buttonTool1;
    public GameObject buttonTool2;
    public GameObject buttonTool3;

    public GameObject buttonStartTimer;

    public GameObject winPanel;
    public GameObject losePanel;

    public Text pin1;
    public Text pin2;
    public Text pin3;

    public Text timerText;
    public Text startTimerGame;

    private bool IsTimerStart = false;
    private float TimeLeft;
    private int countPin1;
    private int countPin2;
    private int countPin3;

    public void ButtonTool1()
    {
        countPin1 += 1;
        countPin2 -= 1;
    }

    public void ButtonTool2()
    {
        countPin1 -= 1;
        countPin2 += 2;
        countPin3 -= 1;

    }
    public void ButtonTool3()
    {
        countPin1 -= 1;
        countPin2 += 1;
        countPin3 += 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        pin1.text = countPin1.ToString();
        pin2.text = countPin2.ToString();
        pin3.text = countPin3.ToString();

        if (IsTimerStart)
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft < 0)
            {
                losePanel.SetActive(true);
                IsTimerStart = false;
                startTimerGame.enabled = true;
                buttonStartTimer.SetActive(true);
                buttonTool1.SetActive(false);
                buttonTool2.SetActive(false);
                buttonTool3.SetActive(false);
            }
            timerText.text = TimeLeft.ToString("F2");
        }
        if (countPin1 == 0 && countPin2 == 0 && countPin3 == 0 && IsTimerStart)
        {
            winPanel.SetActive(true);
            IsTimerStart = false;
            startTimerGame.enabled = true;
            buttonStartTimer.SetActive(true);
            buttonTool1.SetActive(false);
            buttonTool2.SetActive(false);
            buttonTool3.SetActive(false);

        }

    }
    public void Timer()
    {
        IsTimerStart = true;

        buttonStartTimer.SetActive(false);

        TimeLeft = 30f;
        countPin1 = 1;
        countPin2 = -3;
        countPin3 = 1;

        startTimerGame.enabled = false;

        buttonTool1.SetActive(true);
        buttonTool2.SetActive(true);
        buttonTool3.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
        
}
