using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public enum GameMode
    {
        Normal,
        start,
        end,
    }
    public static GameManager Instance { get => _instance; }
    static GameManager _instance;
    public GameMode gameMode;
    //GameObject notes_clone;
    //NotesMoveControl notes_Move;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        //notes_clone = GameObject.FindWithTag("Notes");
        //notes_Move = notes_clone.GetComponent<NotesMoveControl>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "NotesTestScene")
        {
            gameMode = GameMode.Normal;
        }
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            switch (gameMode)
            {
                case GameMode.Normal:
                    gameMode = GameMode.start;
                    break;
                case GameMode.start:
                    break;
                default:
                    Debug.Log("GameMode Err");
                    break;
            }
        }
    }
}
