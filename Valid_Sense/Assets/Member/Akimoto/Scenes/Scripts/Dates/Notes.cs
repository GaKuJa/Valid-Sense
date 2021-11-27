using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notes
{

    // ƒm[ƒc‚Ì“–‚½‚è”»’è‚ÌŠÔ
    public List<float> TimeList = new List<float>();
    // HoldŠÔ
    public List<float> HoldTimeList = new List<float>();
    // Notes‚ÌType
    public List<int> NotesTypeList = new List<int>();
    // Lane‚Ì”Ô†
    public List<int> LaneNumList = new List<int>();
}