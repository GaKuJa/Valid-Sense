using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notes
{

    // �m�[�c�̓����蔻��̎���
    public List<float> TimeList = new List<float>();
    // Hold����
    public List<float> HoldTimeList = new List<float>();
    // Notes��Type
    public List<int> NotesTypeList = new List<int>();
    // Lane�̔ԍ�
    public List<int> LaneNumList = new List<int>();
}