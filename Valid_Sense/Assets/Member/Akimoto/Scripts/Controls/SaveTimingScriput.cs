using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimingScriput : MonoBehaviour
{
    public static SaveTimingScriput Instance { get => _instance; }
    static SaveTimingScriput _instance;
    [SerializeField]
    private float notesTime = 0;
    private float holdStartTime = 0;
    private float holdEndTime = 0;
    private bool holdtimeFlag = false;
    public Notes _notes = new Notes();
    void Awake()
    {
        _instance = this;
    }
    public void SetNotesTiming(int notestype_num)
    {
        notesTime = MusicData.Timer;
        _notes.TimeList.Add(notesTime / 1000);
        _notes.NotesTypeList.Add(notestype_num);
    }
    public void StartHold(int notestype_num)
    {
        notesTime = MusicData.Timer;
        holdStartTime = MusicData.Timer /1000;
        holdtimeFlag = true;
        _notes.TimeList.Add(notesTime / 1000);
        _notes.NotesTypeList.Add(notestype_num);
    }
    public void FinishHold()
    {
        holdEndTime = MusicData.Timer / 1000;
        _notes.HoldTimeList.Add(holdEndTime - holdStartTime);
        holdtimeFlag = false;
    }
}
