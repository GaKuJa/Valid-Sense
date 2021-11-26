using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notes
{
    // ノーツの場所
    public List<Vector3> NotesList = new List<Vector3>();
    // ノーツの当たり判定の時間
    public List<float> TimeList = new List<float>();
    public List<int> NotesTypeList = new List<int>();
    public List<float> HoldTimeList = new List<float>();
}