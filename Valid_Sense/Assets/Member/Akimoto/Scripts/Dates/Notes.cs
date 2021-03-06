using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notes
{

    // ノーツの当たり判定の時間
    public List<float> TimeList = new List<float>();
    // Hold時間
    public List<float> HoldTimeList = new List<float>();
    // NotesのType
    public List<int> NotesTypeList = new List<int>();
    // Laneの番号
    public List<int> LaneNumList = new List<int>();
}