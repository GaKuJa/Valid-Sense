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
    private bool losFlag = false;
    private bool startfMusiclag = false;
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
        {
            //NotesMove();
            StartCoroutine(NotesSatrt());
        }
        if (!startfMusiclag)
        {
            //MusicPlayer.instance.Music_Play(0);
            StartCoroutine(MusicPlay());
            startfMusiclag = true;
        }
        if (judgeLane.transform.position.z >= this.transform.position.z && !losFlag)
        {
            Debug.Log(this.gameObject.name + ":" + MusicData.Timer / 1000f);
            losFlag = true;
        }
    }
    private void NotesMove()
    {
        this.transform.Translate(0.0f, 0.0f, notesMoveSpeed);
    }
    IEnumerator NotesSatrt()
    {
        yield return new WaitForSeconds(1.0f);
        this.transform.Translate(0.0f, 0.0f, notesMoveSpeed);
    }
    IEnumerator MusicPlay()
    {
        yield return new WaitForSeconds(1.0f);
        MusicPlayer.instance.Music_Play(0);
    }
}
