using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] bool isNormalTimer;
    TMP_Text text;
    public bool shouldCountDown;
    public int maxCountDownTime;
    public float currentCountDownTime;
    string currentPlayer;

    void Start()
    {
        if (maxCountDownTime <= 0) Debug.LogError("Time is zero or less");
        currentCountDownTime = maxCountDownTime;
        text = GetComponent<TMP_Text>();
        if (!isNormalTimer)
            currentPlayer = GetComponentInParent<DropCharacterScreen>().currentPlayer.ToString();
        else currentPlayer = "No Player";
    }

    void Update()
    {
        if (!shouldCountDown) return;

        CountDown();
    }

    private void CountDown()
    {
        currentCountDownTime -= Time.deltaTime;
        text.text = currentCountDownTime.ToString("f0");
        if (currentCountDownTime <= 0) 
        {
            currentCountDownTime = 0;
            shouldCountDown = false;
            PlayerRanOutOfTime();
        }
    }

    public void ResetTimer()
    {
        shouldCountDown = false;
        currentCountDownTime = maxCountDownTime;
        Debug.Log(string.Format("{0}'s timer resetted", GetCurrentPlayer()));
    }

    private void PlayerRanOutOfTime()
    {
        shouldCountDown = false;
        text.text = "0";
        Debug.LogError(string.Format("{0} ran out of time.", GetCurrentPlayer()));
    }

    private string GetCurrentPlayer()
    {
        return currentPlayer;
    }
}
