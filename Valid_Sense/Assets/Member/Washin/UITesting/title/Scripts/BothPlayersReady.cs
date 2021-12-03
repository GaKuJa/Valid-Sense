using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BothPlayersReady : MonoBehaviour
{
    DropCharacterScreen player1;
    DropCharacterScreen player2;
    [SerializeField] GameObject readyUpGameObject;
    [SerializeField] GameObject splashArt;
    [SerializeField] RawImage waterEffect;
    [SerializeField] Material greyMat;
    [SerializeField] GameObject characterSelectGameObject;

    bool isTransitioning = false;

    void Start()
    {
        DropCharacterScreen[] playerList = GetComponentsInChildren<DropCharacterScreen>();
        player1 = playerList[0];
        player2 = playerList[1];
        characterSelectGameObject.SetActive(false);
    }

    void Update()
    {
        if (player1.IsPlayerReady() && player2.IsPlayerReady())
        {
            player1.DisableWaitingUI();
            player2.DisableWaitingUI();
            WaitForPlayerInput();
        }
    }

    private void WaitForPlayerInput()
    {
        if (isTransitioning) return;
        isTransitioning = true;
        TransitionScreen.instance.DropShutter(1f, 1f, 1f, 3f);
        Invoke("MoveToCharacterSelection", 1.5f);
    }

    private void MoveToCharacterSelection()
    {
        characterSelectGameObject.SetActive(true);
        readyUpGameObject.SetActive(false);
        splashArt.SetActive(false);
        waterEffect.material = greyMat;
    }
    //private void MoveToGameScreen()
    //{
    //    Debug.Log("Moving to next scene");
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
}
