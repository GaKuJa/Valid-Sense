using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes_Lane_Type_Script:MonoBehaviour
{
    // ���݂�Notes�����郌�[���̔ԍ��penum�^
    public enum LaneType
    {
        first_lane = 0,
        second_lane = 1,
        third_lane = 2,
        fourth_lane = 3
    };
    public LaneType lane_type;
}
