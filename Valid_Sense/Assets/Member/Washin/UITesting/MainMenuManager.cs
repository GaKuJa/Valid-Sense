using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuStates
{
    TitleScreen,
    WaitingForPlayersToReadyUp,
    CharacterSelection,
    WaitingForPlayersToSelectCharacters,
    SongSelection,
    GamePlay,
    Results
}

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public MenuStates currentState;
    public static event Action<MenuStates> OnMenuStateChanged;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        UpdateGameState(MenuStates.TitleScreen);
    }

    public void UpdateGameState(MenuStates newState)
    {
        switch (newState)
        {
            case MenuStates.TitleScreen:
                //DisableOtherUI();
                break;
            case MenuStates.WaitingForPlayersToReadyUp:
                break;
            case MenuStates.CharacterSelection:
                break;
            case MenuStates.WaitingForPlayersToSelectCharacters:
                break;
            case MenuStates.SongSelection:
                break;
            case MenuStates.GamePlay:
                break;
            case MenuStates.Results:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnMenuStateChanged?.Invoke((newState));
    }





}
