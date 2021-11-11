using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPositionControl : MonoBehaviour
{
    public static ChangeCameraPositionControl Instance { get => _instance; }
    static ChangeCameraPositionControl _instance;
    void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        Debug.Log(StartNotesTimingScript.Instance.notesObj_list.Count);
    }
    public void ChangeCameraPos(int notes_pos)
    {
        Camera.main.transform.Translate(0.0f,
                                        StartNotesTimingScript.Instance.notesObj_list[notes_pos].transform.position.y,
                                        0.0f);
    }
}
