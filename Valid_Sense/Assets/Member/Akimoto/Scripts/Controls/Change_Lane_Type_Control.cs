using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Lane_Type_Control:MonoBehaviour
{
    public static Change_Lane_Type_Control Instance { get => _instance; }
    static Change_Lane_Type_Control _instance;
    Notes_Lane_Type_Script notes_lane_type;
    void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// NotesListの番号を取得後、laneTypeを数値で変更
    /// </summary>
    /// <param name="lane_type_num">Laneの番号</param>
    /// <param name="notes_num">NotesListの番号</param>
    public void Change_Lane_Type(int lane_type_num,int notes_num)
    {
        // get 
        notes_lane_type = StartNotesTimingScript.Instance.notesObj_list[notes_num].GetComponent<Notes_Lane_Type_Script>();
        var intLane_type = lane_type_num;
        var enumLane_type = (Notes_Lane_Type_Script.LaneType)Enum.ToObject(typeof(Notes_Lane_Type_Script.LaneType), intLane_type);
        notes_lane_type.lane_type = enumLane_type;
    }
}
