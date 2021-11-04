using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMoveControl : MonoBehaviour
{
    [SerializeField]
    private float notesMove_speed = 1.0f;
    private bool notesMove_flag = false;
    private GameObject notes;
    void Start()
    {
        notes = this.gameObject;
    }
    void FixedUpdate()
    {
        if (GameManager.Instance.gameMode == GameManager.GameMode.start)
        {
            NotesMove();
        }
    }
    private void NotesMove()
    {
        notes.transform.Translate(0.0f, -notesMove_speed, 0.0f);
    }
    public void GameStart()
    {
        notesMove_flag = true;
    }
    public void GameStop()
    {
        notesMove_flag = false;
    }
}
