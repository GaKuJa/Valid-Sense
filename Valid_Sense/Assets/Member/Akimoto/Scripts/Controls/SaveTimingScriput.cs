using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimingScriput : MonoBehaviour
{
    public static SaveTimingScriput Instance { get => _instance; }
    static SaveTimingScriput _instance;
    [SerializeField]
    private float notesTime = 0;
    private float holdnotesTime = 0;
    private bool timeFlag = false;
    private bool holdtimeFlag = false;
    public Notes _notes = new Notes();
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        timeFlag = true;
    }
    void Update()
    {
        if (timeFlag)
            StartTime();
        if (holdtimeFlag)
        {
            StartHoldTime();
        }
    }
    private void StartTime()
    {
        notesTime += Time.deltaTime;
    }
    private void StartHoldTime()
    {
        holdnotesTime += Time.deltaTime;
    }
    public void SetNotesTiming(int notestype_num)
    {
        _notes.TimeList.Add(notesTime);
        _notes.NotesTypeList.Add(notestype_num);
    }
    public void StartHold(int notestype_num)
    {
        holdtimeFlag = true;
        _notes.TimeList.Add(notesTime);
        _notes.NotesTypeList.Add(notestype_num);
    }
    public void FinishHold()
    {
        _notes.HoldTimeList.Add(holdnotesTime);
        holdtimeFlag = false;
        holdnotesTime = 0;
    }
}
