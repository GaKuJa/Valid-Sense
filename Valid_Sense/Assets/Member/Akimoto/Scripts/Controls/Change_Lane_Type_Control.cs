using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Lane_Type_Control:MonoBehaviour
{
    public static Change_Lane_Type_Control Instance { get => _instance; }
    static Change_Lane_Type_Control _instance;
    NotesLaneTypeScript notes_lane_type;
    void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// NotesList�̔ԍ����擾��AlaneType�𐔒l�ŕύX
    /// </summary>
    /// <param name="lane_type_num">Lane�̔ԍ�</param>
    /// <param name="notes_num">NotesList�̔ԍ�</param>
    public void Change_Lane_Type(int lane_type_num,int notes_num)
    {
        // get 
        notes_lane_type = StartNotesTimingScript.Instance.notesObj_list[notes_num].GetComponent<NotesLaneTypeScript>();
        var intLane_type = lane_type_num;
        var enumLane_type = (NotesLaneTypeScript.LaneType)Enum.ToObject(typeof(NotesLaneTypeScript.LaneType), intLane_type);
        notes_lane_type.laneType = enumLane_type;
    }
}
