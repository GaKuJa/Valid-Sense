using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NotesMoveControl : MonoBehaviour
{
    public static NotesMoveControl Instance { get => _instance; }
    static NotesMoveControl _instance;
    [SerializeField]
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
    void Update()
    {
        
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
    private void NotesMove()
    {
        this.transform.Translate(0.0f, 0.0f, notesMoveSpeed);
    }
}
