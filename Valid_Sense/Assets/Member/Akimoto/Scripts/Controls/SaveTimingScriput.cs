using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimingScriput : MonoBehaviour
{
    public static SaveTimingScriput Instance { get => _instance; }
    static SaveTimingScriput _instance;
    [SerializeField]
    private float notes_time = 0;
    private float holdnotes_time = 0;
    private bool time_flag = false;
    private bool holdtime_flag = false;
    public Notes _notes = new Notes();
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        time_flag = true;
    }
    void Update()
    {
        if (time_flag)
            StartTime();
        if (holdtime_flag)
        {
            StartHoldTime();
        }
    }
    private void StartTime()
    {
        notes_time += Time.deltaTime;
    }
    private void StartHoldTime()
    {
        holdnotes_time += Time.deltaTime;
    }
    public void SetNotesTiming(int notestype_num)
    {
        _notes.TimeList.Add(notes_time);
        _notes.NotesTypeList.Add(notestype_num);
    }
    public void StartHold()
    {
        holdtime_flag = true;
        _notes.TimeList.Add(notes_time);
    }
    public void FinishHold(int notestype_num)
    {
        _notes.HoldTimeList.Add(holdnotes_time);
        holdtime_flag = false;
        holdnotes_time = 0;
        _notes.NotesTypeList.Add(notestype_num);
        Debug.Log(notestype_num);
    }
}
