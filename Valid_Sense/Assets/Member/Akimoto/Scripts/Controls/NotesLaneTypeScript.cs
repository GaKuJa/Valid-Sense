using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesLaneTypeScript : MonoBehaviour
{
    // ���݂�Notes�����郌�[���̔ԍ��penum�^
    public enum LaneType
    {
        firstLane = 0,
        secondLane = 1,
        thirdLane = 2,
        fourthLane = 3,
        allLane = 4
    };
    public LaneType laneType;

}
