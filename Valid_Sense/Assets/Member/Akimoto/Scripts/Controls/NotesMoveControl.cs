using System;
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
    private GetNotesTimeScript getNotesTimeScript;
    private bool losFlag = false;
    private float transition = 0;
    private Vector3 startPoint;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        getNotesTimeScript = this.GetComponent<GetNotesTimeScript>();
        //notesMoveSpeed = getNotesTimeScript.GetNotesTime() / (judgeLane.transform.position.z - this.transform.position.z);
        //notesMoveSpeed = (float)Math.Round(notesMoveSpeed, 1, MidpointRounding.AwayFromZero);
        //notesMoveSpeed *= Time.fixedDeltaTime;

        startPoint = transform.position;
        var dist = judgeLane.transform.position.z - startPoint.z;
        notesMoveSpeed = dist * Time.fixedDeltaTime / getNotesTimeScript.GetNotesTime();
        
        Debug.LogError("Time:" + getNotesTimeScript.GetNotesTime());
        //Debug.LogError("LerpDis:" + dist);
        //Debug.LogError("notesMoveSpeed:" + notesMoveSpeed);
        //Debug.Log("notesFinishTime Is :" +(judgeLane.transform.position.z - this.transform.position.z) / notesMoveSpeed / 50);
    }
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "MainGameScene")
        {
            NotesMove();
        }
        if (judgeLane.transform.position.z >= this.transform.position.z && !losFlag)
        {
            Debug.Log(this.gameObject.name + " nowTime : " + MusicData.Timer / 1000f);
            losFlag = true;
            enabled = false;
        }
    }
    private void NotesMove()
    {
        //this.transform.Translate(0.0f, 0.0f, notesMoveSpeed)
        //;
        
        transition += Time.fixedDeltaTime / getNotesTimeScript.GetNotesTime();
        float posZ = Mathf.Lerp(startPoint.z, judgeLane.transform.position.z, transition);
        var pos = this.transform.position;
        pos.z = posZ;
        this.transform.position = pos;
    }
    private float GetOfSpeed()
    {
        return notesMoveSpeed;
    }
}
