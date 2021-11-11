using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NotesMoveControl : MonoBehaviour
{
    public static NotesMoveControl Instance { get => _instance; }
    static NotesMoveControl _instance;
    [SerializeField]
    public float notesMove_speed = 1.0f;
    private bool notesMove_flag = false;
    private GameObject notes;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        notes = this.gameObject;
    }
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "GameSampleScene"||SceneManager.GetActiveScene().name == "GameScene")
            NotesMove();
    }
    private void NotesMove()
    {
        notes.transform.Translate(0.0f, -notesMove_speed, 0.0f);
    }
}
