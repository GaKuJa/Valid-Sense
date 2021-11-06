using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    Player1,
    Player2
}

public class DropCharacterScreen : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] float dropSpeedInSeconds;
    public Player currentPlayer;
    public float currentTime;
    Vector3 startingPos;
    Vector3 endingPos;
    float endingYPos;
    private bool moveUI;
    private bool dropCompleted;
    int mouseButton;
    public CountDownTimer timer;
    bool playerIsReady = false;
    [SerializeField] GameObject waitingUI;
    AudioSource audioSource;
    [SerializeField] AudioClip fallingUISound;

    void Start()
    {
        if (dropSpeedInSeconds <= 0) Debug.LogError("Value is less than or equal to zero!");
        timer = GetComponentInChildren<CountDownTimer>();
        currentTime = 0;
        rectTransform = GetComponent<RectTransform>();
        startingPos = rectTransform.position;
        endingPos = new Vector3(startingPos.x, endingYPos, startingPos.z);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fallingUISound;

        switch (currentPlayer)
        {
            case Player.Player1:
                mouseButton = 0;
                break;
            case Player.Player2:
                mouseButton = 1;
                break;
            default:
                Debug.LogError("CurrentPlayerError");
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { ResetBothPlayers(); }
        if (Input.GetMouseButtonDown(mouseButton)) { ReadyUp(); }
        if (!moveUI) return;

        DropCharacterUI();
    }

    private void ReadyUp()
    {
        moveUI = true;
        timer.shouldCountDown = true;
        playerIsReady = true;
        Debug.Log(string.Format("{0} is ready!", currentPlayer.ToString()));
        audioSource.Play();
    }

    private void ResetBothPlayers()
    {
        ResetDropCharacterUI();
        timer.ResetTimer();
        playerIsReady = false;
    }

    private void ResetDropCharacterUI()
    {
        moveUI = false;
        currentTime = 0;
        rectTransform.position = startingPos;
    }

    private void DropCharacterUI()
    {
        currentTime += Time.deltaTime / dropSpeedInSeconds;
        rectTransform.position = Vector3.Lerp(startingPos, endingPos, currentTime);
        if (currentTime >= 1) moveUI = false;
    }

    public bool IsPlayerReady()
    {
        return playerIsReady;
    }

    public void DisableWaitingUI()
    {
        waitingUI.SetActive(false);
    }
}






