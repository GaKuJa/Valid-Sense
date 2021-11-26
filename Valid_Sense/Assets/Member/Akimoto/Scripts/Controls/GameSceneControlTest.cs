using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneControlTest : MonoBehaviour
{
    public enum GameSceneMode
    {
        Normal,
        GameTime,
        GamePos,
        GameStart,
        Gameend,
    }
    public static GameSceneControlTest Instance { get => _instance; }
    static GameSceneControlTest _instance;
    public GameSceneMode gameSceneMode;
    void Awake()
    {
        _instance = this;
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameSampleScene")
        {
            gameSceneMode = GameSceneMode.GameStart;
        }
        if (SceneManager.GetActiveScene().name == "SetNotesTimingScene")
        {
            gameSceneMode = GameSceneMode.GameTime;
        }
        if (SceneManager.GetActiveScene().name == "SetNotesPositionScene")
        {
            gameSceneMode = GameSceneMode.GamePos;
        }
    }
}
