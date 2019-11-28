using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public static CountdownTimer Instance;
    
    [Header("Enter time left in seconds")] public const int TIMELEFT = 90;
    public TextMeshProUGUI countDownText;

    public int timeLeft;
    private bool oneTime = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        timeLeft = TIMELEFT;
        StartCoroutine("LoseTime");
        Time.timeScale = 1f;
    }

    private void Update()
    {
        int min, sec;
        TimeToMin(timeLeft,out min, out sec);
        countDownText.text = min.ToString("00") + ":" + sec.ToString("00");
        if (timeLeft <= 10 && oneTime)
        {
            countDownText.color = Color.red;
            countDownText.fontSize = 58f;
            oneTime = false;
        }

        if (timeLeft == 0)
        {
            //CheckWinningConditionAndDeclareScoreTakingThatIntoConsideration
            //Debug.Log("Game Over!!!");
            UISetup.Instance.GameOverReady();
            //ShowGameOverScreen
            Time.timeScale = 0;
        }

        if (timeLeft <= (TIMELEFT - (TIMELEFT / 3)))
        {
            EnemySpawn.spawnTimer = 1.3f;
        }

        if (timeLeft <= (TIMELEFT - (TIMELEFT / 3)))
        {
            EnemySpawn.spawnTimer = 0.6f;
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    void TimeToMin(int _timeLeft,out int min,out int sec)
    {
        min = _timeLeft / 60;
        sec = _timeLeft % 60;
    }
}
