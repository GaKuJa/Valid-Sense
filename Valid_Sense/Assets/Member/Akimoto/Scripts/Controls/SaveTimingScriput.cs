using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimingScriput : MonoBehaviour
{
    public static SaveTimingScriput Instance { get => _instance; }
    static SaveTimingScriput _instance;
    [SerializeField]
    private float notes_time = 0;
    private bool time_flag = false;
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
    }
    private void StartTime()
    {
        notes_time += Time.deltaTime;
    }
    public void SetNotesTiming()
    {
        _notes.TimeList.Add(notes_time);
    }
}
