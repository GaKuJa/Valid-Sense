using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesLaneTypeScript:MonoBehaviour
{
    // 現在のNotesがいるレーンの番号用enum型
    public enum LaneType
    {
        firstLane = 0,
        secondLane = 1,
        thirdLane = 2,
        fourthLane = 3,
        ollLane = 4
    };
    public LaneType laneType;
}
