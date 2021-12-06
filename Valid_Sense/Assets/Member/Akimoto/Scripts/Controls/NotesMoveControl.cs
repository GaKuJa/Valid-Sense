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
    public float notesMoveSpeed = 0.0f;
    [SerializeField]
    private GameObject judgeLane;
    private GetNotesTimeScript getNotesTime;
    private bool flag = false;
    private bool startflag = false;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        getNotesTime = this.GetComponent<GetNotesTimeScript>();
        notesMoveSpeed = (judgeLane.transform.position.z - this.transform.position.z) / getNotesTime.notesTime / 50;
    }
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "MainGameScene")
            NotesMove();
    }
    private void NotesMove()
    {
        notes.transform.Translate(0.0f,0.0f, -notesMove_speed);
        if (!startflag)
        {
            MusicPlayer.instance.Music_Play(0);
            startflag = true;
        }
        if (judgeLane.transform.position.z >= this.transform.position.z && !flag)
        {
            Debug.Log(this.gameObject.name + ":" + MusicData.Timer / 1000f);
            flag = true;
        }
    }
}
